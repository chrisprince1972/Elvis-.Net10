using Elvis.UserControls.HeatDetails.HotMetalUCs;
namespace Elvis.UserControls.HeatDetails
{
    partial class HeatDetailsOverview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpProcessDetails = new System.Windows.Forms.GroupBox();
            this.splitProcessDetails = new System.Windows.Forms.SplitContainer();
            this.gdvHeatEvents = new System.Windows.Forms.DataGridView();
            this.TrackIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitShort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStampStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStampEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProgramNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeatLog = new System.Windows.Forms.Panel();
            this.grpSubEvents = new System.Windows.Forms.GroupBox();
            this.ucHeatLogDisplay = new Elvis.UserControls.HeatDetails.HotMetalUCs.HeatLogDisplay();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbShowAllEvents = new System.Windows.Forms.CheckBox();
            this.grpTapTime = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtRota = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtWeek = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HNS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.grpProcessDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitProcessDetails)).BeginInit();
            this.splitProcessDetails.Panel1.SuspendLayout();
            this.splitProcessDetails.Panel2.SuspendLayout();
            this.splitProcessDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvHeatEvents)).BeginInit();
            this.pnlHeatLog.SuspendLayout();
            this.grpSubEvents.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpTapTime.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpProcessDetails);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(1049, 700);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Visible = false;
            // 
            // grpProcessDetails
            // 
            this.grpProcessDetails.Controls.Add(this.splitProcessDetails);
            this.grpProcessDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProcessDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProcessDetails.Location = new System.Drawing.Point(6, 6);
            this.grpProcessDetails.Margin = new System.Windows.Forms.Padding(0);
            this.grpProcessDetails.MinimumSize = new System.Drawing.Size(0, 100);
            this.grpProcessDetails.Name = "grpProcessDetails";
            this.grpProcessDetails.Padding = new System.Windows.Forms.Padding(6);
            this.grpProcessDetails.Size = new System.Drawing.Size(1037, 688);
            this.grpProcessDetails.TabIndex = 8;
            this.grpProcessDetails.TabStop = false;
            this.grpProcessDetails.Text = "Heat Details";
            // 
            // splitProcessDetails
            // 
            this.splitProcessDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitProcessDetails.Location = new System.Drawing.Point(6, 20);
            this.splitProcessDetails.Name = "splitProcessDetails";
            this.splitProcessDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitProcessDetails.Panel1
            // 
            this.splitProcessDetails.Panel1.Controls.Add(this.gdvHeatEvents);
            // 
            // splitProcessDetails.Panel2
            // 
            this.splitProcessDetails.Panel2.Controls.Add(this.pnlHeatLog);
            this.splitProcessDetails.Panel2.Controls.Add(this.grpTapTime);
            this.splitProcessDetails.Panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.splitProcessDetails.Size = new System.Drawing.Size(1025, 662);
            this.splitProcessDetails.SplitterDistance = 156;
            this.splitProcessDetails.TabIndex = 4;
            // 
            // gdvHeatEvents
            // 
            this.gdvHeatEvents.AllowUserToAddRows = false;
            this.gdvHeatEvents.AllowUserToDeleteRows = false;
            this.gdvHeatEvents.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gdvHeatEvents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gdvHeatEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvHeatEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gdvHeatEvents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gdvHeatEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gdvHeatEvents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.gdvHeatEvents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdvHeatEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gdvHeatEvents.ColumnHeadersHeight = 25;
            this.gdvHeatEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdvHeatEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrackIndex,
            this.Column1,
            this.TimeCreated,
            this.UnitShort,
            this.TimeStampStart,
            this.TimeStampEnd,
            this.Duration,
            this.ProgramNumber,
            this.TempBegin,
            this.TempEnd,
            this.WeightBegin,
            this.WeightEnd});
            this.gdvHeatEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvHeatEvents.EnableHeadersVisualStyles = false;
            this.gdvHeatEvents.GridColor = System.Drawing.Color.DimGray;
            this.gdvHeatEvents.Location = new System.Drawing.Point(0, 0);
            this.gdvHeatEvents.MultiSelect = false;
            this.gdvHeatEvents.Name = "gdvHeatEvents";
            this.gdvHeatEvents.ReadOnly = true;
            this.gdvHeatEvents.RowHeadersVisible = false;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdvHeatEvents.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.gdvHeatEvents.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdvHeatEvents.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gdvHeatEvents.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gdvHeatEvents.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.gdvHeatEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvHeatEvents.Size = new System.Drawing.Size(1025, 156);
            this.gdvHeatEvents.TabIndex = 1;
            this.gdvHeatEvents.SelectionChanged += new System.EventHandler(this.gdvHeatEvents_SelectionChanged);
            // 
            // TrackIndex
            // 
            this.TrackIndex.DataPropertyName = "TrackIndex";
            this.TrackIndex.HeaderText = "TrackIndex";
            this.TrackIndex.Name = "TrackIndex";
            this.TrackIndex.ReadOnly = true;
            this.TrackIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TrackIndex.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Activity";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Visible = false;
            // 
            // TimeCreated
            // 
            this.TimeCreated.DataPropertyName = "TimeCreated";
            dataGridViewCellStyle13.Format = "t";
            this.TimeCreated.DefaultCellStyle = dataGridViewCellStyle13;
            this.TimeCreated.HeaderText = "Time Created";
            this.TimeCreated.Name = "TimeCreated";
            this.TimeCreated.ReadOnly = true;
            this.TimeCreated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TimeCreated.Visible = false;
            // 
            // UnitShort
            // 
            this.UnitShort.DataPropertyName = "UnitShort";
            this.UnitShort.HeaderText = "Unit";
            this.UnitShort.Name = "UnitShort";
            this.UnitShort.ReadOnly = true;
            this.UnitShort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimeStampStart
            // 
            this.TimeStampStart.DataPropertyName = "TimeStampStart";
            dataGridViewCellStyle14.Format = "T";
            dataGridViewCellStyle14.NullValue = null;
            this.TimeStampStart.DefaultCellStyle = dataGridViewCellStyle14;
            this.TimeStampStart.HeaderText = "Start Time";
            this.TimeStampStart.Name = "TimeStampStart";
            this.TimeStampStart.ReadOnly = true;
            this.TimeStampStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimeStampEnd
            // 
            this.TimeStampEnd.DataPropertyName = "TimeStampEnd";
            dataGridViewCellStyle15.Format = "T";
            dataGridViewCellStyle15.NullValue = null;
            this.TimeStampEnd.DefaultCellStyle = dataGridViewCellStyle15;
            this.TimeStampEnd.HeaderText = "End Time";
            this.TimeStampEnd.Name = "TimeStampEnd";
            this.TimeStampEnd.ReadOnly = true;
            this.TimeStampEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Duration
            // 
            this.Duration.DataPropertyName = "Duration";
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProgramNumber
            // 
            this.ProgramNumber.DataPropertyName = "ProgramNumber";
            this.ProgramNumber.HeaderText = "Program No.";
            this.ProgramNumber.Name = "ProgramNumber";
            this.ProgramNumber.ReadOnly = true;
            this.ProgramNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TempBegin
            // 
            this.TempBegin.DataPropertyName = "TempBegin";
            dataGridViewCellStyle16.Format = "0.0";
            this.TempBegin.DefaultCellStyle = dataGridViewCellStyle16;
            this.TempBegin.HeaderText = "Temp Begin";
            this.TempBegin.Name = "TempBegin";
            this.TempBegin.ReadOnly = true;
            this.TempBegin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TempEnd
            // 
            this.TempEnd.DataPropertyName = "TempEnd";
            dataGridViewCellStyle17.Format = "0.0";
            this.TempEnd.DefaultCellStyle = dataGridViewCellStyle17;
            this.TempEnd.HeaderText = "Temp End";
            this.TempEnd.Name = "TempEnd";
            this.TempEnd.ReadOnly = true;
            this.TempEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WeightBegin
            // 
            this.WeightBegin.DataPropertyName = "WeightBegin";
            dataGridViewCellStyle18.Format = "0.0";
            this.WeightBegin.DefaultCellStyle = dataGridViewCellStyle18;
            this.WeightBegin.HeaderText = "Weight Begin";
            this.WeightBegin.Name = "WeightBegin";
            this.WeightBegin.ReadOnly = true;
            this.WeightBegin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WeightEnd
            // 
            this.WeightEnd.DataPropertyName = "WeightEnd";
            dataGridViewCellStyle19.Format = "0.0";
            this.WeightEnd.DefaultCellStyle = dataGridViewCellStyle19;
            this.WeightEnd.HeaderText = "Weight End";
            this.WeightEnd.Name = "WeightEnd";
            this.WeightEnd.ReadOnly = true;
            this.WeightEnd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlHeatLog
            // 
            this.pnlHeatLog.Controls.Add(this.grpSubEvents);
            this.pnlHeatLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeatLog.Location = new System.Drawing.Point(0, 6);
            this.pnlHeatLog.Name = "pnlHeatLog";
            this.pnlHeatLog.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlHeatLog.Size = new System.Drawing.Size(875, 496);
            this.pnlHeatLog.TabIndex = 9;
            // 
            // grpSubEvents
            // 
            this.grpSubEvents.Controls.Add(this.ucHeatLogDisplay);
            this.grpSubEvents.Controls.Add(this.panel2);
            this.grpSubEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubEvents.Location = new System.Drawing.Point(0, 0);
            this.grpSubEvents.MinimumSize = new System.Drawing.Size(0, 100);
            this.grpSubEvents.Name = "grpSubEvents";
            this.grpSubEvents.Padding = new System.Windows.Forms.Padding(6);
            this.grpSubEvents.Size = new System.Drawing.Size(869, 496);
            this.grpSubEvents.TabIndex = 2;
            this.grpSubEvents.TabStop = false;
            this.grpSubEvents.Text = "Events for ";
            // 
            // ucHeatLogDisplay
            // 
            this.ucHeatLogDisplay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucHeatLogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHeatLogDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucHeatLogDisplay.Location = new System.Drawing.Point(6, 44);
            this.ucHeatLogDisplay.Name = "ucHeatLogDisplay";
            this.ucHeatLogDisplay.Size = new System.Drawing.Size(857, 446);
            this.ucHeatLogDisplay.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chbShowAllEvents);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 20);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.panel2.Size = new System.Drawing.Size(857, 24);
            this.panel2.TabIndex = 4;
            // 
            // chbShowAllEvents
            // 
            this.chbShowAllEvents.AutoSize = true;
            this.chbShowAllEvents.Checked = true;
            this.chbShowAllEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowAllEvents.Dock = System.Windows.Forms.DockStyle.Right;
            this.chbShowAllEvents.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbShowAllEvents.Location = new System.Drawing.Point(742, 0);
            this.chbShowAllEvents.Name = "chbShowAllEvents";
            this.chbShowAllEvents.Size = new System.Drawing.Size(109, 18);
            this.chbShowAllEvents.TabIndex = 0;
            this.chbShowAllEvents.Text = "Show for all Units";
            this.chbShowAllEvents.UseVisualStyleBackColor = true;
            this.chbShowAllEvents.CheckedChanged += new System.EventHandler(this.chbShowAllEvents_CheckedChanged);
            // 
            // grpTapTime
            // 
            this.grpTapTime.Controls.Add(this.tableLayoutPanel1);
            this.grpTapTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpTapTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTapTime.Location = new System.Drawing.Point(875, 6);
            this.grpTapTime.MinimumSize = new System.Drawing.Size(0, 52);
            this.grpTapTime.Name = "grpTapTime";
            this.grpTapTime.Padding = new System.Windows.Forms.Padding(6);
            this.grpTapTime.Size = new System.Drawing.Size(150, 496);
            this.grpTapTime.TabIndex = 8;
            this.grpTapTime.TabStop = false;
            this.grpTapTime.Text = "Tap Time Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblWeek, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtRota, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtWeek, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtYear, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDate, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(138, 470);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 135);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Size = new System.Drawing.Size(41, 27);
            this.label2.TabIndex = 29;
            this.label2.Text = "Year";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWeek.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(3, 108);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblWeek.Size = new System.Drawing.Size(41, 27);
            this.lblWeek.TabIndex = 27;
            this.lblWeek.Text = "Week";
            this.lblWeek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Size = new System.Drawing.Size(41, 27);
            this.label3.TabIndex = 25;
            this.label3.Text = "Day";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Size = new System.Drawing.Size(41, 27);
            this.label5.TabIndex = 22;
            this.label5.Text = "Rota";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Size = new System.Drawing.Size(41, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(50, 30);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(85, 21);
            this.txtTime.TabIndex = 7;
            // 
            // txtRota
            // 
            this.txtRota.BackColor = System.Drawing.SystemColors.Window;
            this.txtRota.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRota.Location = new System.Drawing.Point(50, 57);
            this.txtRota.Name = "txtRota";
            this.txtRota.ReadOnly = true;
            this.txtRota.Size = new System.Drawing.Size(45, 21);
            this.txtRota.TabIndex = 23;
            // 
            // txtDay
            // 
            this.txtDay.BackColor = System.Drawing.SystemColors.Window;
            this.txtDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDay.Location = new System.Drawing.Point(50, 84);
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size(45, 21);
            this.txtDay.TabIndex = 24;
            // 
            // txtWeek
            // 
            this.txtWeek.BackColor = System.Drawing.SystemColors.Window;
            this.txtWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeek.Location = new System.Drawing.Point(50, 111);
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.ReadOnly = true;
            this.txtWeek.Size = new System.Drawing.Size(45, 21);
            this.txtWeek.TabIndex = 26;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.SystemColors.Window;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(50, 138);
            this.txtYear.Name = "txtYear";
            this.txtYear.ReadOnly = true;
            this.txtYear.Size = new System.Drawing.Size(45, 21);
            this.txtYear.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Size = new System.Drawing.Size(41, 27);
            this.label4.TabIndex = 30;
            this.label4.Text = "Date";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(50, 3);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(85, 21);
            this.txtDate.TabIndex = 31;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Container";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "HNS";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "UnitNumber";
            this.dataGridViewTextBoxColumn15.HeaderText = "UnitNumber";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "UnitShort";
            this.dataGridViewTextBoxColumn14.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Container";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Visible = false;
            // 
            // HeatNo
            // 
            this.HeatNo.DataPropertyName = "HeatNumber";
            this.HeatNo.HeaderText = "HeatNo";
            this.HeatNo.Name = "HeatNo";
            this.HeatNo.ReadOnly = true;
            this.HeatNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HeatNo.Visible = false;
            // 
            // UnitNumber
            // 
            this.UnitNumber.DataPropertyName = "UnitNumber";
            this.UnitNumber.HeaderText = "UnitNumber";
            this.UnitNumber.Name = "UnitNumber";
            this.UnitNumber.ReadOnly = true;
            this.UnitNumber.Visible = false;
            // 
            // HNS
            // 
            this.HNS.HeaderText = "HNS";
            this.HNS.Name = "HNS";
            this.HNS.ReadOnly = true;
            this.HNS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HNS.Visible = false;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "UnitShort";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "HeatNumber";
            this.dataGridViewTextBoxColumn18.HeaderText = "HeatNo";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // HeatDetailsOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "HeatDetailsOverview";
            this.Size = new System.Drawing.Size(1049, 700);
            this.Load += new System.EventHandler(this.ProcHeatDetails_Load);
            this.pnlMain.ResumeLayout(false);
            this.grpProcessDetails.ResumeLayout(false);
            this.splitProcessDetails.Panel1.ResumeLayout(false);
            this.splitProcessDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitProcessDetails)).EndInit();
            this.splitProcessDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvHeatEvents)).EndInit();
            this.pnlHeatLog.ResumeLayout(false);
            this.grpSubEvents.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpTapTime.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpProcessDetails;
        private System.Windows.Forms.SplitContainer splitProcessDetails;
        private System.Windows.Forms.DataGridView gdvHeatEvents;
        private System.Windows.Forms.Panel pnlHeatLog;
        private System.Windows.Forms.GroupBox grpSubEvents;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chbShowAllEvents;
        private System.Windows.Forms.GroupBox grpTapTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtRota;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtWeek;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn HNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private HeatLogDisplay ucHeatLogDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitShort;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStampStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStampEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProgramNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightEnd;


    }
}
