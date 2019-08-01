using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WyMerge
{
    public partial class Form1 : Form
    {
        public static Bitmap bmp1, bmp2;
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap PromptBmp() //Opens an open file prompt for the user to select a bitmap image
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmap Image (*.bmp)|*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return new Bitmap(ofd.FileName);
            } else
            {
                return null;
            }
        }

        private void bLoadImg2_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap = PromptBmp();
            if (newBitmap == null) return;
            bmp2 = newBitmap;
            iDisplay2.Image = new Bitmap(newBitmap, new Size(256, 256));
            if (bmp2.Width * bmp2.Height > 5000) MessageBox.Show("This bitmap has over 5000 pixels. Generating a WyMerge with this many pixels may take a long time or even cause the program to crash.", "Hold on...");
        }

        private void bLoadImg1_Click(object sender, EventArgs e)
        {
            Bitmap newBitmap = PromptBmp();
            if (newBitmap == null) return;
            bmp1 = newBitmap;
            iDisplay1.Image = new Bitmap(newBitmap, new Size(256, 256));
            if (bmp1.Width * bmp1.Height > 5000) MessageBox.Show("This bitmap has over 5000 pixels. Generating a WyMerge with this many pixels may take a long time or even cause the program to crash.", "Hold on...");
        }

        private void bGenerate_Click(object sender, EventArgs e)
        {
            if (bmp1 != null && bmp2 != null)
            {
                if (bmp1.Width == bmp2.Width && bmp1.Height == bmp2.Height) {
                    if (bmp1.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb && bmp2.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                    {
                        tProgress.Text = "Gathering frames...";
                        GifBitmapEncoder generatedWyMerge = GenerateWyMerge(bmp1, bmp2, tbFrames.Value, tbThreshold.Value);
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "GIF Image (*.gif)|*.gif";
                        sfd.Title = "Save " + generatedWyMerge.Frames.Count + " frame WyMerge";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            FileStream stream = (FileStream)sfd.OpenFile();
                            generatedWyMerge.Save(stream);
                            stream.Close();
                        }
                    } else
                    {
                        MessageBox.Show("WyMerge currently only supports 24-bit RGB bitmaps.\n\nBitmap 1: " + bmp1.PixelFormat.ToString() + "\nBitmap 2: " + bmp2.PixelFormat.ToString(), "Whoops...");
                    }
                } else
                {
                    MessageBox.Show("Both bitmaps need to be the same dimensions, else the WyMerge can\'t generate!\n\nBitmap 1: " + bmp1.Width + " x " + bmp1.Height + "\nBitmap 2: " + bmp2.Width + " x " + bmp2.Height, "Whoops...");
                }
            }
            else
            {
                MessageBox.Show("Both bitmaps need to be loaded before generating a WyMerge!", "Whoops...");
            }
        }

        private void tbFrames_Scroll(object sender, EventArgs e)
        {
            tFramesIndicator.Text = "Frames: " + tbFrames.Value;
        }

        public GifBitmapEncoder GenerateWyMerge(Bitmap bitmap1, Bitmap bitmap2, int frames, int threshold)
        {
            GifBitmapEncoder gifEncoder = new GifBitmapEncoder();
            List<Pixel> pixels1 = new List<Pixel>();
            List<Pixel> pixels2 = new List<Pixel>();
            Dictionary<Pixel, Pixel> pixelRelations = new Dictionary<Pixel, Pixel>();
            SplitBmpPixels(bitmap1, out pixels1);
            SplitBmpPixels(bitmap2, out pixels2);
            pixelRelations = CreatePixelRelations(pixels1, pixels2, threshold);
            tProgress.Text = "Moving pixels around...";
            for (int f = 0; f <= frames; f++)
            {
                Bitmap newFrame = new Bitmap(bitmap1.Width, bitmap1.Height);
                foreach (KeyValuePair<Pixel, Pixel> relation in pixelRelations)
                {
                    float percFrames = (float)f / frames;
                    System.Drawing.Color lerpedColor = System.Drawing.Color.FromArgb(255, (int)Lerp(relation.Key.c.R, relation.Value.c.R, percFrames), (int)Lerp(relation.Key.c.G, relation.Value.c.G, percFrames), (int)Lerp(relation.Key.c.B, relation.Value.c.B, percFrames));
                    newFrame.SetPixel((int)Lerp(relation.Key.x, relation.Value.x, percFrames), (int)Lerp(relation.Key.y, relation.Value.y, percFrames), lerpedColor);
                }
                gifEncoder.Frames.Add(BitmapFrame.Create(BitmapToBitmapSource(newFrame)));
            }
            tProgress.Text = "Saving WyMerge (" + pixelRelations.Count + " PxR)";
            return gifEncoder;
        }

        public Dictionary<Pixel, Pixel> CreatePixelRelations(List<Pixel> baseImage, List<Pixel> newImage, int threshold)
        {
            Dictionary<Pixel, Pixel> pixelRelations = new Dictionary<Pixel, Pixel>();
            foreach (Pixel px in baseImage)
            {
                bool canBreak = false;
                foreach (Pixel px2 in newImage)
                {
                    float colDiff = 0;
                    if (cbColorBase.SelectedIndex == 0)
                    {
                        colDiff = Math.Abs(px.c.GetHue() - px2.c.GetHue());
                    } else if (cbColorBase.SelectedIndex == 1)
                    {
                        colDiff = Math.Abs(px.c.GetBrightness() - px2.c.GetBrightness());
                    }
                    if (colDiff <= threshold)
                    {
                        pixelRelations.Add(px, new Pixel(px2));
                        newImage.Remove(px2);
                        groupBox2.Refresh();
                        canBreak = true;
                        break;
                    }
                }
                if (canBreak) continue;
                pixelRelations.Add(px, new Pixel(newImage[0]));
                newImage.RemoveAt(0);
            }
            return pixelRelations;
        }

        public BitmapSource BitmapToBitmapSource(Bitmap bitmap)
        {
            var bmp = bitmap.GetHbitmap();
            var src = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bmp,
                IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return src;
        }

        public void SplitBmpPixels(Bitmap bitmap, out List<Pixel> pixelData)
        {
            pixelData = new List<Pixel>();
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixelData.Add(new Pixel(x, y, bitmap.GetPixel(x, y)));
                }
            }
        }

        float Lerp(float firstFloat, float secondFloat, float t)
        {
            return firstFloat * (1 - t) + secondFloat * t;
        }

        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        private void tbThreshold_Scroll(object sender, EventArgs e)
        {
            tThreshold.Text = "Color Threshold: " + tbThreshold.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("WyMerge Version 1.0.0r\nCreated by SixBeeps in 2019\n\n\n.NET Framework Version 4.6.1", "About WyMerge", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }

    public class Pixel
    {
        public int x, y;
        public System.Drawing.Color c;

        public Pixel(int px, int py, System.Drawing.Color color)
        {
            x = px;
            y = py;
            c = color;
        }

        public Pixel(Pixel oldP) //Creates a copy of a Pixel
        {
            x = oldP.x;
            y = oldP.y;
            c = oldP.c;
        }
    }
}
