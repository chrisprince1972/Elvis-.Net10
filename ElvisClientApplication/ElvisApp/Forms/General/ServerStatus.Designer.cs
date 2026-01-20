namespace Elvis.Forms.General
{
    partial class ServerStatus
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerStatus));
            this.grpServerStatus = new System.Windows.Forms.GroupBox();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlPTBOSAPP = new System.Windows.Forms.Panel();
            this.lblPTBOSAPP = new System.Windows.Forms.Label();
            this.pnlPSPI = new System.Windows.Forms.Panel();
            this.lblPS_PI = new System.Windows.Forms.Label();
            this.pnlPTCCINSQL = new System.Windows.Forms.Panel();
            this.lblPTCCINSQL = new System.Windows.Forms.Label();
            this.pnlPTPCSQLCLUSTER = new System.Windows.Forms.Panel();
            this.lblPTPCSQLCLUSTER = new System.Windows.Forms.Label();
            this.pnlPTSSELVISTEST = new System.Windows.Forms.Panel();
            this.lblPTSSELVISTEST = new System.Windows.Forms.Label();
            this.pnlPTCCL3SQL = new System.Windows.Forms.Panel();
            this.lblPTCCL3SQL = new System.Windows.Forms.Label();
            this.pnlRefresh = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpServerStatus.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlPTBOSAPP.SuspendLayout();
            this.pnlPSPI.SuspendLayout();
            this.pnlPTCCINSQL.SuspendLayout();
            this.pnlPTPCSQLCLUSTER.SuspendLayout();
            this.pnlPTSSELVISTEST.SuspendLayout();
            this.pnlPTCCL3SQL.SuspendLayout();
            this.pnlRefresh.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServerStatus
            // 
            this.grpServerStatus.Controls.Add(this.pnlStatus);
            this.grpServerStatus.Controls.Add(this.pnlRefresh);
            this.grpServerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpServerStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpServerStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpServerStatus.Location = new System.Drawing.Point(0, 0);
            this.grpServerStatus.Name = "grpServerStatus";
            this.grpServerStatus.Padding = new System.Windows.Forms.Padding(6, 4, 6, 6);
            this.grpServerStatus.Size = new System.Drawing.Size(178, 250);
            this.grpServerStatus.TabIndex = 1;
            this.grpServerStatus.TabStop = false;
            this.grpServerStatus.Text = "Server Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.AutoScroll = true;
            this.pnlStatus.Controls.Add(this.pnlPTBOSAPP);
            this.pnlStatus.Controls.Add(this.pnlPSPI);
            this.pnlStatus.Controls.Add(this.pnlPTCCINSQL);
            this.pnlStatus.Controls.Add(this.pnlPTPCSQLCLUSTER);
            this.pnlStatus.Controls.Add(this.pnlPTSSELVISTEST);
            this.pnlStatus.Controls.Add(this.pnlPTCCL3SQL);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Location = new System.Drawing.Point(6, 18);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(166, 201);
            this.pnlStatus.TabIndex = 11;
            // 
            // pnlPTBOSAPP
            // 
            this.pnlPTBOSAPP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPTBOSAPP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPTBOSAPP.Controls.Add(this.lblPTBOSAPP);
            this.pnlPTBOSAPP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPTBOSAPP.Location = new System.Drawing.Point(0, 140);
            this.pnlPTBOSAPP.Name = "pnlPTBOSAPP";
            this.pnlPTBOSAPP.Size = new System.Drawing.Size(166, 28);
            this.pnlPTBOSAPP.TabIndex = 11;
            this.toolTip1.SetToolTip(this.pnlPTBOSAPP, "PI data on the EBM chart will be unavailable if this server is down.");
            // 
            // lblPTBOSAPP
            // 
            this.lblPTBOSAPP.BackColor = System.Drawing.Color.Transparent;
            this.lblPTBOSAPP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPTBOSAPP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPTBOSAPP.Location = new System.Drawing.Point(0, 0);
            this.lblPTBOSAPP.Name = "lblPTBOSAPP";
            this.lblPTBOSAPP.Size = new System.Drawing.Size(164, 26);
            this.lblPTBOSAPP.TabIndex = 5;
            this.lblPTBOSAPP.Text = "PTBOSAPP - Elvis Data";
            this.lblPTBOSAPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblPTBOSAPP, "Populates the Main Elvis database with data.");
            // 
            // pnlPSPI
            // 
            this.pnlPSPI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPSPI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPSPI.Controls.Add(this.lblPS_PI);
            this.pnlPSPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPSPI.Location = new System.Drawing.Point(0, 112);
            this.pnlPSPI.Name = "pnlPSPI";
            this.pnlPSPI.Size = new System.Drawing.Size(166, 28);
            this.pnlPSPI.TabIndex = 10;
            this.toolTip1.SetToolTip(this.pnlPSPI, "PI data on the EBM chart will be unavailable if this server is down.");
            // 
            // lblPS_PI
            // 
            this.lblPS_PI.BackColor = System.Drawing.Color.Transparent;
            this.lblPS_PI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPS_PI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPS_PI.Location = new System.Drawing.Point(0, 0);
            this.lblPS_PI.Name = "lblPS_PI";
            this.lblPS_PI.Size = new System.Drawing.Size(164, 26);
            this.lblPS_PI.TabIndex = 5;
            this.lblPS_PI.Text = "PS_PI - PI Data";
            this.lblPS_PI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblPS_PI, "PI data on the EBM chart will be unavailable if this server is down.");
            // 
            // pnlPTCCINSQL
            // 
            this.pnlPTCCINSQL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPTCCINSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPTCCINSQL.Controls.Add(this.lblPTCCINSQL);
            this.pnlPTCCINSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPTCCINSQL.Location = new System.Drawing.Point(0, 84);
            this.pnlPTCCINSQL.Name = "pnlPTCCINSQL";
            this.pnlPTCCINSQL.Size = new System.Drawing.Size(166, 28);
            this.pnlPTCCINSQL.TabIndex = 9;
            this.toolTip1.SetToolTip(this.pnlPTCCINSQL, "Caster data on the Caster Trend screen will be missing if this is down.");
            // 
            // lblPTCCINSQL
            // 
            this.lblPTCCINSQL.BackColor = System.Drawing.Color.Transparent;
            this.lblPTCCINSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPTCCINSQL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPTCCINSQL.Location = new System.Drawing.Point(0, 0);
            this.lblPTCCINSQL.Name = "lblPTCCINSQL";
            this.lblPTCCINSQL.Size = new System.Drawing.Size(164, 26);
            this.lblPTCCINSQL.TabIndex = 5;
            this.lblPTCCINSQL.Text = "PTCCINSQL - Caster Data";
            this.lblPTCCINSQL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblPTCCINSQL, "Caster data on the Caster Trend screen will be missing if this is down.");
            // 
            // pnlPTPCSQLCLUSTER
            // 
            this.pnlPTPCSQLCLUSTER.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPTPCSQLCLUSTER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPTPCSQLCLUSTER.Controls.Add(this.lblPTPCSQLCLUSTER);
            this.pnlPTPCSQLCLUSTER.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPTPCSQLCLUSTER.Location = new System.Drawing.Point(0, 56);
            this.pnlPTPCSQLCLUSTER.Name = "pnlPTPCSQLCLUSTER";
            this.pnlPTPCSQLCLUSTER.Size = new System.Drawing.Size(166, 28);
            this.pnlPTPCSQLCLUSTER.TabIndex = 8;
            this.toolTip1.SetToolTip(this.pnlPTPCSQLCLUSTER, "Miscast data will be missing if this server is down.");
            // 
            // lblPTPCSQLCLUSTER
            // 
            this.lblPTPCSQLCLUSTER.BackColor = System.Drawing.Color.Transparent;
            this.lblPTPCSQLCLUSTER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPTPCSQLCLUSTER.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPTPCSQLCLUSTER.Location = new System.Drawing.Point(0, 0);
            this.lblPTPCSQLCLUSTER.Name = "lblPTPCSQLCLUSTER";
            this.lblPTPCSQLCLUSTER.Size = new System.Drawing.Size(164, 26);
            this.lblPTPCSQLCLUSTER.TabIndex = 3;
            this.lblPTPCSQLCLUSTER.Text = "PTPCSQLCLUSTER - Miscast";
            this.lblPTPCSQLCLUSTER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblPTPCSQLCLUSTER, "Miscast data will be missing if this server is down.");
            // 
            // pnlPTSSELVISTEST
            // 
            this.pnlPTSSELVISTEST.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPTSSELVISTEST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPTSSELVISTEST.Controls.Add(this.lblPTSSELVISTEST);
            this.pnlPTSSELVISTEST.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPTSSELVISTEST.Location = new System.Drawing.Point(0, 28);
            this.pnlPTSSELVISTEST.Name = "pnlPTSSELVISTEST";
            this.pnlPTSSELVISTEST.Size = new System.Drawing.Size(166, 28);
            this.pnlPTSSELVISTEST.TabIndex = 7;
            this.toolTip1.SetToolTip(this.pnlPTSSELVISTEST, "Test Server - Only development versions will be effected if this is down.");
            // 
            // lblPTSSELVISTEST
            // 
            this.lblPTSSELVISTEST.BackColor = System.Drawing.Color.Transparent;
            this.lblPTSSELVISTEST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPTSSELVISTEST.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPTSSELVISTEST.Location = new System.Drawing.Point(0, 0);
            this.lblPTSSELVISTEST.Name = "lblPTSSELVISTEST";
            this.lblPTSSELVISTEST.Size = new System.Drawing.Size(164, 26);
            this.lblPTSSELVISTEST.TabIndex = 2;
            this.lblPTSSELVISTEST.Text = "PTSSELVISTEST - Test Server";
            this.lblPTSSELVISTEST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblPTSSELVISTEST, "Test Server - Only development versions will be effected if this is down.");
            // 
            // pnlPTCCL3SQL
            // 
            this.pnlPTCCL3SQL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPTCCL3SQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPTCCL3SQL.Controls.Add(this.lblPTCCL3SQL);
            this.pnlPTCCL3SQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPTCCL3SQL.Location = new System.Drawing.Point(0, 0);
            this.pnlPTCCL3SQL.Name = "pnlPTCCL3SQL";
            this.pnlPTCCL3SQL.Size = new System.Drawing.Size(166, 28);
            this.pnlPTCCL3SQL.TabIndex = 6;
            this.toolTip1.SetToolTip(this.pnlPTCCL3SQL, "Main Elvis Server - If this is down then most features will not work.");
            // 
            // lblPTCCL3SQL
            // 
            this.lblPTCCL3SQL.BackColor = System.Drawing.Color.Transparent;
            this.lblPTCCL3SQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPTCCL3SQL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPTCCL3SQL.Location = new System.Drawing.Point(0, 0);
            this.lblPTCCL3SQL.Name = "lblPTCCL3SQL";
            this.lblPTCCL3SQL.Size = new System.Drawing.Size(164, 26);
            this.lblPTCCL3SQL.TabIndex = 1;
            this.lblPTCCL3SQL.Text = "PTCCL3SQL - Main Server";
            this.lblPTCCL3SQL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblPTCCL3SQL, "Main Elvis Server - If this is down then most features will not work.");
            // 
            // pnlRefresh
            // 
            this.pnlRefresh.Controls.Add(this.btnRefresh);
            this.pnlRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRefresh.Location = new System.Drawing.Point(6, 219);
            this.pnlRefresh.Name = "pnlRefresh";
            this.pnlRefresh.Size = new System.Drawing.Size(166, 25);
            this.pnlRefresh.TabIndex = 10;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(166, 25);
            this.btnRefresh.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh (F5)");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            // 
            // ServerStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpServerStatus);
            this.Name = "ServerStatus";
            this.Size = new System.Drawing.Size(178, 250);
            this.grpServerStatus.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlPTBOSAPP.ResumeLayout(false);
            this.pnlPSPI.ResumeLayout(false);
            this.pnlPTCCINSQL.ResumeLayout(false);
            this.pnlPTPCSQLCLUSTER.ResumeLayout(false);
            this.pnlPTSSELVISTEST.ResumeLayout(false);
            this.pnlPTCCL3SQL.ResumeLayout(false);
            this.pnlRefresh.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpServerStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlRefresh;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlPTCCINSQL;
        private System.Windows.Forms.Label lblPTCCINSQL;
        private System.Windows.Forms.Panel pnlPTPCSQLCLUSTER;
        private System.Windows.Forms.Label lblPTPCSQLCLUSTER;
        private System.Windows.Forms.Panel pnlPTSSELVISTEST;
        private System.Windows.Forms.Label lblPTSSELVISTEST;
        private System.Windows.Forms.Panel pnlPTCCL3SQL;
        private System.Windows.Forms.Label lblPTCCL3SQL;
        private System.Windows.Forms.Panel pnlPSPI;
        private System.Windows.Forms.Label lblPS_PI;
        private System.Windows.Forms.Panel pnlPTBOSAPP;
        private System.Windows.Forms.Label lblPTBOSAPP;
    }
}
