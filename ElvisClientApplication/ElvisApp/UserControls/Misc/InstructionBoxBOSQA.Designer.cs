namespace Elvis.UserControls.Misc
{
    partial class InstructionBoxBOSQA
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
            this.grpInstruction = new System.Windows.Forms.GroupBox();
            this.txtInstruction = new System.Windows.Forms.TextBox();
            this.grpInstruction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInstruction
            // 
            this.grpInstruction.Controls.Add(this.txtInstruction);
            this.grpInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInstruction.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInstruction.Location = new System.Drawing.Point(3, 3);
            this.grpInstruction.Name = "grpInstruction";
            this.grpInstruction.Padding = new System.Windows.Forms.Padding(6);
            this.grpInstruction.Size = new System.Drawing.Size(364, 144);
            this.grpInstruction.TabIndex = 0;
            this.grpInstruction.TabStop = false;
            this.grpInstruction.Text = "Insert Unit Here";
            // 
            // txtInstruction
            // 
            this.txtInstruction.BackColor = System.Drawing.SystemColors.Window;
            this.txtInstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInstruction.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstruction.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInstruction.Location = new System.Drawing.Point(6, 20);
            this.txtInstruction.Multiline = true;
            this.txtInstruction.Name = "txtInstruction";
            this.txtInstruction.ReadOnly = true;
            this.txtInstruction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInstruction.Size = new System.Drawing.Size(352, 118);
            this.txtInstruction.TabIndex = 0;
            this.txtInstruction.Text = "This is text and this is an instruction. This is text and this is an instruction." +
    " This is text and this is an instruction.";
            this.txtInstruction.TextChanged += new System.EventHandler(this.txtInstruction_TextChanged);
            // 
            // InstructionBoxBOSQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.grpInstruction);
            this.MinimumSize = new System.Drawing.Size(0, 54);
            this.Name = "InstructionBoxBOSQA";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(370, 150);
            this.grpInstruction.ResumeLayout(false);
            this.grpInstruction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInstruction;
        private System.Windows.Forms.TextBox txtInstruction;
    }
}
