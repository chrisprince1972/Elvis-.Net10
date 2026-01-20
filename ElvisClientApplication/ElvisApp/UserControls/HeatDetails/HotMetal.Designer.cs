using Elvis.UserControls.HeatDetails.HotMetalUCs;
namespace Elvis.UserControls.HeatDetails
{
    partial class HotMetal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTopHalf = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.grpHotMetalDetails = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlTopLeft = new System.Windows.Forms.Panel();
            this.grpInjection = new System.Windows.Forms.GroupBox();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.grpTreatmentDetails = new System.Windows.Forms.GroupBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlBottomHalf = new System.Windows.Forms.Panel();
            this.grpHMDesModel = new System.Windows.Forms.GroupBox();
            this.ucSkimQuality = new Elvis.UserControls.HeatDetails.HotMetalUCs.SkimQuality();
            this.ucHotMetalMakeUp = new Elvis.UserControls.HeatDetails.HotMetalUCs.HotMetalMakeUp();
            this.ucInjectionDetails = new Elvis.UserControls.HeatDetails.HotMetalUCs.InjectionDetails();
            this.ucHeatLogDisplay = new Elvis.UserControls.HeatDetails.HotMetalUCs.HeatLogDisplay();
            this.ucKeyDetails = new Elvis.UserControls.HeatDetails.HotMetalUCs.KeyDetails();
            this.ucDesulphModel = new Elvis.UserControls.HeatDetails.HotMetalUCs.DesulphModel();
            this.pnlMain.SuspendLayout();
            this.pnlTopHalf.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.grpHotMetalDetails.SuspendLayout();
            this.pnlTopLeft.SuspendLayout();
            this.grpInjection.SuspendLayout();
            this.grpTreatmentDetails.SuspendLayout();
            this.pnlBottomHalf.SuspendLayout();
            this.grpHMDesModel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMain.Controls.Add(this.pnlTopHalf);
            this.pnlMain.Controls.Add(this.splitter2);
            this.pnlMain.Controls.Add(this.pnlBottomHalf);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(1206, 651);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlTopHalf
            // 
            this.pnlTopHalf.Controls.Add(this.pnlTopRight);
            this.pnlTopHalf.Controls.Add(this.splitter1);
            this.pnlTopHalf.Controls.Add(this.pnlTopLeft);
            this.pnlTopHalf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopHalf.Location = new System.Drawing.Point(6, 6);
            this.pnlTopHalf.Name = "pnlTopHalf";
            this.pnlTopHalf.Size = new System.Drawing.Size(1194, 538);
            this.pnlTopHalf.TabIndex = 5;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.ucSkimQuality);
            this.pnlTopRight.Controls.Add(this.splitter5);
            this.pnlTopRight.Controls.Add(this.grpHotMetalDetails);
            this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopRight.Location = new System.Drawing.Point(435, 0);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(759, 538);
            this.pnlTopRight.TabIndex = 10;
            // 
            // splitter5
            // 
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter5.Location = new System.Drawing.Point(0, 224);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(759, 5);
            this.splitter5.TabIndex = 10;
            this.splitter5.TabStop = false;
            // 
            // grpHotMetalDetails
            // 
            this.grpHotMetalDetails.BackColor = System.Drawing.SystemColors.Control;
            this.grpHotMetalDetails.Controls.Add(this.ucHotMetalMakeUp);
            this.grpHotMetalDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHotMetalDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHotMetalDetails.Location = new System.Drawing.Point(0, 0);
            this.grpHotMetalDetails.Name = "grpHotMetalDetails";
            this.grpHotMetalDetails.Padding = new System.Windows.Forms.Padding(6);
            this.grpHotMetalDetails.Size = new System.Drawing.Size(759, 224);
            this.grpHotMetalDetails.TabIndex = 7;
            this.grpHotMetalDetails.TabStop = false;
            this.grpHotMetalDetails.Text = "Hot Metal Details";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(430, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 538);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.grpInjection);
            this.pnlTopLeft.Controls.Add(this.splitter4);
            this.pnlTopLeft.Controls.Add(this.grpTreatmentDetails);
            this.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(430, 538);
            this.pnlTopLeft.TabIndex = 5;
            // 
            // grpInjection
            // 
            this.grpInjection.Controls.Add(this.ucInjectionDetails);
            this.grpInjection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInjection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInjection.Location = new System.Drawing.Point(0, 460);
            this.grpInjection.Name = "grpInjection";
            this.grpInjection.Padding = new System.Windows.Forms.Padding(6);
            this.grpInjection.Size = new System.Drawing.Size(430, 78);
            this.grpInjection.TabIndex = 1;
            this.grpInjection.TabStop = false;
            this.grpInjection.Text = "Injection";
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(0, 455);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(430, 5);
            this.splitter4.TabIndex = 8;
            this.splitter4.TabStop = false;
            // 
            // grpTreatmentDetails
            // 
            this.grpTreatmentDetails.BackColor = System.Drawing.SystemColors.Control;
            this.grpTreatmentDetails.Controls.Add(this.ucHeatLogDisplay);
            this.grpTreatmentDetails.Controls.Add(this.splitter3);
            this.grpTreatmentDetails.Controls.Add(this.ucKeyDetails);
            this.grpTreatmentDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTreatmentDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTreatmentDetails.Location = new System.Drawing.Point(0, 0);
            this.grpTreatmentDetails.Name = "grpTreatmentDetails";
            this.grpTreatmentDetails.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.grpTreatmentDetails.Size = new System.Drawing.Size(430, 455);
            this.grpTreatmentDetails.TabIndex = 2;
            this.grpTreatmentDetails.TabStop = false;
            this.grpTreatmentDetails.Text = "Treatment Details";
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(6, 89);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(418, 5);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(6, 544);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1194, 5);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // pnlBottomHalf
            // 
            this.pnlBottomHalf.Controls.Add(this.grpHMDesModel);
            this.pnlBottomHalf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomHalf.Location = new System.Drawing.Point(6, 549);
            this.pnlBottomHalf.Name = "pnlBottomHalf";
            this.pnlBottomHalf.Size = new System.Drawing.Size(1194, 96);
            this.pnlBottomHalf.TabIndex = 6;
            // 
            // grpHMDesModel
            // 
            this.grpHMDesModel.Controls.Add(this.ucDesulphModel);
            this.grpHMDesModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHMDesModel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHMDesModel.Location = new System.Drawing.Point(0, 0);
            this.grpHMDesModel.Name = "grpHMDesModel";
            this.grpHMDesModel.Padding = new System.Windows.Forms.Padding(6);
            this.grpHMDesModel.Size = new System.Drawing.Size(1194, 96);
            this.grpHMDesModel.TabIndex = 0;
            this.grpHMDesModel.TabStop = false;
            this.grpHMDesModel.Text = "HM De-S Model";
            // 
            // ucSkimQuality
            // 
            this.ucSkimQuality.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucSkimQuality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSkimQuality.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSkimQuality.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucSkimQuality.Location = new System.Drawing.Point(0, 229);
            this.ucSkimQuality.Name = "ucSkimQuality";
            this.ucSkimQuality.Size = new System.Drawing.Size(759, 309);
            this.ucSkimQuality.TabIndex = 9;
            // 
            // ucHotMetalMakeUp
            // 
            this.ucHotMetalMakeUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucHotMetalMakeUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHotMetalMakeUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucHotMetalMakeUp.Location = new System.Drawing.Point(6, 20);
            this.ucHotMetalMakeUp.Name = "ucHotMetalMakeUp";
            this.ucHotMetalMakeUp.Size = new System.Drawing.Size(747, 198);
            this.ucHotMetalMakeUp.TabIndex = 4;
            // 
            // ucInjectionDetails
            // 
            this.ucInjectionDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucInjectionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucInjectionDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucInjectionDetails.Location = new System.Drawing.Point(6, 20);
            this.ucInjectionDetails.Name = "ucInjectionDetails";
            this.ucInjectionDetails.Size = new System.Drawing.Size(418, 52);
            this.ucInjectionDetails.TabIndex = 0;
            // 
            // ucHeatLogDisplay
            // 
            this.ucHeatLogDisplay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucHeatLogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHeatLogDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucHeatLogDisplay.Location = new System.Drawing.Point(6, 94);
            this.ucHeatLogDisplay.Name = "ucHeatLogDisplay";
            this.ucHeatLogDisplay.Size = new System.Drawing.Size(418, 355);
            this.ucHeatLogDisplay.TabIndex = 3;
            // 
            // ucKeyDetails
            // 
            this.ucKeyDetails.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucKeyDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucKeyDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucKeyDetails.Location = new System.Drawing.Point(6, 14);
            this.ucKeyDetails.Name = "ucKeyDetails";
            this.ucKeyDetails.Size = new System.Drawing.Size(418, 75);
            this.ucKeyDetails.TabIndex = 2;
            // 
            // ucDesulphModel
            // 
            this.ucDesulphModel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucDesulphModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDesulphModel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucDesulphModel.Location = new System.Drawing.Point(6, 20);
            this.ucDesulphModel.Name = "ucDesulphModel";
            this.ucDesulphModel.Size = new System.Drawing.Size(1182, 70);
            this.ucDesulphModel.TabIndex = 0;
            // 
            // HotMetal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "HotMetal";
            this.Size = new System.Drawing.Size(1206, 651);
            this.pnlMain.ResumeLayout(false);
            this.pnlTopHalf.ResumeLayout(false);
            this.pnlTopRight.ResumeLayout(false);
            this.grpHotMetalDetails.ResumeLayout(false);
            this.pnlTopLeft.ResumeLayout(false);
            this.grpInjection.ResumeLayout(false);
            this.grpTreatmentDetails.ResumeLayout(false);
            this.pnlBottomHalf.ResumeLayout(false);
            this.grpHMDesModel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTopHalf;
        private System.Windows.Forms.GroupBox grpTreatmentDetails;
        private System.Windows.Forms.Panel pnlBottomHalf;
        private System.Windows.Forms.GroupBox grpHMDesModel;
        private System.Windows.Forms.GroupBox grpInjection;
        private System.Windows.Forms.GroupBox grpHotMetalDetails;
        private HotMetalMakeUp ucHotMetalMakeUp;
        private DesulphModel ucDesulphModel;
        private InjectionDetails ucInjectionDetails;
        private KeyDetails ucKeyDetails;
        private HeatLogDisplay ucHeatLogDisplay;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlTopRight;
        private SkimQuality ucSkimQuality;
        private System.Windows.Forms.Panel pnlTopLeft;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Splitter splitter5;

    }
}
