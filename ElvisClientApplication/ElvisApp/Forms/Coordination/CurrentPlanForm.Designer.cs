namespace Elvis.Forms.Coordination
{
    partial class CurrentPlanForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentPlanForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblScheduleUpdate = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.Heat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vessel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ladle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredPour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDesulph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OGStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AimTap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualTap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CastTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CastTMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpeedMM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartCast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndCast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DwellTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotConnectFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(938, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AllowUserToResizeRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Heat,
            this.ProgramNumber,
            this.Grade1,
            this.Grade2,
            this.Vessel,
            this.Ladle,
            this.RequiredPour,
            this.EndDesulph,
            this.OGStart,
            this.AimTap,
            this.ActualTap,
            this.SSUnit,
            this.EndSS,
            this.Caster,
            this.Width,
            this.CastTime,
            this.CastTMin,
            this.SpeedMM,
            this.StartCast,
            this.EndCast,
            this.DwellTime,
            this.HotConnectFlag,
            this.Comments});
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.Location = new System.Drawing.Point(0, 24);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersVisible = false;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvSchedule.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvSchedule.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1016, 680);
            this.dgvSchedule.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblScheduleUpdate);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 704);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.pnlFooter.Size = new System.Drawing.Size(1016, 30);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblScheduleUpdate
            // 
            this.lblScheduleUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduleUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduleUpdate.Location = new System.Drawing.Point(6, 3);
            this.lblScheduleUpdate.Name = "lblScheduleUpdate";
            this.lblScheduleUpdate.Size = new System.Drawing.Size(932, 24);
            this.lblScheduleUpdate.TabIndex = 1;
            this.lblScheduleUpdate.Text = "Plan Last Updated - ";
            this.lblScheduleUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrint,
            this.menuPrintPreview,
            this.toolStripSeparator1,
            this.menuClose});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuPrint
            // 
            this.menuPrint.Image = ((System.Drawing.Image)(resources.GetObject("menuPrint.Image")));
            this.menuPrint.Name = "menuPrint";
            this.menuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuPrint.Size = new System.Drawing.Size(157, 22);
            this.menuPrint.Text = "&Print...";
            this.menuPrint.Click += new System.EventHandler(this.menuPrint_Click);
            // 
            // menuPrintPreview
            // 
            this.menuPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("menuPrintPreview.Image")));
            this.menuPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuPrintPreview.Name = "menuPrintPreview";
            this.menuPrintPreview.Size = new System.Drawing.Size(157, 22);
            this.menuPrintPreview.Text = "Print Pre&view";
            this.menuPrintPreview.Click += new System.EventHandler(this.menuPrintPreview_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // menuClose
            // 
            this.menuClose.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(157, 22);
            this.menuClose.Text = "&Close";
            this.menuClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "BOS Plant - Current Schedule Screenshot";
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Heat
            // 
            this.Heat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Heat.DataPropertyName = "HEAT_NUMBER";
            this.Heat.HeaderText = "Heat";
            this.Heat.Name = "Heat";
            this.Heat.ReadOnly = true;
            this.Heat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Heat.Width = 36;
            // 
            // ProgramNumber
            // 
            this.ProgramNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ProgramNumber.DataPropertyName = "PROGRAM_NUMBER";
            this.ProgramNumber.HeaderText = "Prog.";
            this.ProgramNumber.Name = "ProgramNumber";
            this.ProgramNumber.ReadOnly = true;
            this.ProgramNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProgramNumber.Width = 38;
            // 
            // Grade1
            // 
            this.Grade1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Grade1.DataPropertyName = "GRADE_1";
            this.Grade1.HeaderText = "Grade 1";
            this.Grade1.MinimumWidth = 40;
            this.Grade1.Name = "Grade1";
            this.Grade1.ReadOnly = true;
            this.Grade1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Grade1.Width = 40;
            // 
            // Grade2
            // 
            this.Grade2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Grade2.DataPropertyName = "GRADE_2";
            this.Grade2.HeaderText = "Grade 2";
            this.Grade2.MinimumWidth = 40;
            this.Grade2.Name = "Grade2";
            this.Grade2.ReadOnly = true;
            this.Grade2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Grade2.Width = 40;
            // 
            // Vessel
            // 
            this.Vessel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vessel.DataPropertyName = "VESSEL_NUMBER";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Vessel.DefaultCellStyle = dataGridViewCellStyle2;
            this.Vessel.FillWeight = 50F;
            this.Vessel.HeaderText = "Vsl";
            this.Vessel.Name = "Vessel";
            this.Vessel.ReadOnly = true;
            this.Vessel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Vessel.Width = 27;
            // 
            // Ladle
            // 
            this.Ladle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ladle.DataPropertyName = "STEEL_LADLE_NUMBER";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Ladle.DefaultCellStyle = dataGridViewCellStyle3;
            this.Ladle.FillWeight = 75F;
            this.Ladle.HeaderText = "Ladle";
            this.Ladle.Name = "Ladle";
            this.Ladle.ReadOnly = true;
            this.Ladle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ladle.Width = 39;
            // 
            // RequiredPour
            // 
            this.RequiredPour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.RequiredPour.DataPropertyName = "PLANNED_POUR_TIME";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "t";
            this.RequiredPour.DefaultCellStyle = dataGridViewCellStyle4;
            this.RequiredPour.HeaderText = "Req. Pour";
            this.RequiredPour.MinimumWidth = 40;
            this.RequiredPour.Name = "RequiredPour";
            this.RequiredPour.ReadOnly = true;
            this.RequiredPour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RequiredPour.Width = 40;
            // 
            // EndDesulph
            // 
            this.EndDesulph.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.EndDesulph.DataPropertyName = "PLANNED_END_DESULPH_TIME";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Format = "t";
            dataGridViewCellStyle5.NullValue = null;
            this.EndDesulph.DefaultCellStyle = dataGridViewCellStyle5;
            this.EndDesulph.HeaderText = "End DeS";
            this.EndDesulph.MinimumWidth = 40;
            this.EndDesulph.Name = "EndDesulph";
            this.EndDesulph.ReadOnly = true;
            this.EndDesulph.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndDesulph.Width = 40;
            // 
            // OGStart
            // 
            this.OGStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.OGStart.DataPropertyName = "PLANNED_CHARGE_TIME";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Format = "t";
            this.OGStart.DefaultCellStyle = dataGridViewCellStyle6;
            this.OGStart.HeaderText = "OG Start";
            this.OGStart.MinimumWidth = 40;
            this.OGStart.Name = "OGStart";
            this.OGStart.ReadOnly = true;
            this.OGStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OGStart.Width = 40;
            // 
            // AimTap
            // 
            this.AimTap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.AimTap.DataPropertyName = "PLANNED_TAP_TIME";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Format = "t";
            this.AimTap.DefaultCellStyle = dataGridViewCellStyle7;
            this.AimTap.HeaderText = "Aim Tap";
            this.AimTap.MinimumWidth = 35;
            this.AimTap.Name = "AimTap";
            this.AimTap.ReadOnly = true;
            this.AimTap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AimTap.Width = 35;
            // 
            // ActualTap
            // 
            this.ActualTap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.ActualTap.DataPropertyName = "ACTUAL_TAP_TIME";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.Format = "t";
            this.ActualTap.DefaultCellStyle = dataGridViewCellStyle8;
            this.ActualTap.HeaderText = "Act Tap";
            this.ActualTap.MinimumWidth = 35;
            this.ActualTap.Name = "ActualTap";
            this.ActualTap.ReadOnly = true;
            this.ActualTap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ActualTap.Width = 35;
            // 
            // SSUnit
            // 
            this.SSUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.SSUnit.DataPropertyName = "SS_UNIT";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SSUnit.DefaultCellStyle = dataGridViewCellStyle9;
            this.SSUnit.HeaderText = "SS Unit";
            this.SSUnit.MinimumWidth = 35;
            this.SSUnit.Name = "SSUnit";
            this.SSUnit.ReadOnly = true;
            this.SSUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SSUnit.Width = 35;
            // 
            // EndSS
            // 
            this.EndSS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.EndSS.DataPropertyName = "PLANNED_END_SS_TIME";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Format = "t";
            this.EndSS.DefaultCellStyle = dataGridViewCellStyle10;
            this.EndSS.HeaderText = "End SS";
            this.EndSS.MinimumWidth = 35;
            this.EndSS.Name = "EndSS";
            this.EndSS.ReadOnly = true;
            this.EndSS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndSS.Width = 35;
            // 
            // Caster
            // 
            this.Caster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Caster.DataPropertyName = "CASTER_NUMBER";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Caster.DefaultCellStyle = dataGridViewCellStyle11;
            this.Caster.HeaderText = "Caster";
            this.Caster.Name = "Caster";
            this.Caster.ReadOnly = true;
            this.Caster.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Caster.Width = 43;
            // 
            // Width
            // 
            this.Width.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Width.DataPropertyName = "COMBINED_WIDTH";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Width.DefaultCellStyle = dataGridViewCellStyle12;
            this.Width.HeaderText = "Width";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            this.Width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Width.Width = 41;
            // 
            // CastTime
            // 
            this.CastTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.CastTime.DataPropertyName = "CAST_DURATION";
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CastTime.DefaultCellStyle = dataGridViewCellStyle13;
            this.CastTime.HeaderText = "Cast Time";
            this.CastTime.MinimumWidth = 40;
            this.CastTime.Name = "CastTime";
            this.CastTime.ReadOnly = true;
            this.CastTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CastTime.Width = 40;
            // 
            // CastTMin
            // 
            this.CastTMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.CastTMin.DataPropertyName = "CASTING_RATE";
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.CastTMin.DefaultCellStyle = dataGridViewCellStyle14;
            this.CastTMin.HeaderText = "Cast T/Min";
            this.CastTMin.MinimumWidth = 40;
            this.CastTMin.Name = "CastTMin";
            this.CastTMin.ReadOnly = true;
            this.CastTMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CastTMin.Width = 40;
            // 
            // SpeedMM
            // 
            this.SpeedMM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.SpeedMM.DataPropertyName = "CASTING_SPEED";
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.SpeedMM.DefaultCellStyle = dataGridViewCellStyle15;
            this.SpeedMM.HeaderText = "Speed M/Min";
            this.SpeedMM.MinimumWidth = 45;
            this.SpeedMM.Name = "SpeedMM";
            this.SpeedMM.ReadOnly = true;
            this.SpeedMM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SpeedMM.Width = 45;
            // 
            // StartCast
            // 
            this.StartCast.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.StartCast.DataPropertyName = "PLANNED_START_CAST_TIME";
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.Format = "t";
            this.StartCast.DefaultCellStyle = dataGridViewCellStyle16;
            this.StartCast.HeaderText = "Start Cast";
            this.StartCast.MinimumWidth = 40;
            this.StartCast.Name = "StartCast";
            this.StartCast.ReadOnly = true;
            this.StartCast.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartCast.Width = 40;
            // 
            // EndCast
            // 
            this.EndCast.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.EndCast.DataPropertyName = "PLANNED_END_CAST_TIME";
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Format = "t";
            this.EndCast.DefaultCellStyle = dataGridViewCellStyle17;
            this.EndCast.HeaderText = "End Cast";
            this.EndCast.MinimumWidth = 40;
            this.EndCast.Name = "EndCast";
            this.EndCast.ReadOnly = true;
            this.EndCast.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndCast.Width = 40;
            // 
            // DwellTime
            // 
            this.DwellTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.DwellTime.DataPropertyName = "PLANNED_DWELL_TIME";
            this.DwellTime.HeaderText = "Dwell Time";
            this.DwellTime.MinimumWidth = 40;
            this.DwellTime.Name = "DwellTime";
            this.DwellTime.ReadOnly = true;
            this.DwellTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DwellTime.Width = 40;
            // 
            // HotConnectFlag
            // 
            this.HotConnectFlag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.HotConnectFlag.DataPropertyName = "HotConnectFlag";
            this.HotConnectFlag.HeaderText = "HC";
            this.HotConnectFlag.MinimumWidth = 24;
            this.HotConnectFlag.Name = "HotConnectFlag";
            this.HotConnectFlag.ReadOnly = true;
            this.HotConnectFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HotConnectFlag.Width = 24;
            // 
            // Comments
            // 
            this.Comments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comments.DataPropertyName = "COMMENTS";
            this.Comments.FillWeight = 200F;
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            this.Comments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CurrentPlanForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "CurrentPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOS Plant - Current Schedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CurrentPlanForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblScheduleUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlabWidth;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuPrint;
        private System.Windows.Forms.ToolStripMenuItem menuPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Heat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgramNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vessel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ladle;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredPour;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDesulph;
        private System.Windows.Forms.DataGridViewTextBoxColumn OGStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn AimTap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualTap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndSS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caster;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn CastTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CastTMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeedMM;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartCast;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndCast;
        private System.Windows.Forms.DataGridViewTextBoxColumn DwellTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HotConnectFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
    }
}