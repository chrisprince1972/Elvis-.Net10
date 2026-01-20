namespace Elvis.Forms.General
{
    partial class Diagnostics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diagnostics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMyLog = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAllLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu1Month = new System.Windows.Forms.ToolStripMenuItem();
            this.menu3Months = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuServerStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTimeControls = new System.Windows.Forms.ToolStrip();
            this.btnShowServerStatus = new System.Windows.Forms.ToolStripButton();
            this.btnShowMyLogs = new System.Windows.Forms.ToolStripButton();
            this.btnShowAllLogs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShow1Month = new System.Windows.Forms.ToolStripButton();
            this.btnShow3Month = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlServerStatus = new System.Windows.Forms.Panel();
            this.ucServerStatus = new Elvis.Forms.General.ServerStatus();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.grpErrorLog = new System.Windows.Forms.GroupBox();
            this.dgvErrorLog = new System.Windows.Forms.DataGridView();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exception = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StackTrace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStripTimeControls.SuspendLayout();
            this.pnlServerStatus.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.grpErrorLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorLog)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClose});
            this.menuFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuItemClose
            // 
            this.menuItemClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuItemClose.Image = global::Elvis.Properties.Resources.Close_16xLG;
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(103, 22);
            this.menuItemClose.Text = "&Close";
            this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMyLog,
            this.menuAllLogs,
            this.toolStripSeparator1,
            this.menu1Month,
            this.menu3Months,
            this.toolStripSeparator2,
            this.menuServerStatus});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // menuMyLog
            // 
            this.menuMyLog.Checked = true;
            this.menuMyLog.CheckOnClick = true;
            this.menuMyLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuMyLog.Name = "menuMyLog";
            this.menuMyLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.menuMyLog.Size = new System.Drawing.Size(213, 22);
            this.menuMyLog.Tag = "1";
            this.menuMyLog.Text = "Show &My Log";
            this.menuMyLog.Click += new System.EventHandler(this.menuMyLog_Click);
            // 
            // menuAllLogs
            // 
            this.menuAllLogs.CheckOnClick = true;
            this.menuAllLogs.Name = "menuAllLogs";
            this.menuAllLogs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuAllLogs.Size = new System.Drawing.Size(213, 22);
            this.menuAllLogs.Tag = "2";
            this.menuAllLogs.Text = "Show &All Logs";
            this.menuAllLogs.Click += new System.EventHandler(this.menuAllLogs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(210, 6);
            // 
            // menu1Month
            // 
            this.menu1Month.Checked = true;
            this.menu1Month.CheckOnClick = true;
            this.menu1Month.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu1Month.Name = "menu1Month";
            this.menu1Month.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.menu1Month.Size = new System.Drawing.Size(213, 22);
            this.menu1Month.Text = "Show &1 Month";
            this.menu1Month.Click += new System.EventHandler(this.menu1Month_Click);
            // 
            // menu3Months
            // 
            this.menu3Months.CheckOnClick = true;
            this.menu3Months.Name = "menu3Months";
            this.menu3Months.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.menu3Months.Size = new System.Drawing.Size(213, 22);
            this.menu3Months.Text = "Show &3 Months";
            this.menu3Months.Click += new System.EventHandler(this.menu3Months_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(210, 6);
            // 
            // menuServerStatus
            // 
            this.menuServerStatus.Checked = true;
            this.menuServerStatus.CheckOnClick = true;
            this.menuServerStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuServerStatus.Name = "menuServerStatus";
            this.menuServerStatus.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuServerStatus.Size = new System.Drawing.Size(213, 22);
            this.menuServerStatus.Text = "Show &Server Status";
            this.menuServerStatus.Click += new System.EventHandler(this.btnShowServerStatus_Click);
            // 
            // toolStripTimeControls
            // 
            this.toolStripTimeControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowServerStatus,
            this.btnShowMyLogs,
            this.btnShowAllLogs,
            this.toolStripSep2,
            this.btnShow1Month,
            this.btnShow3Month,
            this.toolStripSeparator3});
            this.toolStripTimeControls.Location = new System.Drawing.Point(0, 24);
            this.toolStripTimeControls.Name = "toolStripTimeControls";
            this.toolStripTimeControls.Size = new System.Drawing.Size(742, 25);
            this.toolStripTimeControls.TabIndex = 12;
            this.toolStripTimeControls.Text = "Time Controls";
            // 
            // btnShowServerStatus
            // 
            this.btnShowServerStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShowServerStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnShowServerStatus.Image")));
            this.btnShowServerStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowServerStatus.Name = "btnShowServerStatus";
            this.btnShowServerStatus.Size = new System.Drawing.Size(23, 22);
            this.btnShowServerStatus.ToolTipText = "Show/Hide Server Status";
            this.btnShowServerStatus.Click += new System.EventHandler(this.btnShowServerStatus_Click);
            // 
            // btnShowMyLogs
            // 
            this.btnShowMyLogs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShowMyLogs.Image = ((System.Drawing.Image)(resources.GetObject("btnShowMyLogs.Image")));
            this.btnShowMyLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowMyLogs.Name = "btnShowMyLogs";
            this.btnShowMyLogs.Size = new System.Drawing.Size(23, 22);
            this.btnShowMyLogs.ToolTipText = "Show My Logs";
            this.btnShowMyLogs.Click += new System.EventHandler(this.menuMyLog_Click);
            // 
            // btnShowAllLogs
            // 
            this.btnShowAllLogs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShowAllLogs.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAllLogs.Image")));
            this.btnShowAllLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAllLogs.Name = "btnShowAllLogs";
            this.btnShowAllLogs.Size = new System.Drawing.Size(23, 22);
            this.btnShowAllLogs.ToolTipText = "Show All Logs";
            this.btnShowAllLogs.Click += new System.EventHandler(this.menuAllLogs_Click);
            // 
            // toolStripSep2
            // 
            this.toolStripSep2.Name = "toolStripSep2";
            this.toolStripSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnShow1Month
            // 
            this.btnShow1Month.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShow1Month.Image = ((System.Drawing.Image)(resources.GetObject("btnShow1Month.Image")));
            this.btnShow1Month.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShow1Month.Name = "btnShow1Month";
            this.btnShow1Month.Size = new System.Drawing.Size(72, 22);
            this.btnShow1Month.Text = "1 Month";
            this.btnShow1Month.Click += new System.EventHandler(this.menu1Month_Click);
            // 
            // btnShow3Month
            // 
            this.btnShow3Month.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShow3Month.Image = ((System.Drawing.Image)(resources.GetObject("btnShow3Month.Image")));
            this.btnShow3Month.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShow3Month.Name = "btnShow3Month";
            this.btnShow3Month.Size = new System.Drawing.Size(77, 22);
            this.btnShow3Month.Text = "3 Months";
            this.btnShow3Month.Click += new System.EventHandler(this.menu3Months_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // pnlServerStatus
            // 
            this.pnlServerStatus.Controls.Add(this.ucServerStatus);
            this.pnlServerStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlServerStatus.Location = new System.Drawing.Point(0, 49);
            this.pnlServerStatus.Name = "pnlServerStatus";
            this.pnlServerStatus.Padding = new System.Windows.Forms.Padding(3);
            this.pnlServerStatus.Size = new System.Drawing.Size(178, 367);
            this.pnlServerStatus.TabIndex = 13;
            this.pnlServerStatus.VisibleChanged += new System.EventHandler(this.pnlServerStatus_VisibleChanged);
            // 
            // ucServerStatus
            // 
            this.ucServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucServerStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucServerStatus.Location = new System.Drawing.Point(3, 3);
            this.ucServerStatus.Name = "ucServerStatus";
            this.ucServerStatus.Size = new System.Drawing.Size(172, 361);
            this.ucServerStatus.TabIndex = 0;
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.grpErrorLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(178, 49);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Padding = new System.Windows.Forms.Padding(3);
            this.pnlLog.Size = new System.Drawing.Size(564, 367);
            this.pnlLog.TabIndex = 14;
            // 
            // grpErrorLog
            // 
            this.grpErrorLog.Controls.Add(this.dgvErrorLog);
            this.grpErrorLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpErrorLog.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpErrorLog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpErrorLog.Location = new System.Drawing.Point(3, 3);
            this.grpErrorLog.Name = "grpErrorLog";
            this.grpErrorLog.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.grpErrorLog.Size = new System.Drawing.Size(558, 361);
            this.grpErrorLog.TabIndex = 0;
            this.grpErrorLog.TabStop = false;
            this.grpErrorLog.Text = "Error Log";
            // 
            // dgvErrorLog
            // 
            this.dgvErrorLog.AllowUserToAddRows = false;
            this.dgvErrorLog.AllowUserToDeleteRows = false;
            this.dgvErrorLog.AllowUserToOrderColumns = true;
            this.dgvErrorLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvErrorLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvErrorLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrorLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvErrorLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvErrorLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvErrorLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvErrorLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrorLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvErrorLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeStamp,
            this.LogLevel,
            this.MachineName,
            this.UserName,
            this.Message,
            this.Exception,
            this.StackTrace,
            this.CallSite,
            this.Thread});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvErrorLog.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvErrorLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrorLog.EnableHeadersVisualStyles = false;
            this.dgvErrorLog.GridColor = System.Drawing.Color.DimGray;
            this.dgvErrorLog.Location = new System.Drawing.Point(6, 18);
            this.dgvErrorLog.Name = "dgvErrorLog";
            this.dgvErrorLog.ReadOnly = true;
            this.dgvErrorLog.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvErrorLog.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvErrorLog.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvErrorLog.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvErrorLog.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvErrorLog.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvErrorLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrorLog.Size = new System.Drawing.Size(546, 337);
            this.dgvErrorLog.TabIndex = 0;
            // 
            // TimeStamp
            // 
            this.TimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TimeStamp.DataPropertyName = "TimeStamp";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.TimeStamp.DefaultCellStyle = dataGridViewCellStyle3;
            this.TimeStamp.HeaderText = "Date/Time";
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.ReadOnly = true;
            this.TimeStamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TimeStamp.Width = 75;
            // 
            // LogLevel
            // 
            this.LogLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LogLevel.DataPropertyName = "LogLevel";
            this.LogLevel.HeaderText = "Type";
            this.LogLevel.Name = "LogLevel";
            this.LogLevel.ReadOnly = true;
            this.LogLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LogLevel.Width = 42;
            // 
            // MachineName
            // 
            this.MachineName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MachineName.DataPropertyName = "MachineName";
            this.MachineName.HeaderText = "Machine Name";
            this.MachineName.Name = "MachineName";
            this.MachineName.ReadOnly = true;
            this.MachineName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MachineName.Width = 96;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Username";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserName.Width = 72;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "Message";
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Exception
            // 
            this.Exception.DataPropertyName = "Exception";
            this.Exception.HeaderText = "Exception";
            this.Exception.Name = "Exception";
            this.Exception.ReadOnly = true;
            this.Exception.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // StackTrace
            // 
            this.StackTrace.DataPropertyName = "StackTrace";
            this.StackTrace.HeaderText = "Stack Trace";
            this.StackTrace.Name = "StackTrace";
            this.StackTrace.ReadOnly = true;
            this.StackTrace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StackTrace.Visible = false;
            // 
            // CallSite
            // 
            this.CallSite.DataPropertyName = "CallSite";
            this.CallSite.HeaderText = "CallSite";
            this.CallSite.Name = "CallSite";
            this.CallSite.ReadOnly = true;
            this.CallSite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CallSite.Visible = false;
            // 
            // Thread
            // 
            this.Thread.DataPropertyName = "Thread";
            this.Thread.HeaderText = "Thread";
            this.Thread.Name = "Thread";
            this.Thread.ReadOnly = true;
            this.Thread.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Thread.Visible = false;
            // 
            // Diagnostics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 416);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlServerStatus);
            this.Controls.Add(this.toolStripTimeControls);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Diagnostics";
            this.Text = "Diagnostics";
            this.Load += new System.EventHandler(this.Diagnostics_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Diagnostics_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripTimeControls.ResumeLayout(false);
            this.toolStripTimeControls.PerformLayout();
            this.pnlServerStatus.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.grpErrorLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuMyLog;
        private System.Windows.Forms.ToolStripMenuItem menuAllLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStripTimeControls;
        private System.Windows.Forms.ToolStripButton btnShowAllLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSep2;
        private System.Windows.Forms.ToolStripMenuItem menu1Month;
        private System.Windows.Forms.ToolStripMenuItem menu3Months;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuServerStatus;
        private System.Windows.Forms.ToolStripButton btnShowMyLogs;
        private System.Windows.Forms.ToolStripButton btnShow1Month;
        private System.Windows.Forms.ToolStripButton btnShow3Month;
        private System.Windows.Forms.ToolStripButton btnShowServerStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel pnlServerStatus;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.GroupBox grpErrorLog;
        private System.Windows.Forms.DataGridView dgvErrorLog;
        private ServerStatus ucServerStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exception;
        private System.Windows.Forms.DataGridViewTextBoxColumn StackTrace;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thread;
    }
}