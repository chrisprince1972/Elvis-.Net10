namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    partial class MiscastFilter
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
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.pnlComboHolder = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRota = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblRootCause = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.ccbStatus = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.ccbRota = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.ccbArea = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.ccbFunction = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.ccbFailureMode = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.ccbUnit = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.ccbRootCause = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.ccbType = new Elvis.Common.ThirdPartyControls.CheckedComboBox();
            this.grpFilters.SuspendLayout();
            this.pnlComboHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.pnlComboHolder);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilters.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilters.Location = new System.Drawing.Point(0, 0);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpFilters.Size = new System.Drawing.Size(499, 113);
            this.grpFilters.TabIndex = 25;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            // 
            // pnlComboHolder
            // 
            this.pnlComboHolder.Controls.Add(this.ccbStatus);
            this.pnlComboHolder.Controls.Add(this.lblStatus);
            this.pnlComboHolder.Controls.Add(this.ccbRota);
            this.pnlComboHolder.Controls.Add(this.lblRota);
            this.pnlComboHolder.Controls.Add(this.ccbArea);
            this.pnlComboHolder.Controls.Add(this.ccbFunction);
            this.pnlComboHolder.Controls.Add(this.lblArea);
            this.pnlComboHolder.Controls.Add(this.ccbFailureMode);
            this.pnlComboHolder.Controls.Add(this.lblFunction);
            this.pnlComboHolder.Controls.Add(this.ccbUnit);
            this.pnlComboHolder.Controls.Add(this.ccbRootCause);
            this.pnlComboHolder.Controls.Add(this.ccbType);
            this.pnlComboHolder.Controls.Add(this.lblRootCause);
            this.pnlComboHolder.Controls.Add(this.lblUnit);
            this.pnlComboHolder.Controls.Add(this.lblType);
            this.pnlComboHolder.Controls.Add(this.lblReason);
            this.pnlComboHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComboHolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlComboHolder.Location = new System.Drawing.Point(3, 14);
            this.pnlComboHolder.Name = "pnlComboHolder";
            this.pnlComboHolder.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
            this.pnlComboHolder.Size = new System.Drawing.Size(493, 96);
            this.pnlComboHolder.TabIndex = 12;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(293, 12);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "Status";
            // 
            // lblRota
            // 
            this.lblRota.AutoSize = true;
            this.lblRota.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRota.Location = new System.Drawing.Point(358, 39);
            this.lblRota.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblRota.Name = "lblRota";
            this.lblRota.Size = new System.Drawing.Size(30, 13);
            this.lblRota.TabIndex = 6;
            this.lblRota.Text = "Rota";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(39, 39);
            this.lblArea.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(30, 13);
            this.lblArea.TabIndex = 4;
            this.lblArea.Text = "Area";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunction.Location = new System.Drawing.Point(21, 12);
            this.lblFunction.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(48, 13);
            this.lblFunction.TabIndex = 14;
            this.lblFunction.Text = "Function";
            // 
            // lblRootCause
            // 
            this.lblRootCause.AutoSize = true;
            this.lblRootCause.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootCause.Location = new System.Drawing.Point(6, 66);
            this.lblRootCause.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblRootCause.Name = "lblRootCause";
            this.lblRootCause.Size = new System.Drawing.Size(63, 13);
            this.lblRootCause.TabIndex = 15;
            this.lblRootCause.Text = "Root Cause";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.Location = new System.Drawing.Point(176, 39);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 12;
            this.lblUnit.Text = "Unit";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(171, 12);
            this.lblType.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(253, 66);
            this.lblReason.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(68, 13);
            this.lblReason.TabIndex = 10;
            this.lblReason.Text = "Failure Mode";
            // 
            // ccbStatus
            // 
            this.ccbStatus.CheckOnClick = true;
            this.ccbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbStatus.DropDownHeight = 1;
            this.ccbStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbStatus.FormattingEnabled = true;
            this.ccbStatus.IntegralHeight = false;
            this.ccbStatus.Location = new System.Drawing.Point(334, 9);
            this.ccbStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbStatus.Name = "ccbStatus";
            this.ccbStatus.Size = new System.Drawing.Size(150, 22);
            this.ccbStatus.TabIndex = 24;
            this.ccbStatus.ValueSeparator = ", ";
            this.ccbStatus.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbStatus_ItemCheck);
            this.ccbStatus.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // ccbRota
            // 
            this.ccbRota.CheckOnClick = true;
            this.ccbRota.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbRota.DropDownHeight = 1;
            this.ccbRota.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbRota.FormattingEnabled = true;
            this.ccbRota.IntegralHeight = false;
            this.ccbRota.Location = new System.Drawing.Point(391, 36);
            this.ccbRota.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbRota.Name = "ccbRota";
            this.ccbRota.Size = new System.Drawing.Size(93, 22);
            this.ccbRota.TabIndex = 17;
            this.ccbRota.ValueSeparator = ", ";
            this.ccbRota.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbRota_ItemCheck);
            this.ccbRota.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // ccbArea
            // 
            this.ccbArea.CheckOnClick = true;
            this.ccbArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbArea.DropDownHeight = 1;
            this.ccbArea.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbArea.FormattingEnabled = true;
            this.ccbArea.IntegralHeight = false;
            this.ccbArea.Location = new System.Drawing.Point(72, 36);
            this.ccbArea.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbArea.Name = "ccbArea";
            this.ccbArea.Size = new System.Drawing.Size(93, 22);
            this.ccbArea.TabIndex = 16;
            this.ccbArea.ValueSeparator = ", ";
            this.ccbArea.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbArea_ItemCheck);
            this.ccbArea.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // ccbFunction
            // 
            this.ccbFunction.CheckOnClick = true;
            this.ccbFunction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbFunction.DropDownHeight = 1;
            this.ccbFunction.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbFunction.FormattingEnabled = true;
            this.ccbFunction.IntegralHeight = false;
            this.ccbFunction.Location = new System.Drawing.Point(72, 9);
            this.ccbFunction.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbFunction.Name = "ccbFunction";
            this.ccbFunction.Size = new System.Drawing.Size(93, 22);
            this.ccbFunction.TabIndex = 20;
            this.ccbFunction.ValueSeparator = ", ";
            this.ccbFunction.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbFunction_ItemCheck);
            this.ccbFunction.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // ccbFailureMode
            // 
            this.ccbFailureMode.CheckOnClick = true;
            this.ccbFailureMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbFailureMode.DropDownHeight = 1;
            this.ccbFailureMode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbFailureMode.FormattingEnabled = true;
            this.ccbFailureMode.IntegralHeight = false;
            this.ccbFailureMode.Location = new System.Drawing.Point(324, 63);
            this.ccbFailureMode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbFailureMode.Name = "ccbFailureMode";
            this.ccbFailureMode.Size = new System.Drawing.Size(160, 22);
            this.ccbFailureMode.TabIndex = 22;
            this.ccbFailureMode.ValueSeparator = ", ";
            this.ccbFailureMode.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbFailureMode_ItemCheck);
            this.ccbFailureMode.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // ccbUnit
            // 
            this.ccbUnit.CheckOnClick = true;
            this.ccbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbUnit.DropDownHeight = 1;
            this.ccbUnit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbUnit.FormattingEnabled = true;
            this.ccbUnit.IntegralHeight = false;
            this.ccbUnit.Location = new System.Drawing.Point(205, 36);
            this.ccbUnit.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbUnit.Name = "ccbUnit";
            this.ccbUnit.Size = new System.Drawing.Size(147, 22);
            this.ccbUnit.TabIndex = 21;
            this.ccbUnit.ValueSeparator = ", ";
            this.ccbUnit.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbUnit_ItemCheck);
            this.ccbUnit.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // ccbRootCause
            // 
            this.ccbRootCause.CheckOnClick = true;
            this.ccbRootCause.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbRootCause.DropDownHeight = 1;
            this.ccbRootCause.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbRootCause.FormattingEnabled = true;
            this.ccbRootCause.IntegralHeight = false;
            this.ccbRootCause.Location = new System.Drawing.Point(72, 63);
            this.ccbRootCause.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbRootCause.Name = "ccbRootCause";
            this.ccbRootCause.Size = new System.Drawing.Size(175, 22);
            this.ccbRootCause.TabIndex = 19;
            this.ccbRootCause.ValueSeparator = ", ";
            this.ccbRootCause.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbRootCause_ItemCheck);
            this.ccbRootCause.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // ccbType
            // 
            this.ccbType.CheckOnClick = true;
            this.ccbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccbType.DropDownHeight = 1;
            this.ccbType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbType.FormattingEnabled = true;
            this.ccbType.IntegralHeight = false;
            this.ccbType.Location = new System.Drawing.Point(205, 9);
            this.ccbType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.ccbType.Name = "ccbType";
            this.ccbType.Size = new System.Drawing.Size(82, 22);
            this.ccbType.TabIndex = 18;
            this.ccbType.ValueSeparator = ", ";
            this.ccbType.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ccbType_ItemCheck);
            this.ccbType.DropDownClosed += new System.EventHandler(this.ccb_DropDownClosed);
            // 
            // MiscastFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpFilters);
            this.Name = "MiscastFilter";
            this.Size = new System.Drawing.Size(499, 113);
            this.Load += new System.EventHandler(this.MiscastFilter_Load);
            this.grpFilters.ResumeLayout(false);
            this.pnlComboHolder.ResumeLayout(false);
            this.pnlComboHolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.Panel pnlComboHolder;
        private Common.ThirdPartyControls.CheckedComboBox ccbRota;
        private System.Windows.Forms.Label lblRota;
        private Common.ThirdPartyControls.CheckedComboBox ccbArea;
        private Common.ThirdPartyControls.CheckedComboBox ccbFunction;
        private System.Windows.Forms.Label lblArea;
        private Common.ThirdPartyControls.CheckedComboBox ccbFailureMode;
        private System.Windows.Forms.Label lblFunction;
        private Common.ThirdPartyControls.CheckedComboBox ccbUnit;
        private Common.ThirdPartyControls.CheckedComboBox ccbRootCause;
        private Common.ThirdPartyControls.CheckedComboBox ccbType;
        private System.Windows.Forms.Label lblRootCause;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblStatus;
        private Common.ThirdPartyControls.CheckedComboBox ccbStatus;
    }
}
