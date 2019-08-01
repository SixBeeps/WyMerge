namespace WyMerge
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tDebug = new System.Windows.Forms.Label();
            this.bLoadImg2 = new System.Windows.Forms.Button();
            this.bLoadImg1 = new System.Windows.Forms.Button();
            this.iDisplay2 = new System.Windows.Forms.PictureBox();
            this.iDisplay1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tProgress = new System.Windows.Forms.Label();
            this.bGenerate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbColorBase = new System.Windows.Forms.ComboBox();
            this.tbThreshold = new System.Windows.Forms.TrackBar();
            this.tThreshold = new System.Windows.Forms.Label();
            this.tbFrames = new System.Windows.Forms.TrackBar();
            this.tFramesIndicator = new System.Windows.Forms.Label();
            this.lAbout = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iDisplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDisplay1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(13, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(234, 65);
            this.title.TabIndex = 0;
            this.title.Text = "WyMerge";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tDebug);
            this.groupBox1.Controls.Add(this.bLoadImg2);
            this.groupBox1.Controls.Add(this.bLoadImg1);
            this.groupBox1.Controls.Add(this.iDisplay2);
            this.groupBox1.Controls.Add(this.iDisplay1);
            this.groupBox1.Location = new System.Drawing.Point(24, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 357);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1 - Select Source Images";
            // 
            // tDebug
            // 
            this.tDebug.AutoSize = true;
            this.tDebug.Location = new System.Drawing.Point(16, 338);
            this.tDebug.Name = "tDebug";
            this.tDebug.Size = new System.Drawing.Size(0, 13);
            this.tDebug.TabIndex = 4;
            // 
            // bLoadImg2
            // 
            this.bLoadImg2.Location = new System.Drawing.Point(278, 284);
            this.bLoadImg2.Name = "bLoadImg2";
            this.bLoadImg2.Size = new System.Drawing.Size(128, 23);
            this.bLoadImg2.TabIndex = 3;
            this.bLoadImg2.Text = "Load Image 2...";
            this.bLoadImg2.UseVisualStyleBackColor = true;
            this.bLoadImg2.Click += new System.EventHandler(this.bLoadImg2_Click);
            // 
            // bLoadImg1
            // 
            this.bLoadImg1.Location = new System.Drawing.Point(16, 284);
            this.bLoadImg1.Name = "bLoadImg1";
            this.bLoadImg1.Size = new System.Drawing.Size(128, 23);
            this.bLoadImg1.TabIndex = 2;
            this.bLoadImg1.Text = "Load Image 1...";
            this.bLoadImg1.UseVisualStyleBackColor = true;
            this.bLoadImg1.Click += new System.EventHandler(this.bLoadImg1_Click);
            // 
            // iDisplay2
            // 
            this.iDisplay2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iDisplay2.Location = new System.Drawing.Point(278, 22);
            this.iDisplay2.Name = "iDisplay2";
            this.iDisplay2.Size = new System.Drawing.Size(256, 256);
            this.iDisplay2.TabIndex = 1;
            this.iDisplay2.TabStop = false;
            // 
            // iDisplay1
            // 
            this.iDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iDisplay1.Location = new System.Drawing.Point(16, 22);
            this.iDisplay1.Name = "iDisplay1";
            this.iDisplay1.Size = new System.Drawing.Size(256, 256);
            this.iDisplay1.TabIndex = 0;
            this.iDisplay1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tProgress);
            this.groupBox2.Controls.Add(this.bGenerate);
            this.groupBox2.Location = new System.Drawing.Point(580, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 145);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 3 - Generate WyMerge";
            // 
            // tProgress
            // 
            this.tProgress.AutoSize = true;
            this.tProgress.Location = new System.Drawing.Point(7, 82);
            this.tProgress.Name = "tProgress";
            this.tProgress.Size = new System.Drawing.Size(87, 13);
            this.tProgress.TabIndex = 2;
            this.tProgress.Text = "Not Generating";
            // 
            // bGenerate
            // 
            this.bGenerate.Location = new System.Drawing.Point(7, 22);
            this.bGenerate.Name = "bGenerate";
            this.bGenerate.Size = new System.Drawing.Size(187, 50);
            this.bGenerate.TabIndex = 0;
            this.bGenerate.Text = "Generate WyMerge!";
            this.bGenerate.UseVisualStyleBackColor = true;
            this.bGenerate.Click += new System.EventHandler(this.bGenerate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbColorBase);
            this.groupBox3.Controls.Add(this.tbThreshold);
            this.groupBox3.Controls.Add(this.tThreshold);
            this.groupBox3.Controls.Add(this.tbFrames);
            this.groupBox3.Controls.Add(this.tFramesIndicator);
            this.groupBox3.Location = new System.Drawing.Point(580, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 206);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 2 - Set Options";
            // 
            // cbColorBase
            // 
            this.cbColorBase.FormattingEnabled = true;
            this.cbColorBase.Items.AddRange(new object[] {
            "Based on Hue",
            "Based on Brightness"});
            this.cbColorBase.Location = new System.Drawing.Point(6, 159);
            this.cbColorBase.Name = "cbColorBase";
            this.cbColorBase.Size = new System.Drawing.Size(182, 21);
            this.cbColorBase.TabIndex = 4;
            this.cbColorBase.Text = "Based on Hue";
            // 
            // tbThreshold
            // 
            this.tbThreshold.Location = new System.Drawing.Point(10, 107);
            this.tbThreshold.Maximum = 255;
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(178, 45);
            this.tbThreshold.TabIndex = 3;
            this.tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbThreshold.Scroll += new System.EventHandler(this.tbThreshold_Scroll);
            // 
            // tThreshold
            // 
            this.tThreshold.AutoSize = true;
            this.tThreshold.Location = new System.Drawing.Point(10, 91);
            this.tThreshold.Name = "tThreshold";
            this.tThreshold.Size = new System.Drawing.Size(107, 13);
            this.tThreshold.TabIndex = 2;
            this.tThreshold.Text = "Color Threshold: 16";
            // 
            // tbFrames
            // 
            this.tbFrames.Location = new System.Drawing.Point(10, 39);
            this.tbFrames.Maximum = 100;
            this.tbFrames.Minimum = 2;
            this.tbFrames.Name = "tbFrames";
            this.tbFrames.Size = new System.Drawing.Size(178, 45);
            this.tbFrames.TabIndex = 1;
            this.tbFrames.TickFrequency = 2;
            this.tbFrames.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbFrames.Value = 2;
            this.tbFrames.Scroll += new System.EventHandler(this.tbFrames_Scroll);
            // 
            // tFramesIndicator
            // 
            this.tFramesIndicator.AutoSize = true;
            this.tFramesIndicator.Location = new System.Drawing.Point(7, 22);
            this.tFramesIndicator.Name = "tFramesIndicator";
            this.tFramesIndicator.Size = new System.Drawing.Size(55, 13);
            this.tFramesIndicator.TabIndex = 0;
            this.tFramesIndicator.Text = "Frames: 2";
            // 
            // lAbout
            // 
            this.lAbout.AutoSize = true;
            this.lAbout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lAbout.Location = new System.Drawing.Point(688, 9);
            this.lAbout.Name = "lAbout";
            this.lAbout.Size = new System.Drawing.Size(100, 13);
            this.lAbout.TabIndex = 5;
            this.lAbout.TabStop = true;
            this.lAbout.Text = "About WyMerge...";
            this.lAbout.VisitedLinkColor = System.Drawing.Color.Gray;
            this.lAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lAbout_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lAbout);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.title);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WyMerge";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iDisplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iDisplay1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFrames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox iDisplay1;
        private System.Windows.Forms.PictureBox iDisplay2;
        private System.Windows.Forms.Button bLoadImg2;
        private System.Windows.Forms.Button bLoadImg1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bGenerate;
        private System.Windows.Forms.Label tProgress;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label tFramesIndicator;
        private System.Windows.Forms.TrackBar tbFrames;
        private System.Windows.Forms.Label tThreshold;
        private System.Windows.Forms.TrackBar tbThreshold;
        private System.Windows.Forms.Label tDebug;
        private System.Windows.Forms.ComboBox cbColorBase;
        private System.Windows.Forms.LinkLabel lAbout;
    }
}

