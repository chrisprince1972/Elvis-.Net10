//namespace Elvis.Forms
//{
//    partial class SplashScreen
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
//            this.pictureBox1 = new System.Windows.Forms.PictureBox();
//            this.pictureBox2 = new System.Windows.Forms.PictureBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.lblVersion = new System.Windows.Forms.Label();
//            this.progressBar1 = new System.Windows.Forms.ProgressBar();
//            this.lblCopyright = new System.Windows.Forms.Label();
//            this.btnSkip = new System.Windows.Forms.Button();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.panel2 = new System.Windows.Forms.Panel();
//            //TODO: conversion issue: Microsoft.VisualBasic.PowerPacks is not available in .NET 10.0 and later versions.
//            //either bin off completely or Replace with standard WinForms controls
//            //this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
//            //this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
//            //this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
//            this.panel1.SuspendLayout();
//            this.panel2.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // pictureBox1
//            // 
//            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
//            resources.ApplyResources(this.pictureBox1, "pictureBox1");
//            this.pictureBox1.Name = "pictureBox1";
//            this.pictureBox1.TabStop = false;
//            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // pictureBox2
//            // 
//            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
//            resources.ApplyResources(this.pictureBox2, "pictureBox2");
//            this.pictureBox2.Name = "pictureBox2";
//            this.pictureBox2.TabStop = false;
//            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // label1
//            // 
//            resources.ApplyResources(this.label1, "label1");
//            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
//            this.label1.ForeColor = System.Drawing.Color.White;
//            this.label1.Name = "label1";
//            this.label1.UseMnemonic = false;
//            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // label2
//            // 
//            resources.ApplyResources(this.label2, "label2");
//            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
//            this.label2.ForeColor = System.Drawing.Color.White;
//            this.label2.Name = "label2";
//            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // lblVersion
//            // 
//            resources.ApplyResources(this.lblVersion, "lblVersion");
//            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
//            this.lblVersion.ForeColor = System.Drawing.Color.White;
//            this.lblVersion.Name = "lblVersion";
//            this.lblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // progressBar1
//            // 
//            this.progressBar1.BackColor = System.Drawing.Color.White;
//            resources.ApplyResources(this.progressBar1, "progressBar1");
//            this.progressBar1.Name = "progressBar1";
//            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
//            this.progressBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // lblCopyright
//            // 
//            resources.ApplyResources(this.lblCopyright, "lblCopyright");
//            this.lblCopyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
//            this.lblCopyright.ForeColor = System.Drawing.Color.White;
//            this.lblCopyright.Name = "lblCopyright";
//            this.lblCopyright.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // btnSkip
//            // 
//            resources.ApplyResources(this.btnSkip, "btnSkip");
//            this.btnSkip.Name = "btnSkip";
//            this.btnSkip.UseVisualStyleBackColor = true;
//            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
//            // 
//            // panel1
//            // 
//            this.panel1.BackColor = System.Drawing.Color.LightGray;
//            this.panel1.Controls.Add(this.panel2);
//            resources.ApplyResources(this.panel1, "panel1");
//            this.panel1.Name = "panel1";
//            // 
//            // panel2
//            // 
//            this.panel2.BackColor = System.Drawing.Color.LightGray;
//            this.panel2.Controls.Add(this.pictureBox1);
//            this.panel2.Controls.Add(this.lblCopyright);
//            this.panel2.Controls.Add(this.btnSkip);
//            this.panel2.Controls.Add(this.label2);
//            this.panel2.Controls.Add(this.lblVersion);
//            this.panel2.Controls.Add(this.label1);
//            this.panel2.Controls.Add(this.pictureBox2);
//            this.panel2.Controls.Add(this.progressBar1);
//            //TODO: fix conversion issue: Microsoft.VisualBasic.PowerPacks is not available in .NET 10.0 and later versions.
//            //this.panel2.Controls.Add(this.shapeContainer1);
//            resources.ApplyResources(this.panel2, "panel2");
//            this.panel2.Name = "panel2";
//            // 
//            // shapeContainer1
//            // 
//            //TODO: fix conversion issue: Microsoft.VisualBasic.PowerPacks is not available in .NET 10.0 and later versions.
//            //
//            //resources.ApplyResources(this.shapeContainer1, "shapeContainer1");
//            //this.shapeContainer1.Name = "shapeContainer1";
//            //this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
//            //this.rectangleShape1,
//            //this.rectangleShape3});
//            //this.shapeContainer1.TabStop = false;
//            // 
//            // rec
//            //TODO: fix conversion issue: Microsoft.VisualBasic.PowerPacks is not available in .NET 10.0 and later versions.
//            //
//            //resources.ApplyResources(this.rectangleShape1, "rectangleShape1");
//            //this.rectangleShape1.Name = "rectangleShape1";
//            //this.rectangleShape1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // rectangleShape3
//            // 
//            //TODO: fix conversion issue: Microsoft.VisualBasic.PowerPacks is not available in .NET 10.0 and later versions.
//            //
//            //resources.ApplyResources(this.rectangleShape3, "rectangleShape3");
//            //this.rectangleShape3.Name = "rectangleShape3";
//            //this.rectangleShape3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            // 
//            // SplashScreen
//            // 
//            resources.ApplyResources(this, "$this");
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
//            this.ControlBox = false;
//            this.Controls.Add(this.panel1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.Name = "SplashScreen";
//            this.ShowIcon = false;
//            this.TransparencyKey = System.Drawing.Color.LightGray;
//            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseDown);
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
//            this.panel1.ResumeLayout(false);
//            this.panel2.ResumeLayout(false);
//            this.panel2.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.PictureBox pictureBox1;
//        private System.Windows.Forms.PictureBox pictureBox2;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label lblVersion;
//        private System.Windows.Forms.ProgressBar progressBar1;
//        private System.Windows.Forms.Label lblCopyright;
//        private System.Windows.Forms.Button btnSkip;
//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Panel panel2;
//        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
//        //private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
//        //private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
//    }
//}