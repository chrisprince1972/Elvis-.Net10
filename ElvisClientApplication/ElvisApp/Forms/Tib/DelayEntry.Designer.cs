namespace Elvis.Forms.Tib
{
    partial class DelayEntry
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelayEntry));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewDelayToolStripMenuItemNewDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.pnlTableLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeatNo = new System.Windows.Forms.TextBox();
            this.txtProgramNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.lstTotals = new System.Windows.Forms.ListView();
            this.RequiredMins = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DelayMins = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MinsRemaining = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelArea = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelHeatNo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlDelayEntryEventDetails = new System.Windows.Forms.Panel();
            this.grpTreatmentDetail = new System.Windows.Forms.GroupBox();
            this.treatmentDetailsPanel = new System.Windows.Forms.Panel();
            this.tibDelayEntryEvent = new Elvis.UserControls.Tib.TibDelayEntryEvent();
            this.pnlDelays = new System.Windows.Forms.Panel();
            this.grpDelays = new System.Windows.Forms.GroupBox();
            this.delayDetailGrid = new Elvis.UserControls.Tib.DelayDetailGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnDeleteDelay = new System.Windows.Forms.Button();
            this.btnAddDelay = new System.Windows.Forms.Button();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.pnlBoxDisplay = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            this.grpEvent.SuspendLayout();
            this.pnlTableLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpTotals.SuspendLayout();
            this.pnlEvent.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlDelayEntryEventDetails.SuspendLayout();
            this.grpTreatmentDetail.SuspendLayout();
            this.treatmentDetailsPanel.SuspendLayout();
            this.pnlDelays.SuspendLayout();
            this.grpDelays.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.delaysToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1092, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // delaysToolStripMenuItem
            // 
            this.delaysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewDelayToolStripMenuItemNewDelay,
            this.menuDeleteDelay});
            this.delaysToolStripMenuItem.Name = "delaysToolStripMenuItem";
            this.delaysToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.delaysToolStripMenuItem.Text = "&Delays";
            // 
            // addNewDelayToolStripMenuItemNewDelay
            // 
            this.addNewDelayToolStripMenuItemNewDelay.Image = ((System.Drawing.Image)(resources.GetObject("addNewDelayToolStripMenuItemNewDelay.Image")));
            this.addNewDelayToolStripMenuItemNewDelay.Name = "addNewDelayToolStripMenuItemNewDelay";
            this.addNewDelayToolStripMenuItemNewDelay.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.addNewDelayToolStripMenuItemNewDelay.Size = new System.Drawing.Size(238, 22);
            this.addNewDelayToolStripMenuItemNewDelay.Text = "Add &New Delay...";
            this.addNewDelayToolStripMenuItemNewDelay.Click += new System.EventHandler(this.addNewDelayToolStripMenuItemNewDelay_Click);
            // 
            // menuDeleteDelay
            // 
            this.menuDeleteDelay.Enabled = false;
            this.menuDeleteDelay.Image = global::Elvis.Properties.Resources.delete_12x12;
            this.menuDeleteDelay.Name = "menuDeleteDelay";
            this.menuDeleteDelay.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.menuDeleteDelay.Size = new System.Drawing.Size(238, 22);
            this.menuDeleteDelay.Text = "&Delete Selected Delay";
            this.menuDeleteDelay.Click += new System.EventHandler(this.btnDeleteDelay_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = global::Elvis.Properties.Resources.Print_11009;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = global::Elvis.Properties.Resources.PrintPreviewControl_698;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // grpEvent
            // 
            this.grpEvent.BackColor = System.Drawing.Color.Transparent;
            this.grpEvent.Controls.Add(this.pnlTableLayout);
            this.grpEvent.Controls.Add(this.grpTotals);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEvent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEvent.Location = new System.Drawing.Point(5, 5);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Padding = new System.Windows.Forms.Padding(3, 0, 5, 5);
            this.grpEvent.Size = new System.Drawing.Size(1082, 86);
            this.grpEvent.TabIndex = 6;
            this.grpEvent.TabStop = false;
            this.grpEvent.Text = "Event";
            // 
            // pnlTableLayout
            // 
            this.pnlTableLayout.Controls.Add(this.tableLayoutPanel1);
            this.pnlTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableLayout.Location = new System.Drawing.Point(3, 14);
            this.pnlTableLayout.Name = "pnlTableLayout";
            this.pnlTableLayout.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.pnlTableLayout.Size = new System.Drawing.Size(759, 67);
            this.pnlTableLayout.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHeatNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProgramNo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUnit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDuration, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label22, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtStartTime, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEndTime, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtStatus, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 62);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Heat Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHeatNo
            // 
            this.txtHeatNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtHeatNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeatNo.Location = new System.Drawing.Point(96, 3);
            this.txtHeatNo.Name = "txtHeatNo";
            this.txtHeatNo.ReadOnly = true;
            this.txtHeatNo.Size = new System.Drawing.Size(75, 20);
            this.txtHeatNo.TabIndex = 1;
            this.txtHeatNo.Text = "N/A";
            // 
            // txtProgramNo
            // 
            this.txtProgramNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtProgramNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramNo.Location = new System.Drawing.Point(96, 29);
            this.txtProgramNo.Name = "txtProgramNo";
            this.txtProgramNo.ReadOnly = true;
            this.txtProgramNo.Size = new System.Drawing.Size(75, 20);
            this.txtProgramNo.TabIndex = 5;
            this.txtProgramNo.Text = "Unavailable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Program Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.Location = new System.Drawing.Point(231, 3);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(75, 20);
            this.txtUnit.TabIndex = 2;
            this.txtUnit.Text = "Unavailable";
            // 
            // txtDuration
            // 
            this.txtDuration.BackColor = System.Drawing.SystemColors.Window;
            this.txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(231, 29);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(75, 20);
            this.txtDuration.TabIndex = 6;
            this.txtDuration.Text = "Unavailable";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 26);
            this.label5.TabIndex = 51;
            this.label5.Text = "Start Time";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(312, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "End Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(177, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 26);
            this.label22.TabIndex = 43;
            this.label22.Text = "Unit";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(177, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 26);
            this.label10.TabIndex = 6;
            this.label10.Text = "Duration";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStartTime
            // 
            this.txtStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartTime.Location = new System.Drawing.Point(374, 3);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(75, 20);
            this.txtStartTime.TabIndex = 3;
            this.txtStartTime.Text = "Unavailable";
            // 
            // txtEndTime
            // 
            this.txtEndTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndTime.Location = new System.Drawing.Point(374, 29);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(75, 20);
            this.txtEndTime.TabIndex = 7;
            this.txtEndTime.Text = "Unavailable";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(455, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 26);
            this.label8.TabIndex = 49;
            this.label8.Text = "Status";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(499, 3);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(109, 20);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.Text = "Unavailable";
            // 
            // grpTotals
            // 
            this.grpTotals.Controls.Add(this.lstTotals);
            this.grpTotals.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpTotals.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTotals.Location = new System.Drawing.Point(762, 14);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.grpTotals.Size = new System.Drawing.Size(315, 67);
            this.grpTotals.TabIndex = 10;
            this.grpTotals.TabStop = false;
            this.grpTotals.Text = "Totals";
            // 
            // lstTotals
            // 
            this.lstTotals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RequiredMins,
            this.DelayMins,
            this.MinsRemaining});
            this.lstTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTotals.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTotals.GridLines = true;
            this.lstTotals.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstTotals.Location = new System.Drawing.Point(5, 17);
            this.lstTotals.MultiSelect = false;
            this.lstTotals.Name = "lstTotals";
            this.lstTotals.Scrollable = false;
            this.lstTotals.Size = new System.Drawing.Size(305, 45);
            this.lstTotals.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstTotals.TabIndex = 8;
            this.lstTotals.UseCompatibleStateImageBehavior = false;
            this.lstTotals.View = System.Windows.Forms.View.Details;
            // 
            // RequiredMins
            // 
            this.RequiredMins.Text = "Event Mins";
            this.RequiredMins.Width = 77;
            // 
            // DelayMins
            // 
            this.DelayMins.Text = "Total Delay Mins";
            this.DelayMins.Width = 107;
            // 
            // MinsRemaining
            // 
            this.MinsRemaining.Text = "Mins Remaining";
            this.MinsRemaining.Width = 106;
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.grpEvent);
            this.pnlEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEvent.Location = new System.Drawing.Point(0, 24);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEvent.Size = new System.Drawing.Size(1092, 96);
            this.pnlEvent.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelArea,
            this.toolStripStatusLabelHeatNo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1092, 24);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelArea
            // 
            this.toolStripStatusLabelArea.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelArea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabelArea.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.toolStripStatusLabelArea.Name = "toolStripStatusLabelArea";
            this.toolStripStatusLabelArea.Size = new System.Drawing.Size(75, 19);
            this.toolStripStatusLabelArea.Text = "Unit Name - ";
            // 
            // toolStripStatusLabelHeatNo
            // 
            this.toolStripStatusLabelHeatNo.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelHeatNo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelHeatNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabelHeatNo.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.toolStripStatusLabelHeatNo.Name = "toolStripStatusLabelHeatNo";
            this.toolStripStatusLabelHeatNo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripStatusLabelHeatNo.Size = new System.Drawing.Size(104, 19);
            this.toolStripStatusLabelHeatNo.Text = "Heat Number - ";
            // 
            // pnlDelayEntryEventDetails
            // 
            this.pnlDelayEntryEventDetails.Controls.Add(this.grpTreatmentDetail);
            this.pnlDelayEntryEventDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDelayEntryEventDetails.Location = new System.Drawing.Point(0, 120);
            this.pnlDelayEntryEventDetails.Name = "pnlDelayEntryEventDetails";
            this.pnlDelayEntryEventDetails.Padding = new System.Windows.Forms.Padding(5);
            this.pnlDelayEntryEventDetails.Size = new System.Drawing.Size(1092, 207);
            this.pnlDelayEntryEventDetails.TabIndex = 10;
            // 
            // grpTreatmentDetail
            // 
            this.grpTreatmentDetail.Controls.Add(this.treatmentDetailsPanel);
            this.grpTreatmentDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTreatmentDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTreatmentDetail.Location = new System.Drawing.Point(5, 5);
            this.grpTreatmentDetail.Name = "grpTreatmentDetail";
            this.grpTreatmentDetail.Size = new System.Drawing.Size(1082, 197);
            this.grpTreatmentDetail.TabIndex = 0;
            this.grpTreatmentDetail.TabStop = false;
            this.grpTreatmentDetail.Text = "Treatment Detail";
            // 
            // treatmentDetailsPanel
            // 
            this.treatmentDetailsPanel.Controls.Add(this.tibDelayEntryEvent);
            this.treatmentDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treatmentDetailsPanel.Location = new System.Drawing.Point(3, 17);
            this.treatmentDetailsPanel.Name = "treatmentDetailsPanel";
            this.treatmentDetailsPanel.Size = new System.Drawing.Size(1076, 177);
            this.treatmentDetailsPanel.TabIndex = 0;
            // 
            // tibDelayEntryEvent
            // 
            this.tibDelayEntryEvent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tibDelayEntryEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tibDelayEntryEvent.Location = new System.Drawing.Point(0, 0);
            this.tibDelayEntryEvent.Name = "tibDelayEntryEvent";
            this.tibDelayEntryEvent.Size = new System.Drawing.Size(1076, 177);
            this.tibDelayEntryEvent.TabIndex = 0;
            // 
            // pnlDelays
            // 
            this.pnlDelays.Controls.Add(this.grpDelays);
            this.pnlDelays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDelays.Location = new System.Drawing.Point(0, 327);
            this.pnlDelays.Name = "pnlDelays";
            this.pnlDelays.Padding = new System.Windows.Forms.Padding(5);
            this.pnlDelays.Size = new System.Drawing.Size(1092, 284);
            this.pnlDelays.TabIndex = 11;
            // 
            // grpDelays
            // 
            this.grpDelays.BackColor = System.Drawing.Color.Transparent;
            this.grpDelays.Controls.Add(this.delayDetailGrid);
            this.grpDelays.Controls.Add(this.panel1);
            this.grpDelays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDelays.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDelays.Location = new System.Drawing.Point(5, 5);
            this.grpDelays.Name = "grpDelays";
            this.grpDelays.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.grpDelays.Size = new System.Drawing.Size(1082, 274);
            this.grpDelays.TabIndex = 7;
            this.grpDelays.TabStop = false;
            this.grpDelays.Text = "Delays Detail";
            // 
            // delayDetailGrid
            // 
            this.delayDetailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delayDetailGrid.Location = new System.Drawing.Point(3, 60);
            this.delayDetailGrid.Name = "delayDetailGrid";
            this.delayDetailGrid.Padding = new System.Windows.Forms.Padding(3);
            this.delayDetailGrid.Size = new System.Drawing.Size(1076, 211);
            this.delayDetailGrid.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlButtons);
            this.panel1.Controls.Add(this.lblEndTime);
            this.panel1.Controls.Add(this.lblStartTime);
            this.panel1.Controls.Add(this.pnlBoxDisplay);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(1076, 38);
            this.panel1.TabIndex = 11;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnUp);
            this.pnlButtons.Controls.Add(this.btnDown);
            this.pnlButtons.Controls.Add(this.btnDeleteDelay);
            this.pnlButtons.Controls.Add(this.btnAddDelay);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(806, 3);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(267, 32);
            this.pnlButtons.TabIndex = 12;
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(5, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(36, 32);
            this.btnUp.TabIndex = 17;
            this.btnUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnUp, "Moves the selected delay up one in the order.");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(41, 0);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(36, 32);
            this.btnDown.TabIndex = 16;
            this.toolTip1.SetToolTip(this.btnDown, "Moves the selected delay down one in the order.");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDeleteDelay
            // 
            this.btnDeleteDelay.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteDelay.Enabled = false;
            this.btnDeleteDelay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDelay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteDelay.Image = global::Elvis.Properties.Resources.delete_12x12;
            this.btnDeleteDelay.Location = new System.Drawing.Point(77, 0);
            this.btnDeleteDelay.Name = "btnDeleteDelay";
            this.btnDeleteDelay.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDeleteDelay.Size = new System.Drawing.Size(95, 32);
            this.btnDeleteDelay.TabIndex = 18;
            this.btnDeleteDelay.Text = "&Delete";
            this.btnDeleteDelay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnDeleteDelay, "Delete the selected delay permanently. This process cannot be undone.");
            this.btnDeleteDelay.UseVisualStyleBackColor = true;
            this.btnDeleteDelay.Click += new System.EventHandler(this.btnDeleteDelay_Click);
            // 
            // btnAddDelay
            // 
            this.btnAddDelay.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddDelay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDelay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddDelay.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDelay.Image")));
            this.btnAddDelay.Location = new System.Drawing.Point(172, 0);
            this.btnAddDelay.Name = "btnAddDelay";
            this.btnAddDelay.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnAddDelay.Size = new System.Drawing.Size(95, 32);
            this.btnAddDelay.TabIndex = 9;
            this.btnAddDelay.Text = "Add &New...";
            this.btnAddDelay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnAddDelay, "Opens a dialog window to insert a new delay.");
            this.btnAddDelay.UseVisualStyleBackColor = true;
            this.btnAddDelay.Click += new System.EventHandler(this.btnAddDelay_Click);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(579, 12);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(35, 13);
            this.lblEndTime.TabIndex = 14;
            this.lblEndTime.Text = "00:00";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(239, 12);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(35, 13);
            this.lblStartTime.TabIndex = 13;
            this.lblStartTime.Text = "00:00";
            // 
            // pnlBoxDisplay
            // 
            this.pnlBoxDisplay.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBoxDisplay.Location = new System.Drawing.Point(276, 6);
            this.pnlBoxDisplay.Name = "pnlBoxDisplay";
            this.pnlBoxDisplay.Size = new System.Drawing.Size(300, 24);
            this.pnlBoxDisplay.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Double-click row to edit delay";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 327);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1092, 3);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // DelayEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1092, 635);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlDelays);
            this.Controls.Add(this.pnlDelayEntryEventDetails);
            this.Controls.Add(this.pnlEvent);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "DelayEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIB Delay Entry";
            this.Shown += new System.EventHandler(this.DelayEntry_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelayEntry_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpEvent.ResumeLayout(false);
            this.pnlTableLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpTotals.ResumeLayout(false);
            this.pnlEvent.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlDelayEntryEventDetails.ResumeLayout(false);
            this.grpTreatmentDetail.ResumeLayout(false);
            this.treatmentDetailsPanel.ResumeLayout(false);
            this.pnlDelays.ResumeLayout(false);
            this.grpDelays.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpEvent;
        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.GroupBox grpTotals;
        private System.Windows.Forms.ListView lstTotals;
        private System.Windows.Forms.ColumnHeader RequiredMins;
        private System.Windows.Forms.ColumnHeader DelayMins;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelArea;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHeatNo;
        private System.Windows.Forms.ToolStripMenuItem delaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewDelayToolStripMenuItemNewDelay;
        private System.Windows.Forms.ColumnHeader MinsRemaining;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteDelay;
        private System.Windows.Forms.Panel pnlTableLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHeatNo;
        private System.Windows.Forms.TextBox txtProgramNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Panel pnlDelayEntryEventDetails;
        private System.Windows.Forms.GroupBox grpTreatmentDetail;
        private System.Windows.Forms.Panel pnlDelays;
        private System.Windows.Forms.GroupBox grpDelays;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnDeleteDelay;
        private System.Windows.Forms.Button btnAddDelay;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Panel pnlBoxDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel treatmentDetailsPanel;
        private UserControls.Tib.TibDelayEntryEvent tibDelayEntryEvent;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private UserControls.Tib.DelayDetailGrid delayDetailGrid;
    }
}