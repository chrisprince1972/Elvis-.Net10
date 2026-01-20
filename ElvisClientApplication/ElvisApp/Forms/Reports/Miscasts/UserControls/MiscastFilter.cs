using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Common.ThirdPartyControls;
using ElvisDataModel.EDMX;
using NLog;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    public partial class MiscastFilter : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private BackgroundWorker worker = new BackgroundWorker();
        private MiscastLookups miscastLookups;
        private bool runCCBEventHandler = false;

        /// <summary>
        /// Fires when a Checked Combo Box Closes menu.
        /// </summary>
        public delegate void CheckedComboBoxClosed();

        public event CheckedComboBoxClosed CheckedComboBoxClosedEvent;

        /// <summary>
        /// Fires when form is ready and loaded.
        /// </summary>
        public delegate void MiscastFilterLoaded();

        public event MiscastFilterLoaded MiscastFilterLoadedEvent;

        public string Filter
        {
            get { return GenerateFilter(); }
        }

        public MiscastLookups MiscastLookups
        {
            get { return this.miscastLookups; }
        }

        public MiscastFilter()
        {
            InitializeComponent();
            SetupBackgroundWorker();

            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Sets up the background worker control to load data
        /// asynchronously
        /// </summary>
        private void SetupBackgroundWorker()
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerSupportsCancellation = true;
        }

        public void Reset()
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        private void GetData()
        {
            this.miscastLookups = new MiscastLookups("All");
        }

        /// <summary>
        /// Background worker event to get the forms data.
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// Background worker completed event.
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.miscastLookups != null)
            {
                PopulateCheckedComboBoxes();
                if (this.MiscastFilterLoadedEvent != null)
                {
                    this.MiscastFilterLoadedEvent();
                }
            }
        }

        private void PopulateCheckedComboBoxes()
        {
            CommonMethods.ReadyCheckedComboBox(ccbFunction, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbType, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbRota, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbUnit, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbFailureMode, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbArea, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbRootCause, 8, ", ");
            CommonMethods.ReadyCheckedComboBox(ccbStatus, 8, ", ");

            PopulateFunction();
            PopulateType();
            PopulateRota();
            PopulateUnit();
            PopulateFailureMode();
            PopulateArea();
            PopulateRootCause();
            PopulateStatus();

            this.runCCBEventHandler = true;
        }

        private void PopulateFunction()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastFunction function in this.miscastLookups.Functions)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    function.TrioFunction,
                    function.FunctionID);

                ccbFunction.Items.Add(ccbItem);
                ccbFunction.SetItemChecked(i, true);
                i++;
            }
        }

        private void PopulateType()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastType type in this.miscastLookups.Types)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    type.Type,
                    type.MiscastTypeID);

                ccbType.Items.Add(ccbItem);
                ccbType.SetItemChecked(i, true);
                i++;
            }
        }

        private void PopulateRota()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastRota rota in this.miscastLookups.Rotas)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    rota.Rota,
                    rota.RotaID);

                ccbRota.Items.Add(ccbItem);
                ccbRota.SetItemChecked(i, true);
                i++;
            }
        }

        private void PopulateUnit()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastUnit unit in this.miscastLookups.Units)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    unit.MiscastUnit1,
                    unit.MiscastUnitID);

                ccbUnit.Items.Add(ccbItem);
                ccbUnit.SetItemChecked(i, true);
                i++;
            }
        }

        private void PopulateFailureMode()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastFailureMode failureMode in this.miscastLookups.FailureModes)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    failureMode.FailureMode,
                    failureMode.FailureModeID);

                ccbFailureMode.Items.Add(ccbItem);
                ccbFailureMode.SetItemChecked(i, true);
                i++;
            }
        }

        private void PopulateArea()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastAreaResponsible area in this.miscastLookups.Areas)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    area.AreaResponsible,
                    area.AreaResponsibleID);

                ccbArea.Items.Add(ccbItem);
                ccbArea.SetItemChecked(i, true);
                i++;
            }
        }

        private void PopulateRootCause()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastRootCause rootCause in this.miscastLookups.RootCauses)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    rootCause.RootCause,
                    rootCause.RootCauseID);

                ccbRootCause.Items.Add(ccbItem);
                ccbRootCause.SetItemChecked(i, true);
                i++;
            }
        }

        private void PopulateStatus()
        {
            int i = 0;//Keep an eye on the indexing of the list

            //Loop data and add them to checked combo box.
            foreach (MiscastStatu status in this.miscastLookups.Statuses)
            {
                CCBoxItem ccbItem = new CCBoxItem(
                    status.Status,
                    status.MiscastStatusID);

                ccbStatus.Items.Add(ccbItem);
                ccbStatus.SetItemChecked(i, true);
                i++;
            }
        }

        /// <summary>
        /// Generates the Dynamic filter text ready for
        /// filtering the data.
        /// </summary>
        private string GenerateFilter()
        {
            StringBuilder sbFilter = new StringBuilder();

            AddFilterForCheckComboBox(ccbFunction, "MiscastFunctionID", sbFilter);
            AddFilterForCheckComboBox(ccbType, "MiscastTypeID", sbFilter);
            AddFilterForCheckComboBox(ccbRota, "MiscastRotaID", sbFilter);
            AddFilterForCheckComboBox(ccbUnit, "MiscastUnitID", sbFilter);
            AddFilterForCheckComboBox(ccbFailureMode, "MiscastFailureModeID", sbFilter);
            AddFilterForCheckComboBox(ccbArea, "MiscastAreaResponsibleID", sbFilter);
            AddFilterForCheckComboBox(ccbRootCause, "RootCauseID", sbFilter);
            AddFilterForCheckComboBox(ccbStatus, "MiscastStatusID", sbFilter);

            if (sbFilter.Length <= 0)//No Filter Value
                sbFilter.Append("1 = 1");

            return sbFilter.ToString();
        }

        /// <summary>
        /// Method for handling the generation of the 
        /// filters for the CheckedComboBoxes
        /// </summary>
        /// <param name="ccb">The CheckedComboBox to base the filter on.</param>
        /// <param name="columnName">The Name of the Column in the database.</param>
        /// <param name="sbFilter">The Outstanding Filter Object.</param>
        private void AddFilterForCheckComboBox(CheckedComboBox ccb, string columnName, StringBuilder sbFilter)
        {
            if (ccb.Items.Count > 0 &&
                ccb.CheckedItems != null &&
                !ccb.CheckedItems.Contains(ccb.Items[0])) //only filter if 'All' is not checked
            {
                if (sbFilter.Length > 0)
                    sbFilter.Append(" AND ");

                if (ccb.CheckedItems.Count == 0)
                {//Unchecked all so no data should be returned. Random text that will never return a result.
                    sbFilter.Append("it.MiscastID == 0");
                }
                else
                {
                    //Find last item in the list.
                    CCBoxItem lastItem = (CCBoxItem)ccb.CheckedItems[ccb.CheckedItems.Count - 1];

                    sbFilter.Append("(");
                    foreach (CCBoxItem item in ccb.CheckedItems)
                    {//Build filter from selected items.
                        sbFilter.AppendFormat("it.{0} == {1}", columnName, item.Value);
                        if (item != lastItem)
                            sbFilter.Append(" OR ");
                    }
                    sbFilter.Append(")");
                }
            }
        }

        /// <summary>
        /// Checks or Unchecks the whole list of Items in a 
        /// given Checked Combo box.
        /// </summary>
        /// <param name="ccb">The CheckedComboBox to Check/Uncheck.</param>
        /// <param name="e">The Item Check Arguments.</param>
        private void CheckUncheckCombobox(CheckedComboBox ccb, ItemCheckEventArgs e)
        {
            if (this.runCCBEventHandler)
            {
                if (e.Index == 0)
                {
                    if (e.NewValue.ToString().Equals("Checked"))
                    {
                        for (int i = 1; i < ccb.Items.Count; i++)
                        {
                            //Hide the Event when checking them here. Infinite loop possibility.
                            this.runCCBEventHandler = false;
                            ccb.SetItemChecked(i, true);
                            this.runCCBEventHandler = true;
                        }
                    }
                    else if (e.NewValue.ToString().Equals("Unchecked"))
                    {
                        for (int i = 1; i < ccb.Items.Count; i++)
                        {
                            //Hide the Event when checking them here. Infinite loop possibility.
                            this.runCCBEventHandler = false;
                            ccb.SetItemChecked(i, false);
                            this.runCCBEventHandler = true;
                        }
                    }
                }
                else if (e.Index > 0 && e.NewValue.ToString().Equals("Unchecked"))
                {
                    //Hide the Event when checking them here. Infinite loop possibility.
                    this.runCCBEventHandler = false;
                    ccb.SetItemChecked(0, false);
                    this.runCCBEventHandler = true;
                }
            }
        }

        public void FilterResultsToGivenValues(List<Tuple<string, string>> filterValues)
        {
            FilterCheckedCombobox(ccbFunction, filterValues, "Function");

            FilterCheckedCombobox(ccbType, filterValues, "Type");

            FilterCheckedCombobox(ccbStatus, filterValues, "Status");

            FilterCheckedCombobox(ccbUnit, filterValues, "Unit");

            FilterCheckedCombobox(ccbFailureMode, filterValues, "Failure Mode");

            FilterCheckedCombobox(ccbRota, filterValues, "Rota");

            FilterCheckedCombobox(ccbArea, filterValues, "Area");

            FilterCheckedCombobox(ccbRootCause, filterValues, "Root Cause");
        }

        private void FilterCheckedCombobox(CheckedComboBox ccb,
            List<Tuple<string, string>> filterValues, string filterTitle)
        {
            //Checks if it needs to filter at all
            if (filterValues.Any(f => f.Item1.Equals(filterTitle)))
            {
                //Hide the event when doing this method
                this.runCCBEventHandler = false;
                for (int i = 0; i < ccb.Items.Count; i++)
                {
                    if (ccb.Items[i] is CCBoxItem)
                    {
                        CCBoxItem ccbItem = (CCBoxItem)ccb.Items[i];
                        if (filterValues.Any(f => f.Item2.Equals(ccbItem.Name)))
                        {
                            ccb.SetItemChecked(i, true);
                        }
                        else
                        {
                            ccb.SetItemChecked(i, false);
                        }
                    }
                }
                this.runCCBEventHandler = true;
            }
        }

        private void ccb_DropDownClosed(object sender, EventArgs e)
        {
            if (this.CheckedComboBoxClosedEvent != null)
            {
                this.CheckedComboBoxClosedEvent();
            }
        }

        #region Checked ComboBox ItemCheck Events
        private void ccbFunction_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbFunction, e);
        }

        private void ccbType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbType, e);
        }

        private void ccbRota_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbRota, e);
        }

        private void ccbUnit_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbUnit, e);
        }

        private void ccbFailureMode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbFailureMode, e);
        }

        private void ccbArea_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbArea, e);
        }

        private void ccbRootCause_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbRootCause, e);
        }

        private void ccbStatus_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckUncheckCombobox(ccbStatus, e);
        }
        #endregion Checked ComboBox ItemCheck Events

        private void MiscastFilter_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlComboHolder.Controls)
            {
                ctrl.Font = new Font("Tahoma", 8, FontStyle.Regular);
            }
        }
    }
}
