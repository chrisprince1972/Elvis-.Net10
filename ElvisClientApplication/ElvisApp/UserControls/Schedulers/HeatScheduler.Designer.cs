namespace Elvis.UserControls
{
    partial class HeatScheduler
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.SuspendLayout();
            // 
            // scheduler
            // 
            this.scheduler.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.scheduler.FirstDateTimeChanged += new System.EventHandler(this.scheduler_FirstDateTimeChanged);
            this.scheduler.AppointmentClick += new System.EventHandler<MLJSystems.Calendars.AppointmentClickEventArgs>(this.scheduler_AppointmentClick);
            this.scheduler.PaintAppointment += new MLJSystems.Calendars.PaintAppointmentEventHandler(this.scheduler_PaintAppointment);
            this.scheduler.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.scheduler_MouseDoubleClick);
            this.scheduler.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scheduler_MouseMove);
            // 
            // HeatScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "HeatScheduler";
            this.ResumeLayout(false);

        }

        #endregion

    }
}
