namespace Elvis.UserControls.HeatDetails
{
    partial class SlabsUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlFailures = new System.Windows.Forms.Panel();
            this.grpFailures = new System.Windows.Forms.GroupBox();
            this.dgvFailures = new System.Windows.Forms.DataGridView();
            this.FailureType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeSlabNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeReason1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeReason2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeReason3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlSlabs = new System.Windows.Forms.Panel();
            this.grpSlabs = new System.Windows.Forms.GroupBox();
            this.dgvSlabs = new System.Windows.Forms.DataGridView();
            this.SlabNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Strand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manual = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MadeToGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMain.SuspendLayout();
            this.pnlFailures.SuspendLayout();
            this.grpFailures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFailures)).BeginInit();
            this.pnlSlabs.SuspendLayout();
            this.grpSlabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlabs)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitter2);
            this.pnlMain.Controls.Add(this.pnlFailures);
            this.pnlMain.Controls.Add(this.splitter1);
            this.pnlMain.Controls.Add(this.pnlSlabs);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(1218, 666);
            this.pnlMain.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(985, 371);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 289);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // pnlFailures
            // 
            this.pnlFailures.Controls.Add(this.grpFailures);
            this.pnlFailures.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFailures.Location = new System.Drawing.Point(6, 371);
            this.pnlFailures.Name = "pnlFailures";
            this.pnlFailures.Size = new System.Drawing.Size(979, 289);
            this.pnlFailures.TabIndex = 3;
            // 
            // grpFailures
            // 
            this.grpFailures.Controls.Add(this.dgvFailures);
            this.grpFailures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFailures.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFailures.Location = new System.Drawing.Point(0, 0);
            this.grpFailures.Name = "grpFailures";
            this.grpFailures.Padding = new System.Windows.Forms.Padding(6);
            this.grpFailures.Size = new System.Drawing.Size(979, 289);
            this.grpFailures.TabIndex = 2;
            this.grpFailures.TabStop = false;
            this.grpFailures.Text = "Failures";
            // 
            // dgvFailures
            // 
            this.dgvFailures.AllowUserToAddRows = false;
            this.dgvFailures.AllowUserToDeleteRows = false;
            this.dgvFailures.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFailures.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFailures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFailures.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFailures.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvFailures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFailures.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvFailures.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFailures.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFailures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FailureType,
            this.GradeSlabNumber,
            this.GradeReason1,
            this.GradeReason2,
            this.GradeReason3,
            this.GradeComment,
            this.GradeCreated});
            this.dgvFailures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFailures.EnableHeadersVisualStyles = false;
            this.dgvFailures.GridColor = System.Drawing.Color.DimGray;
            this.dgvFailures.Location = new System.Drawing.Point(6, 20);
            this.dgvFailures.Name = "dgvFailures";
            this.dgvFailures.ReadOnly = true;
            this.dgvFailures.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFailures.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvFailures.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFailures.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvFailures.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvFailures.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvFailures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFailures.Size = new System.Drawing.Size(967, 263);
            this.dgvFailures.TabIndex = 1;
            this.dgvFailures.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFailures_DataBindingComplete);
            // 
            // FailureType
            // 
            this.FailureType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FailureType.DataPropertyName = "FailureType";
            dataGridViewCellStyle3.NullValue = "-";
            this.FailureType.DefaultCellStyle = dataGridViewCellStyle3;
            this.FailureType.HeaderText = "Failure Type";
            this.FailureType.Name = "FailureType";
            this.FailureType.ReadOnly = true;
            this.FailureType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GradeSlabNumber
            // 
            this.GradeSlabNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradeSlabNumber.DataPropertyName = "SlabNumber";
            dataGridViewCellStyle4.NullValue = "-";
            this.GradeSlabNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.GradeSlabNumber.HeaderText = "Slab Number";
            this.GradeSlabNumber.Name = "GradeSlabNumber";
            this.GradeSlabNumber.ReadOnly = true;
            this.GradeSlabNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GradeReason1
            // 
            this.GradeReason1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradeReason1.DataPropertyName = "Reason1";
            dataGridViewCellStyle5.NullValue = "-";
            this.GradeReason1.DefaultCellStyle = dataGridViewCellStyle5;
            this.GradeReason1.HeaderText = "Reason 1";
            this.GradeReason1.MinimumWidth = 50;
            this.GradeReason1.Name = "GradeReason1";
            this.GradeReason1.ReadOnly = true;
            this.GradeReason1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GradeReason2
            // 
            this.GradeReason2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradeReason2.DataPropertyName = "Reason2";
            dataGridViewCellStyle6.NullValue = "-";
            this.GradeReason2.DefaultCellStyle = dataGridViewCellStyle6;
            this.GradeReason2.HeaderText = "Reason 2";
            this.GradeReason2.Name = "GradeReason2";
            this.GradeReason2.ReadOnly = true;
            this.GradeReason2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GradeReason3
            // 
            this.GradeReason3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradeReason3.DataPropertyName = "Reason3";
            dataGridViewCellStyle7.NullValue = "-";
            this.GradeReason3.DefaultCellStyle = dataGridViewCellStyle7;
            this.GradeReason3.HeaderText = "Reason 3";
            this.GradeReason3.Name = "GradeReason3";
            this.GradeReason3.ReadOnly = true;
            this.GradeReason3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GradeComment
            // 
            this.GradeComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradeComment.DataPropertyName = "Comment";
            dataGridViewCellStyle8.NullValue = "-";
            this.GradeComment.DefaultCellStyle = dataGridViewCellStyle8;
            this.GradeComment.HeaderText = "Comment";
            this.GradeComment.Name = "GradeComment";
            this.GradeComment.ReadOnly = true;
            this.GradeComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GradeCreated
            // 
            this.GradeCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradeCreated.DataPropertyName = "Created";
            dataGridViewCellStyle9.Format = "g";
            dataGridViewCellStyle9.NullValue = null;
            this.GradeCreated.DefaultCellStyle = dataGridViewCellStyle9;
            this.GradeCreated.HeaderText = "Created";
            this.GradeCreated.Name = "GradeCreated";
            this.GradeCreated.ReadOnly = true;
            this.GradeCreated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GradeCreated.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(6, 366);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1206, 5);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pnlSlabs
            // 
            this.pnlSlabs.Controls.Add(this.grpSlabs);
            this.pnlSlabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSlabs.Location = new System.Drawing.Point(6, 6);
            this.pnlSlabs.Name = "pnlSlabs";
            this.pnlSlabs.Size = new System.Drawing.Size(1206, 360);
            this.pnlSlabs.TabIndex = 1;
            // 
            // grpSlabs
            // 
            this.grpSlabs.Controls.Add(this.dgvSlabs);
            this.grpSlabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSlabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSlabs.Location = new System.Drawing.Point(0, 0);
            this.grpSlabs.Name = "grpSlabs";
            this.grpSlabs.Padding = new System.Windows.Forms.Padding(6);
            this.grpSlabs.Size = new System.Drawing.Size(1206, 360);
            this.grpSlabs.TabIndex = 2;
            this.grpSlabs.TabStop = false;
            this.grpSlabs.Text = "Slabs";
            // 
            // dgvSlabs
            // 
            this.dgvSlabs.AllowUserToAddRows = false;
            this.dgvSlabs.AllowUserToDeleteRows = false;
            this.dgvSlabs.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSlabs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSlabs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSlabs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSlabs.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvSlabs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSlabs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSlabs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSlabs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSlabs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlabNumber,
            this.Strand,
            this.Position,
            this.StartWidth,
            this.EndWidth,
            this.Time,
            this.Weight,
            this.Length,
            this.OrderGrade,
            this.GradeMade,
            this.Manual,
            this.DGReason,
            this.MadeToGrade});
            this.dgvSlabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSlabs.EnableHeadersVisualStyles = false;
            this.dgvSlabs.GridColor = System.Drawing.Color.DimGray;
            this.dgvSlabs.Location = new System.Drawing.Point(6, 20);
            this.dgvSlabs.Name = "dgvSlabs";
            this.dgvSlabs.ReadOnly = true;
            this.dgvSlabs.RowHeadersVisible = false;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSlabs.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvSlabs.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSlabs.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSlabs.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvSlabs.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvSlabs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSlabs.Size = new System.Drawing.Size(1194, 334);
            this.dgvSlabs.TabIndex = 1;
            this.dgvSlabs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSlabs_CellFormatting);
            this.dgvSlabs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSlabs_DataBindingComplete);
            // 
            // SlabNumber
            // 
            this.SlabNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SlabNumber.DataPropertyName = "CAST_SLAB_NUMBER";
            this.SlabNumber.HeaderText = "Slab Number";
            this.SlabNumber.Name = "SlabNumber";
            this.SlabNumber.ReadOnly = true;
            this.SlabNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Strand
            // 
            this.Strand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Strand.DataPropertyName = "STRAND_NUMBER";
            this.Strand.HeaderText = "Strand";
            this.Strand.MinimumWidth = 50;
            this.Strand.Name = "Strand";
            this.Strand.ReadOnly = true;
            this.Strand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Position
            // 
            this.Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Position.DataPropertyName = "SLAB_POSITION";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StartWidth
            // 
            this.StartWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StartWidth.DataPropertyName = "WIDTH_MADE_FIRST_SEGMENT";
            this.StartWidth.HeaderText = "Start Width";
            this.StartWidth.Name = "StartWidth";
            this.StartWidth.ReadOnly = true;
            this.StartWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EndWidth
            // 
            this.EndWidth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndWidth.DataPropertyName = "WIDTH_MADE_LAST_SEGMENT";
            this.EndWidth.HeaderText = "End Width";
            this.EndWidth.Name = "EndWidth";
            this.EndWidth.ReadOnly = true;
            this.EndWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Time.DataPropertyName = "SLAB_CUT_TIMESTAMP";
            dataGridViewCellStyle13.Format = "T";
            dataGridViewCellStyle13.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle13;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Weight
            // 
            this.Weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Weight.DataPropertyName = "WEIGHT";
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.Weight.DefaultCellStyle = dataGridViewCellStyle14;
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            this.Weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Length
            // 
            this.Length.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Length.DataPropertyName = "LENGTH_MADE";
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.Length.DefaultCellStyle = dataGridViewCellStyle15;
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            this.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OrderGrade
            // 
            this.OrderGrade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderGrade.DataPropertyName = "GRADE_ORDERED";
            this.OrderGrade.HeaderText = "Grade Ordered";
            this.OrderGrade.Name = "OrderGrade";
            this.OrderGrade.ReadOnly = true;
            this.OrderGrade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GradeMade
            // 
            this.GradeMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GradeMade.DataPropertyName = "GRADE_MADE";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GradeMade.DefaultCellStyle = dataGridViewCellStyle16;
            this.GradeMade.HeaderText = "Grade Made";
            this.GradeMade.Name = "GradeMade";
            this.GradeMade.ReadOnly = true;
            this.GradeMade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Manual
            // 
            this.Manual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Manual.DataPropertyName = "MANUALLY_GRADED";
            this.Manual.HeaderText = "Manual";
            this.Manual.Name = "Manual";
            this.Manual.ReadOnly = true;
            // 
            // DGReason
            // 
            this.DGReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGReason.DataPropertyName = "COMMENT_TEXT";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGReason.DefaultCellStyle = dataGridViewCellStyle17;
            this.DGReason.HeaderText = "DG Reason";
            this.DGReason.Name = "DGReason";
            this.DGReason.ReadOnly = true;
            this.DGReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGReason.Visible = false;
            // 
            // MadeToGrade
            // 
            this.MadeToGrade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MadeToGrade.DataPropertyName = "MADE_TO_GRADE";
            this.MadeToGrade.HeaderText = "MadeToGrade";
            this.MadeToGrade.Name = "MadeToGrade";
            this.MadeToGrade.ReadOnly = true;
            this.MadeToGrade.Visible = false;
            // 
            // SlabsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlMain);
            this.Name = "SlabsUserControl";
            this.Size = new System.Drawing.Size(1218, 666);
            this.pnlMain.ResumeLayout(false);
            this.pnlFailures.ResumeLayout(false);
            this.grpFailures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFailures)).EndInit();
            this.pnlSlabs.ResumeLayout(false);
            this.grpSlabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlabs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSlabs;
        private System.Windows.Forms.DataGridView dgvSlabs;
        private System.Windows.Forms.GroupBox grpSlabs;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlFailures;
        private System.Windows.Forms.GroupBox grpFailures;
        private System.Windows.Forms.DataGridView dgvFailures;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FailureType;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeSlabNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeReason1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeReason2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeReason3;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlabNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Strand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeMade;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Manual;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn MadeToGrade;

    }
}
