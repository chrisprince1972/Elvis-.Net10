using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class HeatDetailsOverview : UserControl
    {
        #region Variables + Properties
        private int heatNumber;
        private int heatNumberSet;
        private bool hasLoaded = false;
        private bool pageError = false;
        private DateTime? tapTime;
        private List<HeatDetailsEvent> heatEvents;
        private BackgroundWorker worker = new BackgroundWorker();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowForAllUnits
        {
            get { return chbShowAllEvents.Checked; }
            set
            {
                chbShowAllEvents.Checked = value;

                if (chbShowAllEvents.Checked)
                {
                    ucHeatLogDisplay.SetupUserControl(this.heatNumber, this.heatNumberSet, 0);
                    grpSubEvents.Text = "Heat Log for All Units";
                    gdvHeatEvents.ClearSelection();
                }
                else if (gdvHeatEvents.Rows != null &&
                         gdvHeatEvents.Rows.Count > 0)
                {
                    if (gdvHeatEvents.SelectedRows.Count == 0)
                        gdvHeatEvents.CurrentRow.Selected = true;

                    HeatDetailsEvent heatEvent = gdvHeatEvents.CurrentRow.DataBoundItem as HeatDetailsEvent;
                    if (heatEvent != null)
                    {
                        ucHeatLogDisplay.SetupUserControl(this.heatNumber, this.heatNumberSet, heatEvent.UnitNumber);
                        grpSubEvents.Text = "Heat Log for " + heatEvent.UnitShort;
                    }
                }
            }
        }

        #endregion

        #region Constructor and Form Setup
        /// <summary>
        /// Initializes a new instance of the Heat Details Overview User Control class.
        /// </summary>
        public HeatDetailsOverview()
        {
            InitializeComponent();
            gdvHeatEvents.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            CommonMethods.LoadImageIntoPanel(Resources.loadingBlack, this, pnlMain);
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Sets up the background worker that gets the data.
        /// </summary>
        private void SetupBackgroundWorker()
        {
            //Shove the DB access on a different thread to protect the UI.
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                gdvHeatEvents.BackgroundColor =
                grpTapTime.BackColor =
                grpProcessDetails.BackColor =
                grpSubEvents.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                grpProcessDetails.ForeColor =
                grpSubEvents.ForeColor =
                grpTapTime.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the data for the form and stores in variables.
        /// </summary>
        /// <returns>If all get datas fail then true, otherwise false.</returns>
        private bool GetData()
        {
            //if all fail, then error
            bool errorHeatEvent = false;
            bool errorHeatLog = false;
            bool errorTapTime = false;

            try
            {
                this.heatEvents = EntityHelper.HeatDetailsEvent.GetByHeat(
                    this.heatNumber,
                    this.heatNumberSet
                    );
                AddMissingProgramNumbers();
            }
            catch (Exception ex)
            {
                errorHeatEvent = true;
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR HEAT DETAILS -- GetData() -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
            }

            try
            {
                this.tapTime = EntityHelper.HeatLog.GetTapTimeByHeat(
                    this.heatNumber,
                    this.heatNumberSet
                    );
            }
            catch (Exception ex)
            {
                errorTapTime = true;
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR TAP TIME -- GetData() -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
            }

            if (errorHeatEvent && errorHeatLog && errorTapTime)
                return true;
            return false;
        }

        /// <summary>
        /// Populates the form with the data from the database.
        /// </summary>
        private void PopulateForm()
        {
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();
            //Clear the existing data.
            gdvHeatEvents.DataSource = null;
            txtDate.Text = "";
            txtTime.Text = "";
            txtRota.Text = "";
            txtDay.Text = "";
            txtWeek.Text = "";
            txtYear.Text = "";

            if (this.heatEvents != null)
            {
                gdvHeatEvents.DataSource = this.heatEvents;
                gdvHeatEvents.ClearSelection();
            }

            if (this.tapTime != null && this.tapTime.HasValue)
            {
                txtDate.Text = this.tapTime.Value.ToString("dd/MM/yyyy");
                txtTime.Text = this.tapTime.Value.ToString("HH:mm:ss");

                try
                {
                    txtRota.Text = EntityHelper.DateInfo.GetRotaByDate(this.tapTime.Value);
                    txtRota.Text = txtRota.Text.Trim();
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        string.Format(
                            "DATA ERROR HEAT DETAILS -- GetRotaByDate() -- Date: {0} -- ",
                            this.tapTime.Value),
                        ex);
                    txtRota.Text = "#";
                }

                txtDay.Text = (TimeFunctions.DayOfWeek_PT(this.tapTime.Value) + 1).ToString();
                txtWeek.Text = TimeFunctions.GetWeekNumber(this.tapTime.Value).ToString();
                txtYear.Text = this.tapTime.Value.ToString("yyyy");
            }
        }


        /// <summary>
        /// Method that adds in missing values for program number
        /// in the list of events.  Simply loops around looking for
        /// nulls and adds in the previous if the value is null.
        /// </summary>
        private void AddMissingProgramNumbers()
        {
            int programNo = 0;
            foreach (HeatDetailsEvent heatEvent in this.heatEvents)
            {
                if (heatEvent != null && heatEvent.ProgramNumber.HasValue)
                {
                    programNo = heatEvent.ProgramNumber.Value;
                }
                else if (heatEvent != null &&
                    !heatEvent.ProgramNumber.HasValue &&
                    programNo > 0)
                {
                    heatEvent.ProgramNumber = programNo;
                }
            }
        }

        /// <summary>
        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMain);
        }

        #region Events
        /// <summary>
        /// DataGridview Selection Change event handler.
        /// </summary>
        private void gdvHeatEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (!chbShowAllEvents.Checked &&
                gdvHeatEvents.SelectedRows.Count > 0 &&
                gdvHeatEvents.CurrentRow != null)
            {//Filter heat log specifically to an Event
                ShowForAllUnits = false;
            }

            if (this.hasLoaded &&
                chbShowAllEvents.Checked && 
                gdvHeatEvents.SelectedRows.Count > 0 &&
                gdvHeatEvents.CurrentRow != null)
            {//Filter heat log and change parents state if selecting a row when show all is clicked.

                Form parentForm = FormControl.FindParentForm(this);

                if (parentForm is Elvis.HeatDetails)
                {
                    Elvis.HeatDetails heatDetails = parentForm as Elvis.HeatDetails;
                    heatDetails.ShowAllEvents = false;
                }
            }
        }

        /// <summary>
        /// Form load event handler.
        /// </summary>
        private void ProcHeatDetails_Load(object sender, EventArgs e)
        {
            this.hasLoaded = true;
        }

        /// <summary>
        /// Checkbox checked changed event handler.
        /// Shows all events or single unit events.
        /// </summary>
        private void chbShowAllEvents_CheckedChanged(object sender, EventArgs e)
        {
            if (this.hasLoaded)
            {
                ShowForAllUnits = chbShowAllEvents.Checked;
                Form parentForm = FormControl.FindParentForm(this);

                if (parentForm is Elvis.HeatDetails)
                {
                    Elvis.HeatDetails heatDetails = parentForm as Elvis.HeatDetails;
                    heatDetails.ShowAllEvents = chbShowAllEvents.Checked;
                }
            }
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.pageError = GetData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this.pageError)
            {
                PopulateForm();
                ShowForAllUnits = true;
            }
            else
            {
                ShowErrorForm();
            }
        }
        #endregion

        #endregion
    }
}
