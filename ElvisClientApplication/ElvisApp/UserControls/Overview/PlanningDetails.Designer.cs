namespace Elvis.UserControls.HeatDetails
{
    partial class PlanningDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanningDetails));
            this.grpPlanning = new System.Windows.Forms.GroupBox();
            this.pnlGrids = new System.Windows.Forms.Panel();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPlanTimes = new System.Windows.Forms.Panel();
            this.grpTimes = new System.Windows.Forms.GroupBox();
            this.tlpPlanTimes = new System.Windows.Forms.TableLayoutPanel();
            this.txtPourStart = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtPourEnd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDesulphStart = new System.Windows.Forms.TextBox();
            this.txtDesulphEnd = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtVesselStart = new System.Windows.Forms.TextBox();
            this.txtVesselEnd = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtSSStart = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtSSEnd = new System.Windows.Forms.TextBox();
            this.txtCasterStart = new System.Windows.Forms.TextBox();
            this.txtCasterEnd = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.grpHeatDetails = new System.Windows.Forms.GroupBox();
            this.tlpHeatDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeatNumber = new System.Windows.Forms.TextBox();
            this.txtProgramNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVesselNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSteelLadleNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCasterNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGrade1 = new System.Windows.Forms.TextBox();
            this.txtGrade2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSSUnit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCastTime = new System.Windows.Forms.Label();
            this.txtCastSpeed = new System.Windows.Forms.TextBox();
            this.txtCastTon = new System.Windows.Forms.TextBox();
            this.txtCastDuration = new System.Windows.Forms.TextBox();
            this.txtIdealCastDuration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlPlanNavi = new System.Windows.Forms.Panel();
            this.grpPlan = new System.Windows.Forms.GroupBox();
            this.btnNextPlan = new System.Windows.Forms.Button();
            this.cmboPlanDTs = new System.Windows.Forms.ComboBox();
            this.btnPreviousPlan = new System.Windows.Forms.Button();
            this.grpPlanning.SuspendLayout();
            this.pnlGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.pnlPlanTimes.SuspendLayout();
            this.grpTimes.SuspendLayout();
            this.tlpPlanTimes.SuspendLayout();
            this.grpHeatDetails.SuspendLayout();
            this.tlpHeatDetails.SuspendLayout();
            this.pnlPlanNavi.SuspendLayout();
            this.grpPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPlanning
            // 
            this.grpPlanning.Controls.Add(this.pnlGrids);
            this.grpPlanning.Controls.Add(this.pnlPlanTimes);
            this.grpPlanning.Controls.Add(this.grpHeatDetails);
            this.grpPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlanning.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlanning.Location = new System.Drawing.Point(3, 56);
            this.grpPlanning.Name = "grpPlanning";
            this.grpPlanning.Padding = new System.Windows.Forms.Padding(6);
            this.grpPlanning.Size = new System.Drawing.Size(615, 364);
            this.grpPlanning.TabIndex = 7;
            this.grpPlanning.TabStop = false;
            this.grpPlanning.Text = "Planning Details";
            // 
            // pnlGrids
            // 
            this.pnlGrids.Controls.Add(this.dgvComments);
            this.pnlGrids.Controls.Add(this.dgvEvents);
            this.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrids.Location = new System.Drawing.Point(6, 221);
            this.pnlGrids.Name = "pnlGrids";
            this.pnlGrids.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlGrids.Size = new System.Drawing.Size(603, 137);
            this.pnlGrids.TabIndex = 10;
            // 
            // dgvComments
            // 
            this.dgvComments.AllowUserToAddRows = false;
            this.dgvComments.AllowUserToDeleteRows = false;
            this.dgvComments.AllowUserToResizeRows = false;
            this.dgvComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvComments.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvComments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvComments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComments.ColumnHeadersHeight = 25;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Comments});
            this.dgvComments.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvComments.EnableHeadersVisualStyles = false;
            this.dgvComments.GridColor = System.Drawing.Color.DimGray;
            this.dgvComments.Location = new System.Drawing.Point(0, 6);
            this.dgvComments.MultiSelect = false;
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComments.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComments.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvComments.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvComments.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvComments.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvComments.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComments.Size = new System.Drawing.Size(269, 131);
            this.dgvComments.TabIndex = 6;
            // 
            // Comments
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comments.DefaultCellStyle = dataGridViewCellStyle2;
            this.Comments.HeaderText = "Planned Heat Comments";
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            this.Comments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AllowUserToDeleteRows = false;
            this.dgvEvents.AllowUserToResizeRows = false;
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEvents.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEvents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvEvents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEvents.ColumnHeadersHeight = 25;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Unit,
            this.StartTime,
            this.EndTime,
            this.Duration});
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvEvents.EnableHeadersVisualStyles = false;
            this.dgvEvents.GridColor = System.Drawing.Color.DimGray;
            this.dgvEvents.Location = new System.Drawing.Point(275, 6);
            this.dgvEvents.MultiSelect = false;
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEvents.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEvents.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEvents.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvEvents.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvEvents.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvents.Size = new System.Drawing.Size(328, 131);
            this.dgvEvents.TabIndex = 2;
            // 
            // Unit
            // 
            this.Unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StartTime
            // 
            this.StartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartTime.Width = 72;
            // 
            // EndTime
            // 
            this.EndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EndTime.Width = 63;
            // 
            // Duration
            // 
            this.Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Duration.Width = 61;
            // 
            // pnlPlanTimes
            // 
            this.pnlPlanTimes.Controls.Add(this.grpTimes);
            this.pnlPlanTimes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlanTimes.Location = new System.Drawing.Point(6, 145);
            this.pnlPlanTimes.Name = "pnlPlanTimes";
            this.pnlPlanTimes.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlPlanTimes.Size = new System.Drawing.Size(603, 76);
            this.pnlPlanTimes.TabIndex = 7;
            // 
            // grpTimes
            // 
            this.grpTimes.Controls.Add(this.tlpPlanTimes);
            this.grpTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTimes.Location = new System.Drawing.Point(0, 3);
            this.grpTimes.Name = "grpTimes";
            this.grpTimes.Size = new System.Drawing.Size(603, 73);
            this.grpTimes.TabIndex = 7;
            this.grpTimes.TabStop = false;
            this.grpTimes.Text = "Plan Times";
            // 
            // tlpPlanTimes
            // 
            this.tlpPlanTimes.ColumnCount = 10;
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlanTimes.Controls.Add(this.txtPourStart, 1, 0);
            this.tlpPlanTimes.Controls.Add(this.label25, 0, 0);
            this.tlpPlanTimes.Controls.Add(this.label26, 0, 1);
            this.tlpPlanTimes.Controls.Add(this.txtPourEnd, 1, 1);
            this.tlpPlanTimes.Controls.Add(this.label17, 2, 0);
            this.tlpPlanTimes.Controls.Add(this.label16, 2, 1);
            this.tlpPlanTimes.Controls.Add(this.txtDesulphStart, 3, 0);
            this.tlpPlanTimes.Controls.Add(this.txtDesulphEnd, 3, 1);
            this.tlpPlanTimes.Controls.Add(this.label27, 4, 0);
            this.tlpPlanTimes.Controls.Add(this.label18, 4, 1);
            this.tlpPlanTimes.Controls.Add(this.txtVesselStart, 5, 0);
            this.tlpPlanTimes.Controls.Add(this.txtVesselEnd, 5, 1);
            this.tlpPlanTimes.Controls.Add(this.label33, 6, 0);
            this.tlpPlanTimes.Controls.Add(this.txtSSStart, 7, 0);
            this.tlpPlanTimes.Controls.Add(this.label34, 6, 1);
            this.tlpPlanTimes.Controls.Add(this.txtSSEnd, 7, 1);
            this.tlpPlanTimes.Controls.Add(this.txtCasterStart, 9, 0);
            this.tlpPlanTimes.Controls.Add(this.txtCasterEnd, 9, 1);
            this.tlpPlanTimes.Controls.Add(this.label35, 8, 0);
            this.tlpPlanTimes.Controls.Add(this.label36, 8, 1);
            this.tlpPlanTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlanTimes.Location = new System.Drawing.Point(3, 17);
            this.tlpPlanTimes.Name = "tlpPlanTimes";
            this.tlpPlanTimes.RowCount = 3;
            this.tlpPlanTimes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlanTimes.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlanTimes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpPlanTimes.Size = new System.Drawing.Size(597, 53);
            this.tlpPlanTimes.TabIndex = 6;
            // 
            // txtPourStart
            // 
            this.txtPourStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtPourStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPourStart.Location = new System.Drawing.Point(65, 3);
            this.txtPourStart.Name = "txtPourStart";
            this.txtPourStart.ReadOnly = true;
            this.txtPourStart.Size = new System.Drawing.Size(48, 20);
            this.txtPourStart.TabIndex = 17;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(3, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 26);
            this.label25.TabIndex = 6;
            this.label25.Text = "Pour Start";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(3, 26);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 26);
            this.label26.TabIndex = 45;
            this.label26.Text = "Pour End";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPourEnd
            // 
            this.txtPourEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtPourEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPourEnd.Location = new System.Drawing.Point(65, 29);
            this.txtPourEnd.Name = "txtPourEnd";
            this.txtPourEnd.ReadOnly = true;
            this.txtPourEnd.Size = new System.Drawing.Size(48, 20);
            this.txtPourEnd.TabIndex = 46;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(119, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 26);
            this.label17.TabIndex = 6;
            this.label17.Text = "Desulph Start";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(119, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 26);
            this.label16.TabIndex = 6;
            this.label16.Text = "Desulph End";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesulphStart
            // 
            this.txtDesulphStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtDesulphStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesulphStart.Location = new System.Drawing.Point(197, 3);
            this.txtDesulphStart.Name = "txtDesulphStart";
            this.txtDesulphStart.ReadOnly = true;
            this.txtDesulphStart.Size = new System.Drawing.Size(48, 20);
            this.txtDesulphStart.TabIndex = 19;
            // 
            // txtDesulphEnd
            // 
            this.txtDesulphEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtDesulphEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesulphEnd.Location = new System.Drawing.Point(197, 29);
            this.txtDesulphEnd.Name = "txtDesulphEnd";
            this.txtDesulphEnd.ReadOnly = true;
            this.txtDesulphEnd.Size = new System.Drawing.Size(48, 20);
            this.txtDesulphEnd.TabIndex = 20;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(251, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 26);
            this.label27.TabIndex = 49;
            this.label27.Text = "Vessel Start";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(251, 26);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 26);
            this.label18.TabIndex = 54;
            this.label18.Text = "Vessel End";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVesselStart
            // 
            this.txtVesselStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtVesselStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVesselStart.Location = new System.Drawing.Point(321, 3);
            this.txtVesselStart.Name = "txtVesselStart";
            this.txtVesselStart.ReadOnly = true;
            this.txtVesselStart.Size = new System.Drawing.Size(48, 20);
            this.txtVesselStart.TabIndex = 21;
            // 
            // txtVesselEnd
            // 
            this.txtVesselEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtVesselEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVesselEnd.Location = new System.Drawing.Point(321, 29);
            this.txtVesselEnd.Name = "txtVesselEnd";
            this.txtVesselEnd.ReadOnly = true;
            this.txtVesselEnd.Size = new System.Drawing.Size(48, 20);
            this.txtVesselEnd.TabIndex = 48;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(375, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(46, 26);
            this.label33.TabIndex = 50;
            this.label33.Text = "SS Start";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSSStart
            // 
            this.txtSSStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtSSStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSStart.Location = new System.Drawing.Point(427, 3);
            this.txtSSStart.Name = "txtSSStart";
            this.txtSSStart.ReadOnly = true;
            this.txtSSStart.Size = new System.Drawing.Size(48, 20);
            this.txtSSStart.TabIndex = 31;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(375, 26);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(46, 26);
            this.label34.TabIndex = 51;
            this.label34.Text = "SS End";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSSEnd
            // 
            this.txtSSEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtSSEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSEnd.Location = new System.Drawing.Point(427, 29);
            this.txtSSEnd.Name = "txtSSEnd";
            this.txtSSEnd.ReadOnly = true;
            this.txtSSEnd.Size = new System.Drawing.Size(48, 20);
            this.txtSSEnd.TabIndex = 34;
            // 
            // txtCasterStart
            // 
            this.txtCasterStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtCasterStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCasterStart.Location = new System.Drawing.Point(553, 3);
            this.txtCasterStart.Name = "txtCasterStart";
            this.txtCasterStart.ReadOnly = true;
            this.txtCasterStart.Size = new System.Drawing.Size(48, 20);
            this.txtCasterStart.TabIndex = 27;
            // 
            // txtCasterEnd
            // 
            this.txtCasterEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtCasterEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCasterEnd.Location = new System.Drawing.Point(553, 29);
            this.txtCasterEnd.Name = "txtCasterEnd";
            this.txtCasterEnd.ReadOnly = true;
            this.txtCasterEnd.Size = new System.Drawing.Size(48, 20);
            this.txtCasterEnd.TabIndex = 30;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(481, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(66, 26);
            this.label35.TabIndex = 52;
            this.label35.Text = "Caster Start";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(481, 26);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(66, 26);
            this.label36.TabIndex = 53;
            this.label36.Text = "Caster End";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpHeatDetails
            // 
            this.grpHeatDetails.Controls.Add(this.tlpHeatDetails);
            this.grpHeatDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHeatDetails.Location = new System.Drawing.Point(6, 20);
            this.grpHeatDetails.Name = "grpHeatDetails";
            this.grpHeatDetails.Size = new System.Drawing.Size(603, 125);
            this.grpHeatDetails.TabIndex = 9;
            this.grpHeatDetails.TabStop = false;
            this.grpHeatDetails.Text = "Heat Details";
            // 
            // tlpHeatDetails
            // 
            this.tlpHeatDetails.ColumnCount = 8;
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpHeatDetails.Controls.Add(this.label1, 0, 0);
            this.tlpHeatDetails.Controls.Add(this.txtHeatNumber, 1, 0);
            this.tlpHeatDetails.Controls.Add(this.txtProgramNo, 1, 1);
            this.tlpHeatDetails.Controls.Add(this.label2, 0, 1);
            this.tlpHeatDetails.Controls.Add(this.txtVesselNo, 3, 0);
            this.tlpHeatDetails.Controls.Add(this.label10, 2, 2);
            this.tlpHeatDetails.Controls.Add(this.txtWidth, 5, 2);
            this.tlpHeatDetails.Controls.Add(this.label11, 4, 2);
            this.tlpHeatDetails.Controls.Add(this.txtSteelLadleNo, 3, 1);
            this.tlpHeatDetails.Controls.Add(this.label5, 2, 0);
            this.tlpHeatDetails.Controls.Add(this.txtCasterNo, 3, 2);
            this.tlpHeatDetails.Controls.Add(this.label6, 2, 1);
            this.tlpHeatDetails.Controls.Add(this.label3, 4, 0);
            this.tlpHeatDetails.Controls.Add(this.label4, 4, 1);
            this.tlpHeatDetails.Controls.Add(this.txtGrade1, 5, 0);
            this.tlpHeatDetails.Controls.Add(this.txtGrade2, 5, 1);
            this.tlpHeatDetails.Controls.Add(this.label22, 0, 2);
            this.tlpHeatDetails.Controls.Add(this.txtSSUnit, 1, 2);
            this.tlpHeatDetails.Controls.Add(this.label8, 6, 3);
            this.tlpHeatDetails.Controls.Add(this.label7, 6, 2);
            this.tlpHeatDetails.Controls.Add(this.lblCastTime, 6, 1);
            this.tlpHeatDetails.Controls.Add(this.txtCastSpeed, 7, 3);
            this.tlpHeatDetails.Controls.Add(this.txtCastTon, 7, 2);
            this.tlpHeatDetails.Controls.Add(this.txtCastDuration, 7, 1);
            this.tlpHeatDetails.Controls.Add(this.txtIdealCastDuration, 7, 0);
            this.tlpHeatDetails.Controls.Add(this.label9, 6, 0);
            this.tlpHeatDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeatDetails.Location = new System.Drawing.Point(3, 17);
            this.tlpHeatDetails.Name = "tlpHeatDetails";
            this.tlpHeatDetails.RowCount = 5;
            this.tlpHeatDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHeatDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHeatDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHeatDetails.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpHeatDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHeatDetails.Size = new System.Drawing.Size(597, 105);
            this.tlpHeatDetails.TabIndex = 5;
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
            // txtHeatNumber
            // 
            this.txtHeatNumber.BackColor = System.Drawing.SystemColors.Window;
            this.txtHeatNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeatNumber.Location = new System.Drawing.Point(96, 3);
            this.txtHeatNumber.Name = "txtHeatNumber";
            this.txtHeatNumber.ReadOnly = true;
            this.txtHeatNumber.Size = new System.Drawing.Size(60, 20);
            this.txtHeatNumber.TabIndex = 7;
            // 
            // txtProgramNo
            // 
            this.txtProgramNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtProgramNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramNo.Location = new System.Drawing.Point(96, 29);
            this.txtProgramNo.Name = "txtProgramNo";
            this.txtProgramNo.ReadOnly = true;
            this.txtProgramNo.Size = new System.Drawing.Size(60, 20);
            this.txtProgramNo.TabIndex = 8;
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
            // txtVesselNo
            // 
            this.txtVesselNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtVesselNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVesselNo.Location = new System.Drawing.Point(247, 3);
            this.txtVesselNo.Name = "txtVesselNo";
            this.txtVesselNo.ReadOnly = true;
            this.txtVesselNo.Size = new System.Drawing.Size(60, 20);
            this.txtVesselNo.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(162, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 26);
            this.label10.TabIndex = 6;
            this.label10.Text = "Caster Number";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWidth
            // 
            this.txtWidth.BackColor = System.Drawing.SystemColors.Window;
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(364, 55);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(60, 20);
            this.txtWidth.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(313, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 26);
            this.label11.TabIndex = 45;
            this.label11.Text = "Width";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSteelLadleNo
            // 
            this.txtSteelLadleNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtSteelLadleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSteelLadleNo.Location = new System.Drawing.Point(247, 29);
            this.txtSteelLadleNo.Name = "txtSteelLadleNo";
            this.txtSteelLadleNo.ReadOnly = true;
            this.txtSteelLadleNo.Size = new System.Drawing.Size(60, 20);
            this.txtSteelLadleNo.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(162, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "Vessel Number";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCasterNo
            // 
            this.txtCasterNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCasterNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCasterNo.Location = new System.Drawing.Point(247, 55);
            this.txtCasterNo.Name = "txtCasterNo";
            this.txtCasterNo.ReadOnly = true;
            this.txtCasterNo.Size = new System.Drawing.Size(60, 20);
            this.txtCasterNo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Steel Ladle No.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(313, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Grade 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(313, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grade 2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGrade1
            // 
            this.txtGrade1.BackColor = System.Drawing.SystemColors.Window;
            this.txtGrade1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrade1.Location = new System.Drawing.Point(364, 3);
            this.txtGrade1.Name = "txtGrade1";
            this.txtGrade1.ReadOnly = true;
            this.txtGrade1.Size = new System.Drawing.Size(60, 20);
            this.txtGrade1.TabIndex = 9;
            // 
            // txtGrade2
            // 
            this.txtGrade2.BackColor = System.Drawing.SystemColors.Window;
            this.txtGrade2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrade2.Location = new System.Drawing.Point(364, 29);
            this.txtGrade2.Name = "txtGrade2";
            this.txtGrade2.ReadOnly = true;
            this.txtGrade2.Size = new System.Drawing.Size(60, 20);
            this.txtGrade2.TabIndex = 10;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 26);
            this.label22.TabIndex = 43;
            this.label22.Text = "SS Unit";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSSUnit
            // 
            this.txtSSUnit.BackColor = System.Drawing.SystemColors.Window;
            this.txtSSUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSSUnit.Location = new System.Drawing.Point(96, 55);
            this.txtSSUnit.Name = "txtSSUnit";
            this.txtSSUnit.ReadOnly = true;
            this.txtSSUnit.Size = new System.Drawing.Size(60, 20);
            this.txtSSUnit.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(430, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 26);
            this.label8.TabIndex = 49;
            this.label8.Text = "Speed m/min";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(430, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 26);
            this.label7.TabIndex = 47;
            this.label7.Text = "Cast T/min";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCastTime
            // 
            this.lblCastTime.AutoSize = true;
            this.lblCastTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCastTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCastTime.Location = new System.Drawing.Point(430, 26);
            this.lblCastTime.Name = "lblCastTime";
            this.lblCastTime.Size = new System.Drawing.Size(100, 26);
            this.lblCastTime.TabIndex = 6;
            this.lblCastTime.Text = "Plan Cast Duration";
            this.lblCastTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCastSpeed
            // 
            this.txtCastSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.txtCastSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCastSpeed.Location = new System.Drawing.Point(536, 81);
            this.txtCastSpeed.Name = "txtCastSpeed";
            this.txtCastSpeed.ReadOnly = true;
            this.txtCastSpeed.Size = new System.Drawing.Size(60, 20);
            this.txtCastSpeed.TabIndex = 50;
            // 
            // txtCastTon
            // 
            this.txtCastTon.BackColor = System.Drawing.SystemColors.Window;
            this.txtCastTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCastTon.Location = new System.Drawing.Point(536, 55);
            this.txtCastTon.Name = "txtCastTon";
            this.txtCastTon.ReadOnly = true;
            this.txtCastTon.Size = new System.Drawing.Size(60, 20);
            this.txtCastTon.TabIndex = 48;
            // 
            // txtCastDuration
            // 
            this.txtCastDuration.BackColor = System.Drawing.SystemColors.Window;
            this.txtCastDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCastDuration.Location = new System.Drawing.Point(536, 29);
            this.txtCastDuration.Name = "txtCastDuration";
            this.txtCastDuration.ReadOnly = true;
            this.txtCastDuration.Size = new System.Drawing.Size(60, 20);
            this.txtCastDuration.TabIndex = 19;
            // 
            // txtIdealCastDuration
            // 
            this.txtIdealCastDuration.BackColor = System.Drawing.SystemColors.Window;
            this.txtIdealCastDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdealCastDuration.Location = new System.Drawing.Point(536, 3);
            this.txtIdealCastDuration.Name = "txtIdealCastDuration";
            this.txtIdealCastDuration.ReadOnly = true;
            this.txtIdealCastDuration.Size = new System.Drawing.Size(60, 20);
            this.txtIdealCastDuration.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(430, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 26);
            this.label9.TabIndex = 51;
            this.label9.Text = "Ideal Cast Duration";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPlanNavi
            // 
            this.pnlPlanNavi.Controls.Add(this.grpPlan);
            this.pnlPlanNavi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlanNavi.Location = new System.Drawing.Point(3, 3);
            this.pnlPlanNavi.Name = "pnlPlanNavi";
            this.pnlPlanNavi.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlPlanNavi.Size = new System.Drawing.Size(615, 53);
            this.pnlPlanNavi.TabIndex = 9;
            // 
            // grpPlan
            // 
            this.grpPlan.Controls.Add(this.btnNextPlan);
            this.grpPlan.Controls.Add(this.cmboPlanDTs);
            this.grpPlan.Controls.Add(this.btnPreviousPlan);
            this.grpPlan.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpPlan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlan.Location = new System.Drawing.Point(0, 0);
            this.grpPlan.Name = "grpPlan";
            this.grpPlan.Size = new System.Drawing.Size(203, 50);
            this.grpPlan.TabIndex = 9;
            this.grpPlan.TabStop = false;
            this.grpPlan.Text = "Plan Navigation";
            // 
            // btnNextPlan
            // 
            this.btnNextPlan.AutoSize = true;
            this.btnNextPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPlan.FlatAppearance.BorderSize = 0;
            this.btnNextPlan.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnNextPlan.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnNextPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPlan.Image")));
            this.btnNextPlan.Location = new System.Drawing.Point(169, 19);
            this.btnNextPlan.Name = "btnNextPlan";
            this.btnNextPlan.Size = new System.Drawing.Size(26, 22);
            this.btnNextPlan.TabIndex = 2;
            this.btnNextPlan.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNextPlan.UseVisualStyleBackColor = true;
            this.btnNextPlan.EnabledChanged += new System.EventHandler(this.btnNextPlan_EnabledChanged);
            this.btnNextPlan.Click += new System.EventHandler(this.btnNextPlan_Click);
            // 
            // cmboPlanDTs
            // 
            this.cmboPlanDTs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboPlanDTs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboPlanDTs.FormattingEnabled = true;
            this.cmboPlanDTs.Location = new System.Drawing.Point(34, 21);
            this.cmboPlanDTs.Name = "cmboPlanDTs";
            this.cmboPlanDTs.Size = new System.Drawing.Size(135, 21);
            this.cmboPlanDTs.TabIndex = 1;
            this.cmboPlanDTs.SelectedIndexChanged += new System.EventHandler(this.cmboPlanDTs_SelectedIndexChanged);
            // 
            // btnPreviousPlan
            // 
            this.btnPreviousPlan.AutoSize = true;
            this.btnPreviousPlan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPlan.FlatAppearance.BorderSize = 0;
            this.btnPreviousPlan.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPreviousPlan.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnPreviousPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousPlan.Image")));
            this.btnPreviousPlan.Location = new System.Drawing.Point(8, 19);
            this.btnPreviousPlan.Name = "btnPreviousPlan";
            this.btnPreviousPlan.Size = new System.Drawing.Size(26, 22);
            this.btnPreviousPlan.TabIndex = 0;
            this.btnPreviousPlan.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPreviousPlan.UseVisualStyleBackColor = true;
            this.btnPreviousPlan.EnabledChanged += new System.EventHandler(this.btnPreviousPlan_EnabledChanged);
            this.btnPreviousPlan.Click += new System.EventHandler(this.btnPreviousPlan_Click);
            // 
            // PlanningDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.grpPlanning);
            this.Controls.Add(this.pnlPlanNavi);
            this.Name = "PlanningDetails";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(621, 423);
            this.Load += new System.EventHandler(this.PlanningDetails_Load);
            this.grpPlanning.ResumeLayout(false);
            this.pnlGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.pnlPlanTimes.ResumeLayout(false);
            this.grpTimes.ResumeLayout(false);
            this.tlpPlanTimes.ResumeLayout(false);
            this.tlpPlanTimes.PerformLayout();
            this.grpHeatDetails.ResumeLayout(false);
            this.tlpHeatDetails.ResumeLayout(false);
            this.tlpHeatDetails.PerformLayout();
            this.pnlPlanNavi.ResumeLayout(false);
            this.grpPlan.ResumeLayout(false);
            this.grpPlan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPlanning;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.GroupBox grpTimes;
        private System.Windows.Forms.TableLayoutPanel tlpPlanTimes;
        private System.Windows.Forms.TextBox txtCasterEnd;
        private System.Windows.Forms.TextBox txtCasterStart;
        private System.Windows.Forms.TextBox txtPourStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtDesulphStart;
        private System.Windows.Forms.TextBox txtDesulphEnd;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtPourEnd;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtVesselStart;
        private System.Windows.Forms.TextBox txtVesselEnd;
        private System.Windows.Forms.TextBox txtSSStart;
        private System.Windows.Forms.TextBox txtSSEnd;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TableLayoutPanel tlpHeatDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHeatNumber;
        private System.Windows.Forms.TextBox txtProgramNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGrade1;
        private System.Windows.Forms.TextBox txtGrade2;
        private System.Windows.Forms.TextBox txtVesselNo;
        private System.Windows.Forms.TextBox txtSteelLadleNo;
        private System.Windows.Forms.TextBox txtSSUnit;
        private System.Windows.Forms.TextBox txtCasterNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCastTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCastDuration;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtCastSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCastTon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpHeatDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdealCastDuration;
        private System.Windows.Forms.Panel pnlGrids;
        private System.Windows.Forms.Panel pnlPlanTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.Panel pnlPlanNavi;
        private System.Windows.Forms.GroupBox grpPlan;
        private System.Windows.Forms.Button btnNextPlan;
        private System.Windows.Forms.ComboBox cmboPlanDTs;
        private System.Windows.Forms.Button btnPreviousPlan;


    }
}
