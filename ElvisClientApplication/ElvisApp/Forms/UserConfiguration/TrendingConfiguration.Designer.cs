namespace Elvis.Forms.UserConfiguration
{
    partial class TrendingConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrendingConfiguration));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabTrendingConfig = new System.Windows.Forms.TabControl();
            this.tabParameters = new System.Windows.Forms.TabPage();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.lstParameters = new System.Windows.Forms.ListView();
            this.colParameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMinLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAimTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDisplayMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDisplayMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCellWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBtnCtrlsParam = new System.Windows.Forms.Panel();
            this.btnAddParam = new System.Windows.Forms.Button();
            this.btnEditParam = new System.Windows.Forms.Button();
            this.tabGrouping = new System.Windows.Forms.TabPage();
            this.pnlGroupings = new System.Windows.Forms.Panel();
            this.lstGrouping = new System.Windows.Forms.ListView();
            this.colGroupDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPar1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPar2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPar3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPar4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPar5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPar6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSortNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDisplay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHighlight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBtnCtrlsGroup = new System.Windows.Forms.Panel();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnEditGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.pnlClose = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.tabTrendingConfig.SuspendLayout();
            this.tabParameters.SuspendLayout();
            this.pnlParameters.SuspendLayout();
            this.pnlBtnCtrlsParam.SuspendLayout();
            this.tabGrouping.SuspendLayout();
            this.pnlGroupings.SuspendLayout();
            this.pnlBtnCtrlsGroup.SuspendLayout();
            this.pnlClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabTrendingConfig);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.pnlMain.Size = new System.Drawing.Size(942, 387);
            this.pnlMain.TabIndex = 3;
            // 
            // tabTrendingConfig
            // 
            this.tabTrendingConfig.Controls.Add(this.tabParameters);
            this.tabTrendingConfig.Controls.Add(this.tabGrouping);
            this.tabTrendingConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTrendingConfig.Location = new System.Drawing.Point(6, 6);
            this.tabTrendingConfig.Name = "tabTrendingConfig";
            this.tabTrendingConfig.SelectedIndex = 0;
            this.tabTrendingConfig.Size = new System.Drawing.Size(930, 378);
            this.tabTrendingConfig.TabIndex = 1;
            // 
            // tabParameters
            // 
            this.tabParameters.Controls.Add(this.pnlParameters);
            this.tabParameters.Controls.Add(this.pnlBtnCtrlsParam);
            this.tabParameters.Location = new System.Drawing.Point(4, 22);
            this.tabParameters.Name = "tabParameters";
            this.tabParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabParameters.Size = new System.Drawing.Size(922, 352);
            this.tabParameters.TabIndex = 0;
            this.tabParameters.Text = "Parameter Configuration";
            this.tabParameters.UseVisualStyleBackColor = true;
            // 
            // pnlParameters
            // 
            this.pnlParameters.Controls.Add(this.lstParameters);
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameters.Location = new System.Drawing.Point(3, 38);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(916, 311);
            this.pnlParameters.TabIndex = 1;
            // 
            // lstParameters
            // 
            this.lstParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colParameter,
            this.colParDesc,
            this.colMinLimit,
            this.colMaxLimit,
            this.colAimTarget,
            this.colDisplayMin,
            this.colDisplayMax,
            this.colCellWidth});
            this.lstParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstParameters.FullRowSelect = true;
            this.lstParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstParameters.Location = new System.Drawing.Point(0, 0);
            this.lstParameters.MultiSelect = false;
            this.lstParameters.Name = "lstParameters";
            this.lstParameters.Size = new System.Drawing.Size(916, 311);
            this.lstParameters.TabIndex = 0;
            this.lstParameters.UseCompatibleStateImageBehavior = false;
            this.lstParameters.View = System.Windows.Forms.View.Details;
            this.lstParameters.SelectedIndexChanged += new System.EventHandler(this.lstParameters_SelectedIndexChanged);
            this.lstParameters.DoubleClick += new System.EventHandler(this.lstParameters_DoubleClick);
            this.lstParameters.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstParameters_KeyDown);
            // 
            // colParameter
            // 
            this.colParameter.Text = "Parameter";
            this.colParameter.Width = 140;
            // 
            // colParDesc
            // 
            this.colParDesc.Text = "Description";
            this.colParDesc.Width = 290;
            // 
            // colMinLimit
            // 
            this.colMinLimit.Text = "Min";
            // 
            // colMaxLimit
            // 
            this.colMaxLimit.Text = "Max";
            // 
            // colAimTarget
            // 
            this.colAimTarget.Text = "Aim";
            // 
            // colDisplayMin
            // 
            this.colDisplayMin.Text = "Axis Min";
            // 
            // colDisplayMax
            // 
            this.colDisplayMax.Text = "Axis Max";
            // 
            // colCellWidth
            // 
            this.colCellWidth.Text = "Cell Width";
            this.colCellWidth.Width = 70;
            // 
            // pnlBtnCtrlsParam
            // 
            this.pnlBtnCtrlsParam.Controls.Add(this.btnAddParam);
            this.pnlBtnCtrlsParam.Controls.Add(this.btnEditParam);
            this.pnlBtnCtrlsParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBtnCtrlsParam.Location = new System.Drawing.Point(3, 3);
            this.pnlBtnCtrlsParam.Name = "pnlBtnCtrlsParam";
            this.pnlBtnCtrlsParam.Padding = new System.Windows.Forms.Padding(3, 6, 3, 4);
            this.pnlBtnCtrlsParam.Size = new System.Drawing.Size(916, 35);
            this.pnlBtnCtrlsParam.TabIndex = 0;
            // 
            // btnAddParam
            // 
            this.btnAddParam.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddParam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddParam.Location = new System.Drawing.Point(763, 6);
            this.btnAddParam.Name = "btnAddParam";
            this.btnAddParam.Size = new System.Drawing.Size(75, 25);
            this.btnAddParam.TabIndex = 0;
            this.btnAddParam.Text = "&Add...";
            this.btnAddParam.UseVisualStyleBackColor = true;
            this.btnAddParam.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEditParam
            // 
            this.btnEditParam.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditParam.Enabled = false;
            this.btnEditParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditParam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditParam.Location = new System.Drawing.Point(838, 6);
            this.btnEditParam.Name = "btnEditParam";
            this.btnEditParam.Size = new System.Drawing.Size(75, 25);
            this.btnEditParam.TabIndex = 1;
            this.btnEditParam.Text = "&Edit...";
            this.btnEditParam.UseVisualStyleBackColor = true;
            this.btnEditParam.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tabGrouping
            // 
            this.tabGrouping.Controls.Add(this.pnlGroupings);
            this.tabGrouping.Controls.Add(this.pnlBtnCtrlsGroup);
            this.tabGrouping.Location = new System.Drawing.Point(4, 22);
            this.tabGrouping.Name = "tabGrouping";
            this.tabGrouping.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrouping.Size = new System.Drawing.Size(922, 352);
            this.tabGrouping.TabIndex = 1;
            this.tabGrouping.Text = "Grouping Configuration";
            this.tabGrouping.UseVisualStyleBackColor = true;
            // 
            // pnlGroupings
            // 
            this.pnlGroupings.Controls.Add(this.lstGrouping);
            this.pnlGroupings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupings.Location = new System.Drawing.Point(3, 38);
            this.pnlGroupings.Name = "pnlGroupings";
            this.pnlGroupings.Size = new System.Drawing.Size(916, 311);
            this.pnlGroupings.TabIndex = 1;
            // 
            // lstGrouping
            // 
            this.lstGrouping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroupDesc,
            this.colPar1,
            this.colPar2,
            this.colPar3,
            this.colPar4,
            this.colPar5,
            this.colPar6,
            this.colSortNo,
            this.colDisplay,
            this.colHighlight});
            this.lstGrouping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGrouping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGrouping.FullRowSelect = true;
            this.lstGrouping.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstGrouping.Location = new System.Drawing.Point(0, 0);
            this.lstGrouping.MultiSelect = false;
            this.lstGrouping.Name = "lstGrouping";
            this.lstGrouping.Size = new System.Drawing.Size(916, 311);
            this.lstGrouping.TabIndex = 0;
            this.lstGrouping.UseCompatibleStateImageBehavior = false;
            this.lstGrouping.View = System.Windows.Forms.View.Details;
            this.lstGrouping.SelectedIndexChanged += new System.EventHandler(this.lstGrouping_SelectedIndexChanged);
            this.lstGrouping.DoubleClick += new System.EventHandler(this.lstGrouping_DoubleClick);
            this.lstGrouping.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstGrouping_KeyDown);
            // 
            // colGroupDesc
            // 
            this.colGroupDesc.Text = "Group Description";
            this.colGroupDesc.Width = 160;
            // 
            // colPar1
            // 
            this.colPar1.Text = "Parameter 1";
            this.colPar1.Width = 95;
            // 
            // colPar2
            // 
            this.colPar2.Text = "Parameter 2";
            this.colPar2.Width = 95;
            // 
            // colPar3
            // 
            this.colPar3.Text = "Parameter 3";
            this.colPar3.Width = 95;
            // 
            // colPar4
            // 
            this.colPar4.Text = "Parameter 4";
            this.colPar4.Width = 95;
            // 
            // colPar5
            // 
            this.colPar5.Text = "Parameter 5";
            this.colPar5.Width = 95;
            // 
            // colPar6
            // 
            this.colPar6.Text = "Parameter 6";
            this.colPar6.Width = 95;
            // 
            // colSortNo
            // 
            this.colSortNo.Text = "Sort No";
            this.colSortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSortNo.Width = 52;
            // 
            // colDisplay
            // 
            this.colDisplay.Text = "Enabled";
            this.colDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDisplay.Width = 54;
            // 
            // colHighlight
            // 
            this.colHighlight.Text = "Highlight";
            this.colHighlight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlBtnCtrlsGroup
            // 
            this.pnlBtnCtrlsGroup.Controls.Add(this.btnMoveUp);
            this.pnlBtnCtrlsGroup.Controls.Add(this.btnMoveDown);
            this.pnlBtnCtrlsGroup.Controls.Add(this.btnAddGroup);
            this.pnlBtnCtrlsGroup.Controls.Add(this.btnEditGroup);
            this.pnlBtnCtrlsGroup.Controls.Add(this.btnDeleteGroup);
            this.pnlBtnCtrlsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBtnCtrlsGroup.Location = new System.Drawing.Point(3, 3);
            this.pnlBtnCtrlsGroup.Name = "pnlBtnCtrlsGroup";
            this.pnlBtnCtrlsGroup.Padding = new System.Windows.Forms.Padding(3, 6, 3, 4);
            this.pnlBtnCtrlsGroup.Size = new System.Drawing.Size(916, 35);
            this.pnlBtnCtrlsGroup.TabIndex = 0;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(615, 6);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(36, 25);
            this.btnMoveUp.TabIndex = 19;
            this.btnMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(651, 6);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(36, 25);
            this.btnMoveDown.TabIndex = 18;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddGroup.Location = new System.Drawing.Point(687, 6);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(75, 25);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "&Add...";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditGroup.Enabled = false;
            this.btnEditGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditGroup.Location = new System.Drawing.Point(762, 6);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(75, 25);
            this.btnEditGroup.TabIndex = 1;
            this.btnEditGroup.Text = "&Edit...";
            this.btnEditGroup.UseVisualStyleBackColor = true;
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteGroup.Enabled = false;
            this.btnDeleteGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDeleteGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteGroup.Image = global::Elvis.Properties.Resources.delete_12x12;
            this.btnDeleteGroup.Location = new System.Drawing.Point(837, 6);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnDeleteGroup.Size = new System.Drawing.Size(76, 25);
            this.btnDeleteGroup.TabIndex = 20;
            this.btnDeleteGroup.Text = "&Delete";
            this.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlClose
            // 
            this.pnlClose.Controls.Add(this.btnClose);
            this.pnlClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlClose.Location = new System.Drawing.Point(0, 387);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlClose.Size = new System.Drawing.Size(942, 29);
            this.pnlClose.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(861, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TrendingConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 416);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrendingConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trending Configuration";
            this.pnlMain.ResumeLayout(false);
            this.tabTrendingConfig.ResumeLayout(false);
            this.tabParameters.ResumeLayout(false);
            this.pnlParameters.ResumeLayout(false);
            this.pnlBtnCtrlsParam.ResumeLayout(false);
            this.tabGrouping.ResumeLayout(false);
            this.pnlGroupings.ResumeLayout(false);
            this.pnlBtnCtrlsGroup.ResumeLayout(false);
            this.pnlClose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.ListView lstParameters;
        private System.Windows.Forms.Panel pnlBtnCtrlsParam;
        private System.Windows.Forms.Button btnEditParam;
        private System.Windows.Forms.Button btnAddParam;
        private System.Windows.Forms.Panel pnlClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colParameter;
        private System.Windows.Forms.ColumnHeader colParDesc;
        private System.Windows.Forms.ColumnHeader colMinLimit;
        private System.Windows.Forms.ColumnHeader colMaxLimit;
        private System.Windows.Forms.ColumnHeader colAimTarget;
        private System.Windows.Forms.ColumnHeader colDisplayMin;
        private System.Windows.Forms.ColumnHeader colDisplayMax;
        private System.Windows.Forms.ColumnHeader colCellWidth;
        private System.Windows.Forms.TabControl tabTrendingConfig;
        private System.Windows.Forms.TabPage tabParameters;
        private System.Windows.Forms.TabPage tabGrouping;
        private System.Windows.Forms.Panel pnlGroupings;
        private System.Windows.Forms.ListView lstGrouping;
        private System.Windows.Forms.ColumnHeader colGroupDesc;
        private System.Windows.Forms.ColumnHeader colDisplay;
        private System.Windows.Forms.ColumnHeader colSortNo;
        private System.Windows.Forms.ColumnHeader colPar1;
        private System.Windows.Forms.ColumnHeader colPar2;
        private System.Windows.Forms.ColumnHeader colPar3;
        private System.Windows.Forms.ColumnHeader colPar4;
        private System.Windows.Forms.ColumnHeader colPar5;
        private System.Windows.Forms.Panel pnlBtnCtrlsGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnEditGroup;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader colPar6;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.ColumnHeader colHighlight;
    }
}