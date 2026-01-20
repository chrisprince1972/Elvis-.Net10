using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.UserControls.HeatDetails
{
    public partial class ScrapUserControl : UserControl
    {
        #region Variables and Properties
        private int heatNumber;
        private int heatNumberSet;
        private bool pageError = false;
        private List<Unit> units;
        private List<ScrapType> scrapTypes;
        private List<Addition> scrapAdditions;
        private List<ScrapDemand> scrapDemands;
        private List<ScrapBoxStatusEvent> scrapEvents;
        private List<ScrapBoxType> scrapBoxTypeLookup;
        private List<ScrapEventType> scrapEventTypeLookup;
        private ScrapBoxLoad scrapLoad = new ScrapBoxLoad();
        
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor and Form Setup
        /// <summary>
        /// Initializes a new instance of the CBM User Control class.
        /// </summary>
        public ScrapUserControl()
        {
            InitializeComponent();
            dgvScrapDetails.AutoGenerateColumns = false;
            dgvScrapEvent.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            CustomiseColours();
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

        /// <summary>
        /// Form load method, included to allow clearing of selections in dgvScrapCar and dgvScrapEvent. Rows are manually
        /// added to the grid so DataBindingComplete methoed is not suitable for this task.
        /// </summary>
        private void ScrapUserControl_Load(object sender, EventArgs e)
        {
            dgvScrapEvent.ClearSelection();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                pnlScrapCar.BackColor =
                pnlScrapEvent.BackColor =
                pnlTreatmentDetails.BackColor =
                grpTreatmentDetails.BackColor =
                grpScrapDetails.BackColor =
                dgvScrapDetails.BackgroundColor =
                dgvScrapEvent.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                pnlScrapCar.ForeColor =
                pnlScrapEvent.ForeColor =
                pnlTreatmentDetails.ForeColor =
                grpTreatmentDetails.ForeColor =
                grpScrapDetails.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Gets the data for the form and stores in variables.
        /// </summary>
        /// <returns>If any get datas fail then true, otherwise false.</returns>
        private bool GetData()
        {
            bool hasErrors = false;
            this.scrapAdditions = new List<Addition>();
            this.scrapEvents = new List<ScrapBoxStatusEvent>();
            this.scrapLoad = new ScrapBoxLoad();
            this.scrapEventTypeLookup = new List<ScrapEventType>();
            this.scrapTypes = new List<ScrapType>();
            this.scrapDemands = new List<ScrapDemand>();

            try
            {
                this.scrapAdditions = EntityHelper.Additions.GetByHeatNumber(
                    this.heatNumber, 
                    this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Scrap Details -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
                hasErrors = true;
            }

            try
            {
                this.scrapEvents = EntityHelper.ScrapBoxStatusEvent.GetByHeatNumber(
                    this.heatNumber,
                    this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Scrap Box Status Events -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
                hasErrors = true;
            }

            try
            {
                this.scrapLoad = EntityHelper.ScrapBoxLoad.GetByHeatNumber(
                    this.heatNumber, 
                    this.heatNumberSet
                    );
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Scrap Box Load -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
                hasErrors = true;
            }

            try
            {
                this.scrapDemands = EntityHelper.ScrapDemand.GetByHeatNumber(this.heatNumber, this.heatNumberSet);
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Scrap Demands -- HeatNumber: {0}, HNS: {1} -- ",
                        this.heatNumber,
                        this.heatNumberSet),
                    ex);
                hasErrors = true;
            }

            try
            {
                this.scrapEventTypeLookup = EntityHelper.ScrapEventTypes.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Scrap Event Types Lookup -- ",
                    ex);
                hasErrors = true;
            }

            try
            {
                this.units = EntityHelper.Units.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Get Units -- ",
                    ex);
                hasErrors = true;
            }

            try
            {
                this.scrapBoxTypeLookup = EntityHelper.ScrapBoxTypes.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Scrap Box Lookup -- ",
                    ex);
                hasErrors = true;
            }

            try
            {
                this.scrapTypes = EntityHelper.ScrapTypes.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- SCRAP USER CONTROL -- GetData() -- Scrap Box Lookup -- ",
                    ex);
                hasErrors = true;
            }
            return hasErrors;
        }


        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            CommonMethods.LoadImageIntoPanel(
                Resources.loadingBlack, this, pnlMain);
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Populates the form with the data from the database.
        /// Hides the Loading Screen.
        /// </summary>
        private void PopulateForm()
        {
            this.Controls.Clear();
            this.Controls.Add(pnlMain);
            pnlMain.Visible = true;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BringToFront();

            if (this.scrapAdditions != null && this.scrapTypes != null &&
                this.scrapDemands != null)
            {
                //dgvScrapDetails.DataSource = scrapDetails;
                BindScrapDetailsGridview(BuildScrapDetails());
            }

            if (this.scrapEvents != null)
            {
                BindScrapEventGridview(BuildScrapEvents());
                PopulateScrapCar(BuildScrapCarInfo());
            }
        }

        /// <summary>
        /// Binds the ScrapDetails DataGridview with the list passed in.
        /// </summary>
        /// <param name="scrapDetails">The List of ScrapDetail to bind.</param>
        private void BindScrapDetailsGridview(List<ScrapDetail> scrapDetails)
        {
            dgvScrapDetails.DataSource = null;
            dgvScrapDetails.DataSource = scrapDetails;
        }

        /// <summary>
        /// Binds the ScrapEvent DataGridview with the list passed in.
        /// </summary>
        /// <param name="scrapEventInfos">The List of ScrapEventinfos to bind.</param>
        private void BindScrapEventGridview(List<ScrapEventInfo> scrapEventInfos)
        {
            dgvScrapEvent.DataSource = null;
            dgvScrapEvent.DataSource = scrapEventInfos;
        }

        /// <summary>
        /// Binds the Scrap Car Data to the textboxes.
        /// </summary>
        /// <param name="scrapEventInfos">A ScrapCarInfo object with the data to populate.</param>
        private void PopulateScrapCar(ScrapCarInfo scrapCarInfo)
        {
            txtScrapCar.Text = scrapCarInfo.ScrapCar;
            txtScrapBoxType.Text = scrapCarInfo.ScrapBoxType;
        }

        /// <summary>
        /// Builds the scrao detail objects for the DataGridview
        /// </summary>
        /// <returns>A list of scrap detail objects.</returns>
        private List<ScrapDetail> BuildScrapDetails()
        {
            List<ScrapDetail> scrapDetails = new List<ScrapDetail>();

            foreach (ScrapDemand demand in this.scrapDemands)
            {
                //Find the associated addition.
                Addition addition = this.scrapAdditions.FirstOrDefault(s => s.Material == demand.MaterialCode);

                //Build the Object
                ScrapDetail detail = new ScrapDetail();
                detail.Description = GetMaterialDescription(demand.MaterialCode);
                detail.MenuWeight = HelperFunctions.GetIntSafely(demand.DemandWeight);
                if (addition != null)
                {
                    detail.RequiredWeight = HelperFunctions.GetIntSafely(addition.RequestWeight);
                    detail.ActualWeight = HelperFunctions.GetIntSafely(addition.AddedWeight);
                }
                scrapDetails.Add(detail);
            }

            return scrapDetails;
        }

        /// <summary>
        /// Gets the description from the list of types using the material code
        /// </summary>
        /// <param name="materialCode">The MAterial Code e.g. SCRAP_A</param>
        /// <returns>The Description for that Material.</returns>
        private string GetMaterialDescription(string materialCode)
        {
            if (this.scrapTypes != null)
            {
                ElvisDataModel.EDMX.ScrapType type = this.scrapTypes.FirstOrDefault(s => s.Code == materialCode);
                if (type != null)
                {
                    return type.Description;
                }
            }
            return "Error";
        }

        /// <summary>
        /// Builds the scrap events DataGridview
        /// </summary>
        /// <returns>A list of ScrapEventInfo objects.</returns>
        private List<ScrapEventInfo> BuildScrapEvents()
        {
            List<ScrapEventInfo> scrapEventInfos = new List<ScrapEventInfo>();
            if (this.scrapEvents != null)
            {
                foreach (ScrapBoxStatusEvent scrapEvent in this.scrapEvents)
                {
                    ScrapEventInfo scrapInfo = new ScrapEventInfo();
                    ScrapEventType scrapType = this.scrapEventTypeLookup
                        .FirstOrDefault(s =>
                            s.ScrapEventTypeID == scrapEvent.ScrapEventTypeID
                            );

                    if (scrapType != null)
                    {
                        //Build Row.
                        scrapInfo.ScrapBoxStatusEventID = scrapEvent.ScrapBoxStatusEventID;
                        scrapInfo.ScrapEventTypeID = scrapEvent.ScrapEventTypeID;
                        scrapInfo.EventDescription = scrapType.Description;
                        scrapInfo.EventTime = scrapEvent.ScrapEventTimeStamp;
                        //Add to List.
                        scrapEventInfos.Add(scrapInfo);
                    }
                }
            }
            return scrapEventInfos;
        }

        /// <summary>
        /// Builds the scrap car data object.
        /// </summary>
        private ScrapCarInfo BuildScrapCarInfo()
        {
            ScrapCarInfo carInfo = new ScrapCarInfo();
            if (this.scrapBoxTypeLookup != null &&
                this.scrapLoad != null)
            {
                ScrapBoxType scrapBoxType = this.scrapBoxTypeLookup
                    .FirstOrDefault(s =>
                        s.ScrapBoxTypeID == this.scrapLoad.ScrapBoxTypeID
                        );

                Unit scrapUnit = this.units
                    .FirstOrDefault(u =>
                        u.UnitNumber == this.scrapLoad.UnitID
                        );

                if (scrapBoxType != null)
                {
                    carInfo.ScrapBoxType = scrapBoxType.Description;
                }

                if (scrapUnit != null)
                {
                    if (scrapUnit.UnitShort.ToUpper().Contains("SCRAP"))
                        carInfo.ScrapCar = scrapUnit.UnitShort.Substring(5, 5);
                    else
                        carInfo.ScrapCar = scrapUnit.UnitShort;
                }
            }
            return carInfo;
        }

        /// Shows an error screen if page has errored.
        /// </summary>
        private void ShowErrorForm()
        {
            CommonMethods.LoadImageIntoPanel(Resources.error, this, pnlMain);
        }
        #endregion

        #region Events
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
            }
            else
            {
                ShowErrorForm();
            }
        }

        /// <summary>
        /// Clears selection once binding is complete.
        /// </summary>
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView dgv = (DataGridView)sender;
                dgv.ClearSelection();
            }
        }
        #endregion
    }

    #region Supporting Classes
    class ScrapCarInfo
    {
        public string ScrapCar { get; set; }
        public string ScrapBoxType { get; set; }
    }

    class ScrapEventInfo
    {
        public int ScrapBoxStatusEventID { get; set; }
        public int ScrapEventTypeID { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventTime { get; set; }
    }

    class ScrapDetail
    {
        public string Description { get; set; }
        public int MenuWeight { get; set; }
        public int RequiredWeight { get; set; }
        public int ActualWeight { get; set; }
    }
    #endregion
}
