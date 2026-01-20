namespace Elvis.UserControls
{
	partial class BaseScheduler
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
            MLJSystems.Calendars.Resource resource1 = new MLJSystems.Calendars.Resource();
            this.scheduler = new MLJSystems.Calendars.ResourceScheduler();
            this.SuspendLayout();
            // 
            // scheduler
            // 
            this.scheduler.AllowDrop = false;
            this.scheduler.AppointmentBoxStyle = MLJSystems.Calendars.AppointmentBoxStyle.SmallBox;
            this.scheduler.AvailableResolutions = MLJSystems.Calendars.HoursResolutions.One;
            this.scheduler.BackColor = System.Drawing.Color.White;
            this.scheduler.BehaviorsOptions = MLJSystems.Calendars.BehaviorOptions.DenyResourceChange;
            this.scheduler.CalendarVersion = 1;
            this.scheduler.CellWidth = 30;
            this.scheduler.ConnectorStyle = MLJSystems.Calendars.ConnectorStyle.DashLine;
            this.scheduler.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduler.DatesLabelColor = System.Drawing.Color.White;
            this.scheduler.DatesLabelColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(126)))), ((int)(((byte)(219)))));
            this.scheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduler.FirstDateTime = new System.DateTime(2013, 8, 1, 0, 0, 0, 0);
            this.scheduler.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduler.ForeColor = System.Drawing.SystemColors.ControlText;
            this.scheduler.FreeDay = MLJSystems.Calendars.FreeDays.None;
            this.scheduler.FreeHourColor = System.Drawing.SystemColors.Control;
            this.scheduler.HeaderStyle = MLJSystems.Calendars.ResourceSchedulerHeaderStyle.Ruler;
            this.scheduler.HoursResolution = MLJSystems.Calendars.HoursResolutions.One;
            this.scheduler.ImageAlign = MLJSystems.Calendars.ImageHAlign.Left;
            this.scheduler.LineColor = System.Drawing.Color.Silver;
            this.scheduler.Location = new System.Drawing.Point(0, 0);
            this.scheduler.Name = "scheduler";
            resource1.SubItems.Add(new MLJSystems.Calendars.ResourceItem(""));
            resource1.SubItems.Add(new MLJSystems.Calendars.ResourceItem(""));
            resource1.SubItems.Add(new MLJSystems.Calendars.ResourceItem(""));
            this.scheduler.Resources.Add(resource1);
            this.scheduler.ResourcesLabelColor = System.Drawing.Color.WhiteSmoke;
            this.scheduler.RowHeight = 23;
            this.scheduler.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.scheduler.SelectedAppointmentColor = System.Drawing.Color.Lime;
            this.scheduler.ShowVerticalGridLine = false;
            this.scheduler.Size = new System.Drawing.Size(875, 606);
            this.scheduler.TabIndex = 4;
            this.scheduler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduler.TodayMarkerColor = System.Drawing.Color.White;
            this.scheduler.TodayTimelineVisible = true;
            this.scheduler.WeekRule = System.Globalization.CalendarWeekRule.FirstDay;
            this.scheduler.WorkHourBegin = System.TimeSpan.Parse("00:00:00");
            this.scheduler.WorkHourColor = System.Drawing.Color.WhiteSmoke;
            this.scheduler.WorkHourColorSecond = System.Drawing.Color.WhiteSmoke;
            this.scheduler.WorkHourEnd = System.TimeSpan.Parse("24.00:00:00");
            // 
            // BaseScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scheduler);
            this.DoubleBuffered = true;
            this.Name = "BaseScheduler";
            this.Size = new System.Drawing.Size(875, 606);
            this.ResumeLayout(false);

        }

        #endregion

        public MLJSystems.Calendars.ResourceScheduler scheduler;




    }
}
