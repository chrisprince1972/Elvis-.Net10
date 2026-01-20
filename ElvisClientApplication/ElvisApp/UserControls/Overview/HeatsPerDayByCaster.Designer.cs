namespace Elvis.UserControls.HeatDetails
{
    partial class HeatsPerDayByCaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.labelPanel = new System.Windows.Forms.Panel();
            this.actuallyProducedLabel = new System.Windows.Forms.Label();
            this.planningDeviationsLabel = new System.Windows.Forms.Label();
            this.plannedHeatsLabel = new System.Windows.Forms.Label();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.heatsDataGridView = new System.Windows.Forms.DataGridView();
            this.dayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc1PlannedCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc2PlannedCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc3PlannedCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlannedCountTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc1DeviationsCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc2DeviationsCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc3DeviationsCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviationsCountTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc1ActualCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc2ActualCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc3ActualCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualCountTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalsPanel = new System.Windows.Forms.Panel();
            this.totalsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.totalsLabel = new System.Windows.Forms.Label();
            this.cc1PlannedCountLabel = new System.Windows.Forms.Label();
            this.cc2PlannedCountLabel = new System.Windows.Forms.Label();
            this.cc3PlannedCountLabel = new System.Windows.Forms.Label();
            this.plannedCountTotalLabel = new System.Windows.Forms.Label();
            this.cc1DeviationsCountLabel = new System.Windows.Forms.Label();
            this.cc2DeviationsCountLabel = new System.Windows.Forms.Label();
            this.cc3DeviationsCountLabel = new System.Windows.Forms.Label();
            this.deviationsCountTotalLabel = new System.Windows.Forms.Label();
            this.cc1ActualCountLabel = new System.Windows.Forms.Label();
            this.cc2ActualCountLabel = new System.Windows.Forms.Label();
            this.cc3ActualCountLabel = new System.Windows.Forms.Label();
            this.actualCountTotalLabel = new System.Windows.Forms.Label();
            this.labelPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatsDataGridView)).BeginInit();
            this.totalsPanel.SuspendLayout();
            this.totalsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPanel
            // 
            this.labelPanel.Controls.Add(this.actuallyProducedLabel);
            this.labelPanel.Controls.Add(this.planningDeviationsLabel);
            this.labelPanel.Controls.Add(this.plannedHeatsLabel);
            this.labelPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel.Location = new System.Drawing.Point(0, 0);
            this.labelPanel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(628, 22);
            this.labelPanel.TabIndex = 0;
            // 
            // actuallyProducedLabel
            // 
            this.actuallyProducedLabel.AutoSize = true;
            this.actuallyProducedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actuallyProducedLabel.Location = new System.Drawing.Point(452, 8);
            this.actuallyProducedLabel.Name = "actuallyProducedLabel";
            this.actuallyProducedLabel.Size = new System.Drawing.Size(110, 13);
            this.actuallyProducedLabel.TabIndex = 2;
            this.actuallyProducedLabel.Text = "Actually Produced";
            // 
            // planningDeviationsLabel
            // 
            this.planningDeviationsLabel.AutoSize = true;
            this.planningDeviationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planningDeviationsLabel.Location = new System.Drawing.Point(288, 8);
            this.planningDeviationsLabel.Name = "planningDeviationsLabel";
            this.planningDeviationsLabel.Size = new System.Drawing.Size(120, 13);
            this.planningDeviationsLabel.TabIndex = 1;
            this.planningDeviationsLabel.Text = "Planning Deviations";
            // 
            // plannedHeatsLabel
            // 
            this.plannedHeatsLabel.AutoSize = true;
            this.plannedHeatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plannedHeatsLabel.Location = new System.Drawing.Point(124, 8);
            this.plannedHeatsLabel.Name = "plannedHeatsLabel";
            this.plannedHeatsLabel.Size = new System.Drawing.Size(90, 13);
            this.plannedHeatsLabel.TabIndex = 0;
            this.plannedHeatsLabel.Text = "Planned Heats";
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.heatsDataGridView);
            this.dataPanel.Controls.Add(this.totalsPanel);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 22);
            this.dataPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Padding = new System.Windows.Forms.Padding(6);
            this.dataPanel.Size = new System.Drawing.Size(628, 474);
            this.dataPanel.TabIndex = 1;
            // 
            // heatsDataGridView
            // 
            this.heatsDataGridView.AllowUserToAddRows = false;
            this.heatsDataGridView.AllowUserToDeleteRows = false;
            this.heatsDataGridView.AllowUserToResizeColumns = false;
            this.heatsDataGridView.AllowUserToResizeRows = false;
            this.heatsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.heatsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.heatsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.heatsDataGridView.ColumnHeadersHeight = 25;
            this.heatsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.heatsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dayColumn,
            this.shiftColumn,
            this.Cc1PlannedCountColumn,
            this.Cc2PlannedCountColumn,
            this.Cc3PlannedCountColumn,
            this.PlannedCountTotalColumn,
            this.Cc1DeviationsCountColumn,
            this.Cc2DeviationsCountColumn,
            this.Cc3DeviationsCountColumn,
            this.DeviationsCountTotalColumn,
            this.Cc1ActualCountColumn,
            this.Cc2ActualCountColumn,
            this.Cc3ActualCountColumn,
            this.ActualCountTotalColumn});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.heatsDataGridView.DefaultCellStyle = dataGridViewCellStyle14;
            this.heatsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heatsDataGridView.EnableHeadersVisualStyles = false;
            this.heatsDataGridView.GridColor = System.Drawing.Color.DimGray;
            this.heatsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.heatsDataGridView.MultiSelect = false;
            this.heatsDataGridView.Name = "heatsDataGridView";
            this.heatsDataGridView.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.heatsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.heatsDataGridView.RowHeadersVisible = false;
            this.heatsDataGridView.RowTemplate.ReadOnly = true;
            this.heatsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.heatsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.heatsDataGridView.ShowEditingIcon = false;
            this.heatsDataGridView.Size = new System.Drawing.Size(616, 433);
            this.heatsDataGridView.TabIndex = 0;
            // 
            // dayColumn
            // 
            this.dayColumn.DataPropertyName = "DisplayDay";
            this.dayColumn.Frozen = true;
            this.dayColumn.HeaderText = "Day";
            this.dayColumn.Name = "dayColumn";
            this.dayColumn.ReadOnly = true;
            this.dayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dayColumn.Width = 40;
            // 
            // shiftColumn
            // 
            this.shiftColumn.DataPropertyName = "DisplayShift";
            this.shiftColumn.DividerWidth = 3;
            this.shiftColumn.HeaderText = "Shift";
            this.shiftColumn.Name = "shiftColumn";
            this.shiftColumn.ReadOnly = true;
            this.shiftColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shiftColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.shiftColumn.Width = 80;
            // 
            // Cc1PlannedCountColumn
            // 
            this.Cc1PlannedCountColumn.DataPropertyName = "CC1PlannedCount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc1PlannedCountColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cc1PlannedCountColumn.HeaderText = "CC1";
            this.Cc1PlannedCountColumn.Name = "Cc1PlannedCountColumn";
            this.Cc1PlannedCountColumn.ReadOnly = true;
            this.Cc1PlannedCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc1PlannedCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc1PlannedCountColumn.Width = 40;
            // 
            // Cc2PlannedCountColumn
            // 
            this.Cc2PlannedCountColumn.DataPropertyName = "CC2PlannedCount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc2PlannedCountColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cc2PlannedCountColumn.HeaderText = "CC2";
            this.Cc2PlannedCountColumn.Name = "Cc2PlannedCountColumn";
            this.Cc2PlannedCountColumn.ReadOnly = true;
            this.Cc2PlannedCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc2PlannedCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc2PlannedCountColumn.Width = 40;
            // 
            // Cc3PlannedCountColumn
            // 
            this.Cc3PlannedCountColumn.DataPropertyName = "CC3PlannedCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc3PlannedCountColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cc3PlannedCountColumn.HeaderText = "CC3";
            this.Cc3PlannedCountColumn.Name = "Cc3PlannedCountColumn";
            this.Cc3PlannedCountColumn.ReadOnly = true;
            this.Cc3PlannedCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc3PlannedCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc3PlannedCountColumn.Width = 40;
            // 
            // PlannedCountTotalColumn
            // 
            this.PlannedCountTotalColumn.DataPropertyName = "PlannedCountTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PlannedCountTotalColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.PlannedCountTotalColumn.DividerWidth = 3;
            this.PlannedCountTotalColumn.HeaderText = "Total";
            this.PlannedCountTotalColumn.Name = "PlannedCountTotalColumn";
            this.PlannedCountTotalColumn.ReadOnly = true;
            this.PlannedCountTotalColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PlannedCountTotalColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlannedCountTotalColumn.Width = 44;
            // 
            // Cc1DeviationsCountColumn
            // 
            this.Cc1DeviationsCountColumn.DataPropertyName = "CC1DeviationsCount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc1DeviationsCountColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.Cc1DeviationsCountColumn.HeaderText = "CC1";
            this.Cc1DeviationsCountColumn.Name = "Cc1DeviationsCountColumn";
            this.Cc1DeviationsCountColumn.ReadOnly = true;
            this.Cc1DeviationsCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc1DeviationsCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc1DeviationsCountColumn.Width = 40;
            // 
            // Cc2DeviationsCountColumn
            // 
            this.Cc2DeviationsCountColumn.DataPropertyName = "CC2DeviationsCount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc2DeviationsCountColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.Cc2DeviationsCountColumn.HeaderText = "CC2";
            this.Cc2DeviationsCountColumn.Name = "Cc2DeviationsCountColumn";
            this.Cc2DeviationsCountColumn.ReadOnly = true;
            this.Cc2DeviationsCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc2DeviationsCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc2DeviationsCountColumn.Width = 40;
            // 
            // Cc3DeviationsCountColumn
            // 
            this.Cc3DeviationsCountColumn.DataPropertyName = "CC3DeviationsCount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc3DeviationsCountColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.Cc3DeviationsCountColumn.HeaderText = "CC3";
            this.Cc3DeviationsCountColumn.Name = "Cc3DeviationsCountColumn";
            this.Cc3DeviationsCountColumn.ReadOnly = true;
            this.Cc3DeviationsCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc3DeviationsCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc3DeviationsCountColumn.Width = 40;
            // 
            // DeviationsCountTotalColumn
            // 
            this.DeviationsCountTotalColumn.DataPropertyName = "DeviationsCountTotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DeviationsCountTotalColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.DeviationsCountTotalColumn.DividerWidth = 3;
            this.DeviationsCountTotalColumn.HeaderText = "Total";
            this.DeviationsCountTotalColumn.Name = "DeviationsCountTotalColumn";
            this.DeviationsCountTotalColumn.ReadOnly = true;
            this.DeviationsCountTotalColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeviationsCountTotalColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeviationsCountTotalColumn.Width = 44;
            // 
            // Cc1ActualCountColumn
            // 
            this.Cc1ActualCountColumn.DataPropertyName = "CC1ActualCount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc1ActualCountColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.Cc1ActualCountColumn.HeaderText = "CC1";
            this.Cc1ActualCountColumn.Name = "Cc1ActualCountColumn";
            this.Cc1ActualCountColumn.ReadOnly = true;
            this.Cc1ActualCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc1ActualCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc1ActualCountColumn.Width = 40;
            // 
            // Cc2ActualCountColumn
            // 
            this.Cc2ActualCountColumn.DataPropertyName = "CC2ActualCount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc2ActualCountColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.Cc2ActualCountColumn.HeaderText = "CC2";
            this.Cc2ActualCountColumn.Name = "Cc2ActualCountColumn";
            this.Cc2ActualCountColumn.ReadOnly = true;
            this.Cc2ActualCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc2ActualCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc2ActualCountColumn.Width = 40;
            // 
            // Cc3ActualCountColumn
            // 
            this.Cc3ActualCountColumn.DataPropertyName = "CC3ActualCount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cc3ActualCountColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.Cc3ActualCountColumn.HeaderText = "CC3";
            this.Cc3ActualCountColumn.Name = "Cc3ActualCountColumn";
            this.Cc3ActualCountColumn.ReadOnly = true;
            this.Cc3ActualCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc3ActualCountColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cc3ActualCountColumn.Width = 40;
            // 
            // ActualCountTotalColumn
            // 
            this.ActualCountTotalColumn.DataPropertyName = "ActualCountTotal";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ActualCountTotalColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.ActualCountTotalColumn.HeaderText = "Total";
            this.ActualCountTotalColumn.Name = "ActualCountTotalColumn";
            this.ActualCountTotalColumn.ReadOnly = true;
            this.ActualCountTotalColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ActualCountTotalColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ActualCountTotalColumn.Width = 45;
            // 
            // totalsPanel
            // 
            this.totalsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.totalsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalsPanel.Controls.Add(this.totalsTableLayoutPanel);
            this.totalsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totalsPanel.Location = new System.Drawing.Point(6, 439);
            this.totalsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.totalsPanel.Name = "totalsPanel";
            this.totalsPanel.Size = new System.Drawing.Size(616, 29);
            this.totalsPanel.TabIndex = 1;
            // 
            // totalsTableLayoutPanel
            // 
            this.totalsTableLayoutPanel.ColumnCount = 13;
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.totalsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.totalsTableLayoutPanel.Controls.Add(this.totalsLabel, 0, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc1PlannedCountLabel, 1, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc2PlannedCountLabel, 2, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc3PlannedCountLabel, 3, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.plannedCountTotalLabel, 4, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc1DeviationsCountLabel, 5, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc2DeviationsCountLabel, 6, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc3DeviationsCountLabel, 7, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.deviationsCountTotalLabel, 8, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc1ActualCountLabel, 9, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc2ActualCountLabel, 10, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.cc3ActualCountLabel, 11, 0);
            this.totalsTableLayoutPanel.Controls.Add(this.actualCountTotalLabel, 12, 0);
            this.totalsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.totalsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.totalsTableLayoutPanel.Name = "totalsTableLayoutPanel";
            this.totalsTableLayoutPanel.RowCount = 1;
            this.totalsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.totalsTableLayoutPanel.Size = new System.Drawing.Size(614, 27);
            this.totalsTableLayoutPanel.TabIndex = 13;
            this.totalsTableLayoutPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.totalsTableLayoutPanel_CellPaint);
            // 
            // totalsLabel
            // 
            this.totalsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalsLabel.AutoSize = true;
            this.totalsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalsLabel.Location = new System.Drawing.Point(3, 7);
            this.totalsLabel.Name = "totalsLabel";
            this.totalsLabel.Size = new System.Drawing.Size(46, 13);
            this.totalsLabel.TabIndex = 1;
            this.totalsLabel.Text = "Totals:";
            this.totalsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cc1PlannedCountLabel
            // 
            this.cc1PlannedCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc1PlannedCountLabel.AutoSize = true;
            this.cc1PlannedCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc1PlannedCountLabel.Location = new System.Drawing.Point(146, 7);
            this.cc1PlannedCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc1PlannedCountLabel.Name = "cc1PlannedCountLabel";
            this.cc1PlannedCountLabel.Size = new System.Drawing.Size(14, 13);
            this.cc1PlannedCountLabel.TabIndex = 2;
            this.cc1PlannedCountLabel.Text = "1";
            this.cc1PlannedCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc2PlannedCountLabel
            // 
            this.cc2PlannedCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc2PlannedCountLabel.AutoSize = true;
            this.cc2PlannedCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc2PlannedCountLabel.Location = new System.Drawing.Point(186, 7);
            this.cc2PlannedCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc2PlannedCountLabel.Name = "cc2PlannedCountLabel";
            this.cc2PlannedCountLabel.Size = new System.Drawing.Size(14, 13);
            this.cc2PlannedCountLabel.TabIndex = 3;
            this.cc2PlannedCountLabel.Text = "2";
            this.cc2PlannedCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc3PlannedCountLabel
            // 
            this.cc3PlannedCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc3PlannedCountLabel.AutoSize = true;
            this.cc3PlannedCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc3PlannedCountLabel.Location = new System.Drawing.Point(226, 7);
            this.cc3PlannedCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc3PlannedCountLabel.Name = "cc3PlannedCountLabel";
            this.cc3PlannedCountLabel.Size = new System.Drawing.Size(14, 13);
            this.cc3PlannedCountLabel.TabIndex = 4;
            this.cc3PlannedCountLabel.Text = "3";
            this.cc3PlannedCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // plannedCountTotalLabel
            // 
            this.plannedCountTotalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.plannedCountTotalLabel.AutoSize = true;
            this.plannedCountTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plannedCountTotalLabel.Location = new System.Drawing.Point(267, 7);
            this.plannedCountTotalLabel.Margin = new System.Windows.Forms.Padding(3, 0, 4, 0);
            this.plannedCountTotalLabel.Name = "plannedCountTotalLabel";
            this.plannedCountTotalLabel.Size = new System.Drawing.Size(14, 13);
            this.plannedCountTotalLabel.TabIndex = 7;
            this.plannedCountTotalLabel.Text = "4";
            this.plannedCountTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc1DeviationsCountLabel
            // 
            this.cc1DeviationsCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc1DeviationsCountLabel.AutoSize = true;
            this.cc1DeviationsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc1DeviationsCountLabel.Location = new System.Drawing.Point(310, 7);
            this.cc1DeviationsCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc1DeviationsCountLabel.Name = "cc1DeviationsCountLabel";
            this.cc1DeviationsCountLabel.Size = new System.Drawing.Size(14, 13);
            this.cc1DeviationsCountLabel.TabIndex = 13;
            this.cc1DeviationsCountLabel.Text = "5";
            this.cc1DeviationsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc2DeviationsCountLabel
            // 
            this.cc2DeviationsCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc2DeviationsCountLabel.AutoSize = true;
            this.cc2DeviationsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc2DeviationsCountLabel.Location = new System.Drawing.Point(350, 7);
            this.cc2DeviationsCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc2DeviationsCountLabel.Name = "cc2DeviationsCountLabel";
            this.cc2DeviationsCountLabel.Size = new System.Drawing.Size(14, 13);
            this.cc2DeviationsCountLabel.TabIndex = 14;
            this.cc2DeviationsCountLabel.Text = "6";
            this.cc2DeviationsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc3DeviationsCountLabel
            // 
            this.cc3DeviationsCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc3DeviationsCountLabel.AutoSize = true;
            this.cc3DeviationsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc3DeviationsCountLabel.Location = new System.Drawing.Point(390, 7);
            this.cc3DeviationsCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc3DeviationsCountLabel.Name = "cc3DeviationsCountLabel";
            this.cc3DeviationsCountLabel.Size = new System.Drawing.Size(14, 13);
            this.cc3DeviationsCountLabel.TabIndex = 15;
            this.cc3DeviationsCountLabel.Text = "7";
            this.cc3DeviationsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deviationsCountTotalLabel
            // 
            this.deviationsCountTotalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.deviationsCountTotalLabel.AutoSize = true;
            this.deviationsCountTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviationsCountTotalLabel.Location = new System.Drawing.Point(431, 7);
            this.deviationsCountTotalLabel.Margin = new System.Windows.Forms.Padding(3, 0, 4, 0);
            this.deviationsCountTotalLabel.Name = "deviationsCountTotalLabel";
            this.deviationsCountTotalLabel.Size = new System.Drawing.Size(14, 13);
            this.deviationsCountTotalLabel.TabIndex = 16;
            this.deviationsCountTotalLabel.Text = "8";
            this.deviationsCountTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc1ActualCountLabel
            // 
            this.cc1ActualCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc1ActualCountLabel.AutoSize = true;
            this.cc1ActualCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc1ActualCountLabel.Location = new System.Drawing.Point(474, 7);
            this.cc1ActualCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc1ActualCountLabel.Name = "cc1ActualCountLabel";
            this.cc1ActualCountLabel.Size = new System.Drawing.Size(14, 13);
            this.cc1ActualCountLabel.TabIndex = 17;
            this.cc1ActualCountLabel.Text = "9";
            this.cc1ActualCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc2ActualCountLabel
            // 
            this.cc2ActualCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc2ActualCountLabel.AutoSize = true;
            this.cc2ActualCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc2ActualCountLabel.Location = new System.Drawing.Point(507, 7);
            this.cc2ActualCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc2ActualCountLabel.Name = "cc2ActualCountLabel";
            this.cc2ActualCountLabel.Size = new System.Drawing.Size(21, 13);
            this.cc2ActualCountLabel.TabIndex = 18;
            this.cc2ActualCountLabel.Text = "10";
            this.cc2ActualCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cc3ActualCountLabel
            // 
            this.cc3ActualCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cc3ActualCountLabel.AutoSize = true;
            this.cc3ActualCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cc3ActualCountLabel.Location = new System.Drawing.Point(547, 7);
            this.cc3ActualCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.cc3ActualCountLabel.Name = "cc3ActualCountLabel";
            this.cc3ActualCountLabel.Size = new System.Drawing.Size(21, 13);
            this.cc3ActualCountLabel.TabIndex = 19;
            this.cc3ActualCountLabel.Text = "11";
            this.cc3ActualCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // actualCountTotalLabel
            // 
            this.actualCountTotalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.actualCountTotalLabel.AutoSize = true;
            this.actualCountTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualCountTotalLabel.Location = new System.Drawing.Point(593, 7);
            this.actualCountTotalLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.actualCountTotalLabel.Name = "actualCountTotalLabel";
            this.actualCountTotalLabel.Size = new System.Drawing.Size(21, 13);
            this.actualCountTotalLabel.TabIndex = 20;
            this.actualCountTotalLabel.Text = "12";
            this.actualCountTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HeatsPerDayByCaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.labelPanel);
            this.Name = "HeatsPerDayByCaster";
            this.Size = new System.Drawing.Size(628, 496);
            this.labelPanel.ResumeLayout(false);
            this.labelPanel.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heatsDataGridView)).EndInit();
            this.totalsPanel.ResumeLayout(false);
            this.totalsTableLayoutPanel.ResumeLayout(false);
            this.totalsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel labelPanel;
        private System.Windows.Forms.Label actuallyProducedLabel;
        private System.Windows.Forms.Label planningDeviationsLabel;
        private System.Windows.Forms.Label plannedHeatsLabel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.DataGridView heatsDataGridView;
        private System.Windows.Forms.Panel totalsPanel;
        private System.Windows.Forms.TableLayoutPanel totalsTableLayoutPanel;
        private System.Windows.Forms.Label totalsLabel;
        private System.Windows.Forms.Label cc1DeviationsCountLabel;
        private System.Windows.Forms.Label plannedCountTotalLabel;
        private System.Windows.Forms.Label cc3PlannedCountLabel;
        private System.Windows.Forms.Label cc2PlannedCountLabel;
        private System.Windows.Forms.Label cc1PlannedCountLabel;
        private System.Windows.Forms.Label actualCountTotalLabel;
        private System.Windows.Forms.Label cc3ActualCountLabel;
        private System.Windows.Forms.Label cc2ActualCountLabel;
        private System.Windows.Forms.Label cc1ActualCountLabel;
        private System.Windows.Forms.Label deviationsCountTotalLabel;
        private System.Windows.Forms.Label cc3DeviationsCountLabel;
        private System.Windows.Forms.Label cc2DeviationsCountLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc1PlannedCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc2PlannedCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc3PlannedCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlannedCountTotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc1DeviationsCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc2DeviationsCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc3DeviationsCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviationsCountTotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc1ActualCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc2ActualCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc3ActualCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualCountTotalColumn;
    }
}
