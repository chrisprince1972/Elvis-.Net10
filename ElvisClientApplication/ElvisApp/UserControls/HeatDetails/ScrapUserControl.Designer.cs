namespace Elvis.UserControls.HeatDetails
{
    partial class ScrapUserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.grpScrapDetails = new System.Windows.Forms.GroupBox();
            this.dgvScrapDetails = new System.Windows.Forms.DataGridView();
            this.ScrapType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuTonnes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredTonnes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualTonnes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlTreatmentDetails = new System.Windows.Forms.Panel();
            this.grpTreatmentDetails = new System.Windows.Forms.GroupBox();
            this.pnlScrapEvent = new System.Windows.Forms.Panel();
            this.dgvScrapEvent = new System.Windows.Forms.DataGridView();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapEventTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScrapEventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlScrapCar = new System.Windows.Forms.Panel();
            this.txtScrapBoxType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScrapCar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.grpScrapDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrapDetails)).BeginInit();
            this.pnlTreatmentDetails.SuspendLayout();
            this.grpTreatmentDetails.SuspendLayout();
            this.pnlScrapEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrapEvent)).BeginInit();
            this.pnlScrapCar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Controls.Add(this.splitter1);
            this.pnlMain.Controls.Add(this.pnlTreatmentDetails);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(1087, 557);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDetails
            // 
            this.pnlDetails.AutoScroll = true;
            this.pnlDetails.Controls.Add(this.grpScrapDetails);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(410, 6);
            this.pnlDetails.MinimumSize = new System.Drawing.Size(300, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(671, 545);
            this.pnlDetails.TabIndex = 1;
            // 
            // grpScrapDetails
            // 
            this.grpScrapDetails.Controls.Add(this.dgvScrapDetails);
            this.grpScrapDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpScrapDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpScrapDetails.Location = new System.Drawing.Point(0, 0);
            this.grpScrapDetails.Name = "grpScrapDetails";
            this.grpScrapDetails.Padding = new System.Windows.Forms.Padding(6);
            this.grpScrapDetails.Size = new System.Drawing.Size(671, 545);
            this.grpScrapDetails.TabIndex = 2;
            this.grpScrapDetails.TabStop = false;
            this.grpScrapDetails.Text = "Scrap Details";
            // 
            // dgvScrapDetails
            // 
            this.dgvScrapDetails.AllowUserToAddRows = false;
            this.dgvScrapDetails.AllowUserToDeleteRows = false;
            this.dgvScrapDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvScrapDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScrapDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScrapDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvScrapDetails.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvScrapDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvScrapDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvScrapDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScrapDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScrapDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScrapType,
            this.MenuTonnes,
            this.RequiredTonnes,
            this.ActualTonnes});
            this.dgvScrapDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScrapDetails.EnableHeadersVisualStyles = false;
            this.dgvScrapDetails.GridColor = System.Drawing.Color.DimGray;
            this.dgvScrapDetails.Location = new System.Drawing.Point(6, 20);
            this.dgvScrapDetails.Name = "dgvScrapDetails";
            this.dgvScrapDetails.ReadOnly = true;
            this.dgvScrapDetails.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dgvScrapDetails.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvScrapDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScrapDetails.Size = new System.Drawing.Size(659, 519);
            this.dgvScrapDetails.TabIndex = 0;
            this.dgvScrapDetails.TabStop = false;
            this.dgvScrapDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // ScrapType
            // 
            this.ScrapType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ScrapType.DataPropertyName = "Description";
            this.ScrapType.FillWeight = 203.0457F;
            this.ScrapType.HeaderText = "Scrap Type";
            this.ScrapType.Name = "ScrapType";
            this.ScrapType.ReadOnly = true;
            this.ScrapType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MenuTonnes
            // 
            this.MenuTonnes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MenuTonnes.DataPropertyName = "MenuWeight";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "-";
            this.MenuTonnes.DefaultCellStyle = dataGridViewCellStyle3;
            this.MenuTonnes.FillWeight = 70F;
            this.MenuTonnes.HeaderText = "Menu Tonnes";
            this.MenuTonnes.Name = "MenuTonnes";
            this.MenuTonnes.ReadOnly = true;
            this.MenuTonnes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RequiredTonnes
            // 
            this.RequiredTonnes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RequiredTonnes.DataPropertyName = "RequiredWeight";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "-";
            this.RequiredTonnes.DefaultCellStyle = dataGridViewCellStyle4;
            this.RequiredTonnes.FillWeight = 70F;
            this.RequiredTonnes.HeaderText = "Required Tonnes";
            this.RequiredTonnes.Name = "RequiredTonnes";
            this.RequiredTonnes.ReadOnly = true;
            this.RequiredTonnes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ActualTonnes
            // 
            this.ActualTonnes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActualTonnes.DataPropertyName = "ActualWeight";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "-";
            this.ActualTonnes.DefaultCellStyle = dataGridViewCellStyle5;
            this.ActualTonnes.FillWeight = 70F;
            this.ActualTonnes.HeaderText = "Actual Tonnes";
            this.ActualTonnes.Name = "ActualTonnes";
            this.ActualTonnes.ReadOnly = true;
            this.ActualTonnes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(405, 6);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 545);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pnlTreatmentDetails
            // 
            this.pnlTreatmentDetails.AutoScroll = true;
            this.pnlTreatmentDetails.Controls.Add(this.grpTreatmentDetails);
            this.pnlTreatmentDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTreatmentDetails.Location = new System.Drawing.Point(6, 6);
            this.pnlTreatmentDetails.MinimumSize = new System.Drawing.Size(399, 0);
            this.pnlTreatmentDetails.Name = "pnlTreatmentDetails";
            this.pnlTreatmentDetails.Size = new System.Drawing.Size(399, 545);
            this.pnlTreatmentDetails.TabIndex = 0;
            // 
            // grpTreatmentDetails
            // 
            this.grpTreatmentDetails.Controls.Add(this.pnlScrapEvent);
            this.grpTreatmentDetails.Controls.Add(this.splitter2);
            this.grpTreatmentDetails.Controls.Add(this.pnlScrapCar);
            this.grpTreatmentDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTreatmentDetails.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTreatmentDetails.Location = new System.Drawing.Point(0, 0);
            this.grpTreatmentDetails.Name = "grpTreatmentDetails";
            this.grpTreatmentDetails.Padding = new System.Windows.Forms.Padding(6);
            this.grpTreatmentDetails.Size = new System.Drawing.Size(399, 545);
            this.grpTreatmentDetails.TabIndex = 0;
            this.grpTreatmentDetails.TabStop = false;
            this.grpTreatmentDetails.Text = "Treatment Details";
            // 
            // pnlScrapEvent
            // 
            this.pnlScrapEvent.Controls.Add(this.dgvScrapEvent);
            this.pnlScrapEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScrapEvent.Location = new System.Drawing.Point(6, 60);
            this.pnlScrapEvent.Name = "pnlScrapEvent";
            this.pnlScrapEvent.Size = new System.Drawing.Size(387, 479);
            this.pnlScrapEvent.TabIndex = 1;
            // 
            // dgvScrapEvent
            // 
            this.dgvScrapEvent.AllowUserToAddRows = false;
            this.dgvScrapEvent.AllowUserToDeleteRows = false;
            this.dgvScrapEvent.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvScrapEvent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvScrapEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScrapEvent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvScrapEvent.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvScrapEvent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvScrapEvent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvScrapEvent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScrapEvent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvScrapEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Event,
            this.EventTime,
            this.ScrapEventTypeID,
            this.ScrapEventID});
            this.dgvScrapEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScrapEvent.EnableHeadersVisualStyles = false;
            this.dgvScrapEvent.GridColor = System.Drawing.Color.DimGray;
            this.dgvScrapEvent.Location = new System.Drawing.Point(0, 0);
            this.dgvScrapEvent.Name = "dgvScrapEvent";
            this.dgvScrapEvent.ReadOnly = true;
            this.dgvScrapEvent.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.dgvScrapEvent.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvScrapEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScrapEvent.Size = new System.Drawing.Size(387, 479);
            this.dgvScrapEvent.TabIndex = 0;
            this.dgvScrapEvent.TabStop = false;
            this.dgvScrapEvent.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            // 
            // Event
            // 
            this.Event.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Event.DataPropertyName = "EventDescription";
            this.Event.HeaderText = "Event";
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            this.Event.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EventTime
            // 
            this.EventTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EventTime.DataPropertyName = "EventTime";
            dataGridViewCellStyle9.Format = "T";
            dataGridViewCellStyle9.NullValue = null;
            this.EventTime.DefaultCellStyle = dataGridViewCellStyle9;
            this.EventTime.HeaderText = "Time";
            this.EventTime.Name = "EventTime";
            this.EventTime.ReadOnly = true;
            this.EventTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ScrapEventTypeID
            // 
            this.ScrapEventTypeID.DataPropertyName = "ScrapEventTypeID";
            this.ScrapEventTypeID.HeaderText = "ScrapEventTypeID";
            this.ScrapEventTypeID.Name = "ScrapEventTypeID";
            this.ScrapEventTypeID.ReadOnly = true;
            this.ScrapEventTypeID.Visible = false;
            // 
            // ScrapEventID
            // 
            this.ScrapEventID.DataPropertyName = "ScrapEventID";
            this.ScrapEventID.HeaderText = "ScrapEventID";
            this.ScrapEventID.Name = "ScrapEventID";
            this.ScrapEventID.ReadOnly = true;
            this.ScrapEventID.Visible = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(6, 55);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(387, 5);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // pnlScrapCar
            // 
            this.pnlScrapCar.Controls.Add(this.txtScrapBoxType);
            this.pnlScrapCar.Controls.Add(this.label1);
            this.pnlScrapCar.Controls.Add(this.txtScrapCar);
            this.pnlScrapCar.Controls.Add(this.label4);
            this.pnlScrapCar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScrapCar.Location = new System.Drawing.Point(6, 20);
            this.pnlScrapCar.Name = "pnlScrapCar";
            this.pnlScrapCar.Size = new System.Drawing.Size(387, 35);
            this.pnlScrapCar.TabIndex = 2;
            // 
            // txtScrapBoxType
            // 
            this.txtScrapBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScrapBoxType.BackColor = System.Drawing.SystemColors.Window;
            this.txtScrapBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScrapBoxType.Location = new System.Drawing.Point(259, 3);
            this.txtScrapBoxType.Name = "txtScrapBoxType";
            this.txtScrapBoxType.ReadOnly = true;
            this.txtScrapBoxType.Size = new System.Drawing.Size(125, 20);
            this.txtScrapBoxType.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 14);
            this.label1.TabIndex = 33;
            this.label1.Text = "Scrap Box Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtScrapCar
            // 
            this.txtScrapCar.BackColor = System.Drawing.SystemColors.Window;
            this.txtScrapCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScrapCar.Location = new System.Drawing.Point(71, 3);
            this.txtScrapCar.Name = "txtScrapCar";
            this.txtScrapCar.ReadOnly = true;
            this.txtScrapCar.Size = new System.Drawing.Size(83, 20);
            this.txtScrapCar.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "Scrap Car";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScrapUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlMain);
            this.Name = "ScrapUserControl";
            this.Size = new System.Drawing.Size(1087, 557);
            this.Load += new System.EventHandler(this.ScrapUserControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.grpScrapDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrapDetails)).EndInit();
            this.pnlTreatmentDetails.ResumeLayout(false);
            this.grpTreatmentDetails.ResumeLayout(false);
            this.pnlScrapEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScrapEvent)).EndInit();
            this.pnlScrapCar.ResumeLayout(false);
            this.pnlScrapCar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTreatmentDetails;
        private System.Windows.Forms.GroupBox grpTreatmentDetails;
        private System.Windows.Forms.DataGridView dgvScrapEvent;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.GroupBox grpScrapDetails;
        private System.Windows.Forms.DataGridView dgvScrapDetails;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlScrapEvent;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlScrapCar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScrapCar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScrapBoxType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuTonnes;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredTonnes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualTonnes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapEventTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScrapEventID;

    }
}
