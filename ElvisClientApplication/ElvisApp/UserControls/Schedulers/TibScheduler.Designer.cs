namespace Elvis.UserControls
{
    partial class TibScheduler
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
            this.components = new System.ComponentModel.Container();
            this.lblExternal = new System.Windows.Forms.Label();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.lblNoReason = new System.Windows.Forms.Label();
            this.lblCranes = new System.Windows.Forms.Label();
            this.lblCasters = new System.Windows.Forms.Label();
            this.lblSecSteel = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblVessels = new System.Windows.Forms.Label();
            this.lblHMScrap = new System.Windows.Forms.Label();
            this.lblMultiServ = new System.Windows.Forms.Label();
            this.ctxMenuHeat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxHeatDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuDelay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxDelayEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLegend.SuspendLayout();
            this.ctxMenuHeat.SuspendLayout();
            this.ctxMenuDelay.SuspendLayout();
            this.SuspendLayout();
            // 
            // scheduler
            // 
            this.scheduler.AppointmentBoxStyle = MLJSystems.Calendars.AppointmentBoxStyle.Individual;
            this.scheduler.Location = new System.Drawing.Point(0, 32);
            this.scheduler.Size = new System.Drawing.Size(1453, 574);
            this.scheduler.FirstDateTimeChanged += new System.EventHandler(this.scheduler_FirstDateTimeChanged);
            this.scheduler.AppointmentClick += new System.EventHandler<MLJSystems.Calendars.AppointmentClickEventArgs>(this.scheduler_AppointmentClick);
            this.scheduler.PaintAppointment += new MLJSystems.Calendars.PaintAppointmentEventHandler(this.scheduler_PaintAppointment);
            this.scheduler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.scheduler_MouseDoubleClick);
            this.scheduler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scheduler_MouseDown);
            this.scheduler.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scheduler_MouseMove);
            // 
            // lblExternal
            // 
            this.lblExternal.BackColor = System.Drawing.Color.Red;
            this.lblExternal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExternal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExternal.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternal.ForeColor = System.Drawing.Color.White;
            this.lblExternal.Location = new System.Drawing.Point(6, 6);
            this.lblExternal.Name = "lblExternal";
            this.lblExternal.Size = new System.Drawing.Size(130, 20);
            this.lblExternal.TabIndex = 6;
            this.lblExternal.Text = "EXTERNAL";
            this.lblExternal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLegend
            // 
            this.pnlLegend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(196)))), ((int)(((byte)(246)))));
            this.pnlLegend.Controls.Add(this.lblNoReason);
            this.pnlLegend.Controls.Add(this.lblCranes);
            this.pnlLegend.Controls.Add(this.lblCasters);
            this.pnlLegend.Controls.Add(this.lblSecSteel);
            this.pnlLegend.Controls.Add(this.lblPlan);
            this.pnlLegend.Controls.Add(this.lblVessels);
            this.pnlLegend.Controls.Add(this.lblHMScrap);
            this.pnlLegend.Controls.Add(this.lblMultiServ);
            this.pnlLegend.Controls.Add(this.lblExternal);
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLegend.Location = new System.Drawing.Point(0, 0);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Padding = new System.Windows.Forms.Padding(6);
            this.pnlLegend.Size = new System.Drawing.Size(1453, 32);
            this.pnlLegend.TabIndex = 7;
            // 
            // lblNoReason
            // 
            this.lblNoReason.BackColor = System.Drawing.Color.DarkGray;
            this.lblNoReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoReason.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNoReason.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoReason.ForeColor = System.Drawing.Color.Black;
            this.lblNoReason.Location = new System.Drawing.Point(1046, 6);
            this.lblNoReason.Name = "lblNoReason";
            this.lblNoReason.Size = new System.Drawing.Size(130, 20);
            this.lblNoReason.TabIndex = 14;
            this.lblNoReason.Text = "NO REASON";
            this.lblNoReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoReason.UseMnemonic = false;
            // 
            // lblCranes
            // 
            this.lblCranes.BackColor = System.Drawing.Color.Peru;
            this.lblCranes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCranes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCranes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCranes.ForeColor = System.Drawing.Color.Black;
            this.lblCranes.Location = new System.Drawing.Point(916, 6);
            this.lblCranes.Name = "lblCranes";
            this.lblCranes.Size = new System.Drawing.Size(130, 20);
            this.lblCranes.TabIndex = 13;
            this.lblCranes.Text = "CRANES";
            this.lblCranes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCranes.UseMnemonic = false;
            // 
            // lblCasters
            // 
            this.lblCasters.BackColor = System.Drawing.Color.SkyBlue;
            this.lblCasters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCasters.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCasters.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCasters.ForeColor = System.Drawing.Color.Black;
            this.lblCasters.Location = new System.Drawing.Point(786, 6);
            this.lblCasters.Name = "lblCasters";
            this.lblCasters.Size = new System.Drawing.Size(130, 20);
            this.lblCasters.TabIndex = 12;
            this.lblCasters.Text = "CASTERS";
            this.lblCasters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCasters.UseMnemonic = false;
            // 
            // lblSecSteel
            // 
            this.lblSecSteel.BackColor = System.Drawing.Color.YellowGreen;
            this.lblSecSteel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecSteel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSecSteel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecSteel.ForeColor = System.Drawing.Color.Black;
            this.lblSecSteel.Location = new System.Drawing.Point(656, 6);
            this.lblSecSteel.Name = "lblSecSteel";
            this.lblSecSteel.Size = new System.Drawing.Size(130, 20);
            this.lblSecSteel.TabIndex = 11;
            this.lblSecSteel.Text = "SEC-STEEL";
            this.lblSecSteel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSecSteel.UseMnemonic = false;
            // 
            // lblPlan
            // 
            this.lblPlan.BackColor = System.Drawing.Color.HotPink;
            this.lblPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlan.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPlan.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlan.ForeColor = System.Drawing.Color.Black;
            this.lblPlan.Location = new System.Drawing.Point(526, 6);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(130, 20);
            this.lblPlan.TabIndex = 10;
            this.lblPlan.Text = "PLAN";
            this.lblPlan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlan.UseMnemonic = false;
            // 
            // lblVessels
            // 
            this.lblVessels.BackColor = System.Drawing.Color.SeaGreen;
            this.lblVessels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVessels.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVessels.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVessels.ForeColor = System.Drawing.Color.White;
            this.lblVessels.Location = new System.Drawing.Point(396, 6);
            this.lblVessels.Name = "lblVessels";
            this.lblVessels.Size = new System.Drawing.Size(130, 20);
            this.lblVessels.TabIndex = 9;
            this.lblVessels.Text = "VESSELS";
            this.lblVessels.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVessels.UseMnemonic = false;
            // 
            // lblHMScrap
            // 
            this.lblHMScrap.BackColor = System.Drawing.Color.Gold;
            this.lblHMScrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHMScrap.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHMScrap.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHMScrap.ForeColor = System.Drawing.Color.Black;
            this.lblHMScrap.Location = new System.Drawing.Point(266, 6);
            this.lblHMScrap.Name = "lblHMScrap";
            this.lblHMScrap.Size = new System.Drawing.Size(130, 20);
            this.lblHMScrap.TabIndex = 8;
            this.lblHMScrap.Text = "HM & SCRAP";
            this.lblHMScrap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHMScrap.UseMnemonic = false;
            // 
            // lblMultiServ
            // 
            this.lblMultiServ.BackColor = System.Drawing.Color.BlueViolet;
            this.lblMultiServ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMultiServ.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMultiServ.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultiServ.ForeColor = System.Drawing.Color.White;
            this.lblMultiServ.Location = new System.Drawing.Point(136, 6);
            this.lblMultiServ.Name = "lblMultiServ";
            this.lblMultiServ.Size = new System.Drawing.Size(130, 20);
            this.lblMultiServ.TabIndex = 7;
            this.lblMultiServ.Text = "MULTISERV";
            this.lblMultiServ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctxMenuHeat
            // 
            this.ctxMenuHeat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxHeatDetails});
            this.ctxMenuHeat.Name = "ctxMenuHeat";
            this.ctxMenuHeat.Size = new System.Drawing.Size(155, 26);
            // 
            // ctxHeatDetails
            // 
            this.ctxHeatDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxHeatDetails.Name = "ctxHeatDetails";
            this.ctxHeatDetails.Size = new System.Drawing.Size(154, 22);
            this.ctxHeatDetails.Text = "Heat Details";
            this.ctxHeatDetails.Click += new System.EventHandler(this.ctxHeatDetails_Click);
            // 
            // ctxMenuDelay
            // 
            this.ctxMenuDelay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxDelayEntry});
            this.ctxMenuDelay.Name = "ctxMenuHeat";
            this.ctxMenuDelay.Size = new System.Drawing.Size(153, 48);
            // 
            // ctxDelayEntry
            // 
            this.ctxDelayEntry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctxDelayEntry.Name = "ctxDelayEntry";
            this.ctxDelayEntry.Size = new System.Drawing.Size(152, 22);
            this.ctxDelayEntry.Text = "Delay Entry";
            this.ctxDelayEntry.Click += new System.EventHandler(this.ctxDelayEntry_Click);
            // 
            // TibScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLegend);
            this.Name = "TibScheduler";
            this.Size = new System.Drawing.Size(1453, 606);
            this.Resize += new System.EventHandler(this.TibScheduler_Resize);
            this.Controls.SetChildIndex(this.pnlLegend, 0);
            this.Controls.SetChildIndex(this.scheduler, 0);
            this.pnlLegend.ResumeLayout(false);
            this.ctxMenuHeat.ResumeLayout(false);
            this.ctxMenuDelay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblExternal;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label lblMultiServ;
        private System.Windows.Forms.Label lblHMScrap;
        private System.Windows.Forms.Label lblVessels;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblSecSteel;
        private System.Windows.Forms.Label lblCasters;
        private System.Windows.Forms.Label lblCranes;
        private System.Windows.Forms.Label lblNoReason;
        private System.Windows.Forms.ContextMenuStrip ctxMenuHeat;
        private System.Windows.Forms.ToolStripMenuItem ctxHeatDetails;
        private System.Windows.Forms.ContextMenuStrip ctxMenuDelay;
        private System.Windows.Forms.ToolStripMenuItem ctxDelayEntry;

    }
}
