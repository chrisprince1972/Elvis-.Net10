using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using NLog;
using ElvisDataModel;

namespace Elvis.Forms.Tib
{
    public partial class DelayPopup : Form
    {
        #region Variables
        private int tibIndex;
        private int tibDelayIndex;
        private int minsRemaining;
        private int maxMins;
        private bool error = false;
        private DateTime onGoingEndTime;
        private TIBEvent tibEvent;
        private TIBDelay tibDelay;
        private TIBReasonsView reasonToSave;
        private DRFReport drfReport;
        private List<TIBDelay> tibDelays;
        private List<TIBReasonsView> tibReasons;
        private List<TibDisciplineLookUp> disciplines;
        private List<TibClassLookUp> classes;
        private List<TibCategoryLookUp> categories;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for Delay Popup.
        /// Used when you know the Event Index and other details.
        /// </summary>
        /// <param name="tibIndex">The Tib Event Index.</param>
        /// <param name="delayNo">The Delay Number.</param>
        /// <param name="minsRemaining">The minutes remaining on the event. Can leave this zero if editing.</param>
        /// <param name="onGoingEndTime">The ongoing end time if there is one. 
        /// Set to MyDateTime.Now, will be ignored if there is an end time.</param>
        public DelayPopup(int tibIndex, int tibDelayIndex,
            int minsRemaining, DateTime onGoingEndTime)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            this.tibIndex = tibIndex;
            this.tibDelayIndex = tibDelayIndex;
            this.minsRemaining = minsRemaining;

            GetData();

            if (!this.tibEvent.EventEnd.HasValue)
                this.onGoingEndTime = onGoingEndTime;

            BindListView(lstLevel1, 
                    Enumerable.DistinctBy(tibReasons,t => t.DelayReason1)
                    .OrderByDescending(o => o.DelayIndex)
                    .ToList()
                );

            SetupForm();
            CustomiseColours();
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the main data for the form.
        /// </summary>
        private void GetData()
        {
            try
            {
                this.tibEvent = EntityHelper.TIBEvents.GetSingle(this.tibIndex);
                this.tibDelays = EntityHelper.TIBDelays.GetByTibEventIndex(this.tibIndex);
                this.tibReasons = EntityHelper.TIBReasonsView.GetByUnitGroup(this.tibEvent.UnitGroup);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DELAY DATA ERROR -- GetData() -- Tib Data -- Tib Index: " + this.tibIndex +
                    " -- An error occurred when loading the delay popup data -- ", ex);
            }

            try
            {
                this.disciplines = EntityHelper.TibDisciplineLookUp.GetAll();
                this.classes = EntityHelper.TibClassLookUp.GetAll();
                this.categories = EntityHelper.TibCategoryLookUp.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DELAY DATA ERROR -- GetData() -- Tib Look Ups -- Tib Index: " + this.tibIndex +
                    " -- An error occurred when loading the delay popup data -- ", ex);
            }

        }

        /// <summary>
        /// Sets up the form in either edit or add state.
        /// </summary>
        private void SetupForm()
        {
            if (this.tibDelayIndex > 0)
            {//Edit Delay
                this.Text = "Edit Delay";

                GetTibDelay();

                if (this.tibDelay != null)
                {
                    this.drfReport = EntityHelper.DRFReport.GetSingleWithDelayIndex(this.tibDelay.TibDelayIndex);
                    if (this.drfReport != null)
                    {
                        btnDRF.Text = "Edit DRF...";
                    }
                }
                PopulateForm();
                numMins.Enabled = EnableNoPicker();
                if (!numMins.Enabled)
                {
                    InvalidNumberPicker(false);
                }
            }
            else
            {//Add Delay
                numMins.Value = numMins.Maximum =
                    this.maxMins = this.minsRemaining;
                btnDeleteDelay.Visible = false;
                btnDRF.Visible = false;
            }
        }

        /// <summary>
        /// Gets the tib delay for editing.
        /// </summary>
        private void GetTibDelay()
        {
            try
            {
                this.tibDelay = EntityHelper.TIBDelays.GetSingle(this.tibDelayIndex);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DELAY DATA ERROR -- GetTibDelay() -- Tib Delay Index: " + this.tibDelayIndex +
                    "An error occurred when loading the dely popup data -- ", ex);
            }
        }

        /// <summary>
        /// Enables/Disables number picker if there are delays beyond this one in the list
        /// of delays for that event.
        /// </summary>
        /// <returns>True to disable, false to enable.</returns>
        private bool EnableNoPicker()
        {
            if (this.tibDelays != null &&
                this.tibDelays.Count > 0 &&
                this.tibDelay != null && 
                this.tibDelay.DelayNumber == this.tibDelays.Count)
            {
                return true;
            }
            return false;
        }

        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
                grpReasons.ForeColor =
                grpLevel1.ForeColor =
                grpLevel2.ForeColor =
                grpLevel3.ForeColor =
                grpLevel4.ForeColor =
                grpInfo.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Method to bind a CheckedListBox
        /// </summary>
        /// <param name="lstLevel">The CheckedListBox to bind.</param>
        /// <param name="reasons">The items to bind it with.</param>
        private void BindListView(CheckedListBox lstLevel, List<TIBReasonsView> reasons)
        {
            ClearCheckedListBox(lstLevel);
            ((ListBox)lstLevel).DataSource = reasons;
            ((ListBox)lstLevel).DisplayMember = lstLevel.Tag.ToString();
            ((ListBox)lstLevel).ValueMember = lstLevel.Tag.ToString();
        }

        /// <summary>
        /// Fills the form with the data of the delay to edit.
        /// </summary>
        private void PopulateForm()
        {
            if (this.tibDelay != null)
            {
                //If there's a value place into correct list box
                if (!string.IsNullOrWhiteSpace(this.tibDelay.DelayReason1))
                {
                    lstLevel1.SelectedValue = this.tibDelay.DelayReason1;
                    if (lstLevel1.SelectedIndex >= 0)
                        lstLevel1.SetItemChecked(lstLevel1.SelectedIndex, true);
                }

                if (!string.IsNullOrWhiteSpace(this.tibDelay.DelayReason2))
                {
                    lstLevel2.SelectedValue = this.tibDelay.DelayReason2;
                    if (lstLevel2.SelectedIndex >= 0)
                        lstLevel2.SetItemChecked(lstLevel2.SelectedIndex, true);
                }

                if (!string.IsNullOrWhiteSpace(this.tibDelay.DelayReason3))
                {
                    lstLevel3.SelectedValue = this.tibDelay.DelayReason3;
                    if (lstLevel3.SelectedIndex >= 0)
                        lstLevel3.SetItemChecked(lstLevel3.SelectedIndex, true);
                }

                if (!string.IsNullOrWhiteSpace(this.tibDelay.DelayReason4))
                {
                    lstLevel4.SelectedValue = this.tibDelay.DelayReason4;
                    if (lstLevel4.SelectedIndex >= 0)
                        lstLevel4.SetItemChecked(lstLevel4.SelectedIndex, true);
                }

                //Fill remaining controls with values
                if (this.tibDelay.DelayDuration.HasValue)
                {
                    this.maxMins = this.minsRemaining + this.tibDelay.DelayDuration.Value;
                    if (this.minsRemaining < 0)
                    {//Mins are dodgy
                        numMins.Maximum = Convert.ToDecimal(this.tibDelay.DelayDuration.Value);
                        InvalidNumberPicker(true);
                        lblMax.Text = "Max - " + this.maxMins;
                    }
                    else
                    {
                        numMins.Maximum = this.maxMins;
                        InvalidNumberPicker(false);
                    }
                    numMins.Value = Convert.ToDecimal(this.tibDelay.DelayDuration.Value);
                }

                txtDiscipline.Text = GetDisciplineText(this.tibDelay.Discipline);
                txtDiscipline.Tag = this.tibDelay.Discipline;

                txtClass.Text = GetClassText(this.tibDelay.DelayClass);
                txtClass.Tag = this.tibDelay.DelayClass;

                txtCategory.Text = GetCategoryText(this.tibDelay.Category);
                txtCategory.Tag = this.tibDelay.Category;

                txtComments.Text = this.tibDelay.Comment;
            }
        }

        /// <summary>
        /// Gets the discipline text using the index from the discipline list.
        /// </summary>
        /// <param name="tibDisIndex">The Tib Discipline Index.</param>
        /// <returns>A string containing the Tib Discipline Text, if found.</returns>
        private string GetDisciplineText(int? tibDisIndex)
        {
            if (tibDisIndex.HasValue && this.disciplines != null &&
                this.disciplines.Count > 0)
            {
                TibDisciplineLookUp discipline = this.disciplines
                    .FirstOrDefault(d => d.TIBDisIndex == tibDisIndex);

                if (discipline != null)
                {
                    return discipline.TIBDisText;
                }
            }
            return "";
        }

        /// <summary>
        /// Gets the class text using the index from the class list.
        /// </summary>
        /// <param name="tibDisIndex">The Tib Class Index.</param>
        /// <returns>A string containing the Tib Class Text, if found.</returns>
        private string GetClassText(int? tibClassIndex)
        {
            if (tibClassIndex.HasValue && 
                this.classes != null &&
                this.classes.Count > 0)
            {
                TibClassLookUp tibClass = this.classes
                    .FirstOrDefault(d => d.TIBClassIndex == tibClassIndex);

                if (tibClass != null)
                {
                    return tibClass.TIBClassText;
                }
            }
            return "";
        }

        /// <summary>
        /// Gets the category text using the index from the category list.
        /// </summary>
        /// <param name="tibDisIndex">The Tib Category Index.</param>
        /// <returns>A string containing the Tib Category Text, if found.</returns>
        private string GetCategoryText(int? tibCategoryIndex)
        {
            if (tibCategoryIndex.HasValue &&
                this.categories != null &&
                this.categories.Count > 0)
            {
                TibCategoryLookUp category = this.categories
                    .FirstOrDefault(d => d.TIBCategoryIndex == tibCategoryIndex);

                if (category != null)
                {
                    return category.TIBCategoryText;
                }
            }
            return "";
        }

        /// <summary>
        /// Shows the user that the value in the number picker is
        /// invalid when compared to the remaining minutes for that event.
        /// </summary>
        /// <param name="invalid"></param>
        private void InvalidNumberPicker(bool invalid)
        {
            if (invalid)
            {
                numMins.BackColor = Color.Red;
                numMins.ForeColor = Color.White;
                lblMax.Visible = true;
            }
            else
            {
                numMins.BackColor = Color.White;
                numMins.ForeColor = Color.Black;
                lblMax.Visible = false;
            }
        }

        /// <summary>
        /// Checks to see if Save should be enabled.
        /// </summary>
        /// <returns>True or False</returns>
        private bool EnableSaveCheck()
        {
            if (this.reasonToSave != null &&
                numMins.Value > 0 &&
                numMins.Value <= this.maxMins)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Builds and Adds new delay to database
        /// </summary>
        private void AddNewDelay()
        {
            int delayNumber = GetDelayNumber();
            DateTime dtStart = GetTibStart(delayNumber);
            int? discipline = GetDisciplineInt(txtDiscipline.Tag);
            int delayClass = GetDisciplineInt(txtClass.Tag);
            int category = GetDisciplineInt(txtCategory.Tag);
            
            TIBDelay newTibDelay = new TIBDelay()
            {
                TibIndex = this.tibIndex,
                DelayNumber = delayNumber,
                DelayStart = dtStart,
                DelayEnd = dtStart.AddMinutes(Convert.ToDouble(numMins.Value)),
                DelayDuration = int.Parse(numMins.Value.ToString()),
                PlantArea = reasonToSave.PlantArea,
                DelayReason1 = reasonToSave.DelayReason1,
                DelayReason2 = reasonToSave.DelayReason2,
                DelayReason3 = reasonToSave.DelayReason3,
                DelayReason4 = reasonToSave.DelayReason4,
                UnitGroup = reasonToSave.UnitGroup,
                DelayClass = delayClass,
                Category = category,
                Discipline = discipline,
                Comment = txtComments.Text,
                UserName = WindowsIdentity.GetCurrent().Name,
                MachineName = Environment.MachineName,
                OEECategory = reasonToSave.OEECategory,
                LossType = reasonToSave.LossType,
                Owner = reasonToSave.Owner,
                ReportingTextLevel1 = reasonToSave.ReportingTextLevel1,
                ReportingTextLevel2 = reasonToSave.ReportingTextLevel2,
                ObjectDescription = reasonToSave.ObjectDescription,
                ObjectCode = reasonToSave.ObjectCode,
                DamageDescription = reasonToSave.DamageDescription,
                DamageCode = reasonToSave.DamageCode,
                DeviationType = reasonToSave.DeviationType,
                CauseText = reasonToSave.CauseText,
                Section = reasonToSave.Section,
                ExternalInternal = reasonToSave.ExternalInternal,
                SupplierDownStream = reasonToSave.SupplierDownStream,
                NoExtraWork = reasonToSave.NoExtraWork,
                FlocDescriptionL3 = reasonToSave.FlocDescriptionL3,
                FlocNumberL3 = reasonToSave.FlocNumberL3,
                FlocDescriptionL4 = reasonToSave.FlocDescriptionL4,
                FlocNumberL4 = reasonToSave.FlocNumberL4,
                FlocDescriptionL5 = reasonToSave.FlocDescriptionL5,
                FlocNumberL5 = reasonToSave.FlocNumberL5
            };

            try
            {
                EntityHelper.TIBDelays.AddNew(newTibDelay);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- AddNewDelay() -- " +
                    "Adding TIB Delay to database -- ", ex);
                logger.Error("DATA ERROR **Continued from Previous Error** -- AddNewDelay() -- Inner Exception: " +
                    ex.InnerException);

                error = true;
                MessageBox.Show("Could not add Tib Delay to database.",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Checks to see if theres any delays and generates a
        /// delay number for saving off new delays.
        /// </summary>
        /// <returns>A New Delay Number</returns>
        private int GetDelayNumber()
        {
            if (this.tibDelays.Count > 0)
                return this.tibDelays[this.tibDelays.Count - 1].DelayNumber + 1;
            return 1;
        }

        /// <summary>
        /// Updates existing delay to the database.
        /// </summary>
        private void SaveExistingDelay()
        {
            int discipline = GetDisciplineInt(txtDiscipline.Tag);
            int delayClass = GetDisciplineInt(txtClass.Tag);
            int category = GetDisciplineInt(txtCategory.Tag);

            this.tibDelay.PlantArea = reasonToSave.PlantArea;
            this.tibDelay.DelayReason1 = reasonToSave.DelayReason1;
            this.tibDelay.DelayReason2 = reasonToSave.DelayReason2;
            this.tibDelay.DelayReason3 = reasonToSave.DelayReason3;
            this.tibDelay.DelayReason4 = reasonToSave.DelayReason4;
            this.tibDelay.Discipline = discipline;
            this.tibDelay.DelayClass = delayClass;
            this.tibDelay.Category = category;
            this.tibDelay.Comment = txtComments.Text;
            this.tibDelay.UserName = WindowsIdentity.GetCurrent().Name;
            this.tibDelay.MachineName = Environment.MachineName;
            this.tibDelay.OEECategory = reasonToSave.OEECategory;
            this.tibDelay.LossType = reasonToSave.LossType;
            this.tibDelay.Owner = reasonToSave.Owner;
            this.tibDelay.ReportingTextLevel1 = reasonToSave.ReportingTextLevel1;
            this.tibDelay.ReportingTextLevel2 = reasonToSave.ReportingTextLevel2;
            this.tibDelay.ObjectDescription = reasonToSave.ObjectDescription;
            this.tibDelay.ObjectCode = reasonToSave.ObjectCode;
            this.tibDelay.DamageDescription = reasonToSave.DamageDescription;
            this.tibDelay.DamageCode = reasonToSave.DamageCode;
            this.tibDelay.DeviationType = reasonToSave.DeviationType;
            this.tibDelay.CauseText = reasonToSave.CauseText;
            this.tibDelay.Section = reasonToSave.Section;
            this.tibDelay.ExternalInternal = reasonToSave.ExternalInternal;
            this.tibDelay.SupplierDownStream = reasonToSave.SupplierDownStream;
            this.tibDelay.NoExtraWork = reasonToSave.NoExtraWork;
            this.tibDelay.FlocDescriptionL3 = reasonToSave.FlocDescriptionL3;
            this.tibDelay.FlocNumberL3 = reasonToSave.FlocNumberL3;
            this.tibDelay.FlocDescriptionL4 = reasonToSave.FlocDescriptionL4;
            this.tibDelay.FlocNumberL4 = reasonToSave.FlocNumberL4;
            this.tibDelay.FlocDescriptionL5 = reasonToSave.FlocDescriptionL5;
            this.tibDelay.FlocNumberL5 = reasonToSave.FlocNumberL5;

            if (numMins.Value != Convert.ToDecimal(this.tibDelay.DelayDuration))
            {
                this.tibDelay.DelayDuration = int.Parse(numMins.Value.ToString());
                this.tibDelay.DelayEnd = this.tibDelay.DelayStart.Value.AddMinutes(
                        Convert.ToDouble(numMins.Value));
            }

            try
            {
                EntityHelper.TIBDelays.EditExisting(this.tibDelay);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- EditTibDelay() -- " +
                    "Editing TIB Delay -- ", ex);
                error = true;
                MessageBox.Show("Could not save Tib Delay changes.",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Gets an Int from an object safely for the discipline.
        /// </summary>
        /// <param name="value">The value you wish to convert to int.</param>
        /// <returns>An int representing the object, or a 3 if null (Not Set in database)</returns>
        private int GetDisciplineInt(object value)
        {
            if (value != null)
            {
                int intVal = 0;
                if (int.TryParse(value.ToString(), out intVal))
                {
                    return intVal;
                }
            }
            return 3;
        }

        /// <summary>
        /// Gets the Calculated TIB start date
        /// </summary>
        /// <returns>DateTime representing the start date.</returns>
        private DateTime GetTibStart(int delayNumber)
        {
            if (tibEvent.EventStart.HasValue)
            {
                if (delayNumber == 1)
                    return tibEvent.EventStart.Value;

                int? duration = 0;
                if (this.tibEvent.TibDuration.HasValue)
                    duration = this.tibEvent.TibDuration.Value;

                if (duration == 0 && !this.tibEvent.EventEnd.HasValue)//Event has not ended
                {
                    duration = HelperFunctions.GetDuration(this.tibEvent.EventStart.Value, this.onGoingEndTime);
                }

                return tibEvent.EventStart.Value.AddMinutes(
                    Convert.ToDouble(duration - this.minsRemaining)
                    );
            }
            return new DateTime();
        }

        /// <summary>
        /// Finds the delay reason from the list and sets it 
        /// to a variable ready to save off later.
        /// </summary>
        private void SetDelayReason(int level)
        {
            this.reasonToSave = null;
            switch (level)
            {//Determine which level of issue
                case 1:
                    this.reasonToSave = tibReasons.FirstOrDefault(t =>
                        t.DelayReason1 == lstLevel1.SelectedValue.ToString() &&
                        string.IsNullOrWhiteSpace(t.DelayReason2) &&
                        string.IsNullOrWhiteSpace(t.DelayReason3) && 
                        string.IsNullOrWhiteSpace(t.DelayReason4));
                    break;
                case 2:
                    this.reasonToSave = tibReasons.FirstOrDefault(t =>
                        t.DelayReason1 == lstLevel1.SelectedValue.ToString() &&
                        t.DelayReason2 == lstLevel2.SelectedValue.ToString() &&
                        string.IsNullOrWhiteSpace(t.DelayReason3) &&
                        string.IsNullOrWhiteSpace(t.DelayReason4));
                    break;
                case 3:
                    this.reasonToSave = tibReasons.FirstOrDefault(t =>
                        t.DelayReason1 == lstLevel1.SelectedValue.ToString() &&
                        t.DelayReason2 == lstLevel2.SelectedValue.ToString() &&
                        t.DelayReason3 == lstLevel3.SelectedValue.ToString() &&
                        string.IsNullOrWhiteSpace(t.DelayReason4));
                    break;
                case 4:
                    this.reasonToSave = tibReasons.FirstOrDefault(t =>
                        t.DelayReason1 == lstLevel1.SelectedValue.ToString() &&
                        t.DelayReason2 == lstLevel2.SelectedValue.ToString() &&
                        t.DelayReason3 == lstLevel3.SelectedValue.ToString() &&
                        t.DelayReason4 == lstLevel4.SelectedValue.ToString());
                    break;
            }
            if (this.reasonToSave != null)
            {
                if (this.reasonToSave.Discipline.HasValue)
                {
                    txtDiscipline.Text = GetDisciplineText(this.reasonToSave.Discipline);
                    txtDiscipline.Tag = this.reasonToSave.Discipline;
                }

                if (this.reasonToSave.DelayClass.HasValue)
                {
                    txtClass.Text = GetClassText(this.reasonToSave.DelayClass);
                    txtClass.Tag = this.reasonToSave.DelayClass;
                }

                if (this.reasonToSave.Category.HasValue)
                {
                    txtCategory.Text = GetCategoryText(this.reasonToSave.Category);
                    txtCategory.Tag = this.reasonToSave.Category;
                }
            }
        }

        /// <summary>
        /// Clears a CheckedListBox of all items and sets
        /// datasource to null;
        /// </summary>
        /// <param name="lstLevel"></param>
        private void ClearCheckedListBox(CheckedListBox lstLevel)
        {
            ((ListBox)lstLevel).DataSource = null;
            lstLevel.Items.Clear();
        }

        /// <summary>
        /// Deselects all of the checkboxes in the list to
        /// stop users selecting multiple rows.
        /// </summary>
        /// <param name="lst">The Checked List Box concerned.</param>
        /// <param name="index">The index of the selected row.</param>
        private void DeselectAllButOne(CheckedListBox lst, int index)
        {
            for (int i = 0; i < lst.Items.Count; ++i)
            {
                if (i != index)
                    lst.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Confirms user wishes to delete delay, then removes from database.
        /// Corrects any Tib Delay Numbers that may be affected.
        /// </summary>
        private void DeleteDelay()
        {
            DialogResult result = MessageBox.Show(
                "This change cannot be undone. Are you sure you wish to delete this delay?",
                "Delete Delay - Please Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;

                try
                {
                    EntityHelper.DRFReport.RemoveTibDelayLinks(this.tibDelayIndex);
                    EntityHelper.TIBDelays.DeleteRecord(this.tibDelay,
                        this.tibEvent.EventStart.Value);
                    this.Cursor = Cursors.Default;
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    logger.ErrorException("DELETE DELAY ERROR -- DeleteDelay() -- " +
                        "TibDelayIndex: " + this.tibDelayIndex + " -- " +
                        "An error occurred when trying to delete a delay on the delay entry screen -- ",
                        ex);
                    MessageBox.Show("Unable to delete delay.",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    error = true;
                }
            }
            else
            {
                error = true;
            }
        }

        /// <summary>
        /// Adds or Edits a DRF Report.
        /// </summary>
        /// <param name="isAdd">True for adding, false for editing.</param>
        private void AddEditDRFReport(bool isAdd)
        {
            if (isAdd)//Add New
            {
                if (this.tibDelay != null)
                {
                    if (CommonMethods.AddEditDRF(0, this.tibDelay.TibDelayIndex))
                    {
                        btnDRF.Text = "Edit DRF...";
                    }
                }
            }
            else//Edit Existing
            {
                if (this.drfReport == null && this.tibDelay != null)
                {
                    this.drfReport = EntityHelper.DRFReport.GetSingleWithDelayIndex(this.tibDelay.TibDelayIndex);
                }
                if (this.drfReport != null && this.drfReport.TIBDelayIndex.HasValue)
                {
                    CommonMethods.AddEditDRF(
                        this.drfReport.DRFIndex,
                        this.drfReport.TIBDelayIndex.Value);
                }
                else
                {
                    MessageBox.Show("Could not find DRF Report.",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        #region Events
        /// <summary>
        /// Item Check event for Checked List Box control.
        /// </summary>
        private void lstLevel_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox lstLevel = (CheckedListBox)sender;
            DeselectAllButOne(lstLevel, e.Index);

            switch (lstLevel.Tag.ToString())
            {//Determine which level of issue
                case "DelayReason1":
                    BindListView(lstLevel2,
                        Enumerable.DistinctBy(
                                tibReasons
                                    .OrderByDescending(o => o.DelayIndex)
                                    .Where(t =>
                                        t.DelayReason1 == lstLevel.SelectedValue.ToString() &&
                                        !string.IsNullOrWhiteSpace(t.DelayReason2)),
                                t => t.DelayReason2)
                            .ToList());
                    ClearCheckedListBox(lstLevel3);
                    ClearCheckedListBox(lstLevel4);

                    if (lstLevel2.Items.Count == 0)
                        SetDelayReason(1);
                    if (lstLevel.CheckedItems.Count > 0)
                        ClearCheckedListBox(lstLevel2);
                    break;
                case "DelayReason2":
                    BindListView(lstLevel3,
                        Enumerable.DistinctBy(
                                tibReasons
                                    .OrderByDescending(o => o.DelayIndex)
                                    .Where(t =>
                                        t.DelayReason1 == lstLevel1.SelectedValue.ToString() &&
                                        t.DelayReason2 == lstLevel.SelectedValue.ToString() &&
                                        !string.IsNullOrWhiteSpace(t.DelayReason3)),
                                t => t.DelayReason3)
                            .ToList());

                    ClearCheckedListBox(lstLevel4);

                    if (lstLevel3.Items.Count == 0)
                        SetDelayReason(2);
                    if (lstLevel.CheckedItems.Count > 0)
                        ClearCheckedListBox(lstLevel3);
                    break;
                case "DelayReason3":
                    BindListView(lstLevel4,
                        Enumerable.DistinctBy(
                                tibReasons
                                    .OrderByDescending(o => o.DelayIndex)
                                    .Where(t =>
                                        t.DelayReason1 == lstLevel1.SelectedValue.ToString() &&
                                        t.DelayReason2 == lstLevel2.SelectedValue.ToString() &&
                                        t.DelayReason3 == lstLevel.SelectedValue.ToString() &&
                                        !string.IsNullOrWhiteSpace(t.DelayReason4)),
                                t => t.DelayReason4)
                            .ToList());


                    if (lstLevel4.Items.Count == 0)
                        SetDelayReason(3);
                    if (lstLevel.CheckedItems.Count > 0)
                        ClearCheckedListBox(lstLevel4);
                    break;
                case "DelayReason4":
                    if (e.NewValue == CheckState.Checked)
                        SetDelayReason(4);
                    break;
            }
            if (e.NewValue == CheckState.Unchecked)
            {
                this.reasonToSave = null;
                txtDiscipline.Text = "";
                txtDiscipline.Tag = "";
                txtClass.Text = "";
                txtClass.Tag = "";
                txtCategory.Text = "";
                txtCategory.Tag = "";
            }
            btnSave.Enabled = btnDRF.Enabled = EnableSaveCheck();
        }

        /// <summary>
        /// Enables/Disables Save button depending on form state.
        /// </summary>
        private void Ctrl_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = btnDRF.Enabled = EnableSaveCheck();
            if (sender is NumericUpDown)
            {
                if (numMins.Value <= this.maxMins)
                {//Valid
                    InvalidNumberPicker(false);
                }
                else
                {//Invalid
                    InvalidNumberPicker(true);
                }
            }
        }

        /// <summary>
        /// Button Save event, checks if edit or add.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.tibDelayIndex > 0)
                SaveExistingDelay();
            else
                AddNewDelay();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Cancel the form closing if there are any errors.
        /// </summary>
        private void DelayPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = error;
            error = false;//reset error bool
        }

        /// <summary>
        /// Checks for valid saving when typing into the box
        /// </summary>
        private void numMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSave.Enabled = btnDRF.Enabled = EnableSaveCheck();
        }

        /// <summary>
        /// Sets the active control of the form.
        /// </summary>
        private void DelayPopup_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnSave;
        }

        /// <summary>
        /// Deletes the current display and then closes the window.
        /// </summary>
        private void btnDeleteDelay_Click(object sender, EventArgs e)
        {
            DeleteDelay();
        }

        /// <summary>
        /// Edits or Creates a New DRF.
        /// </summary>
        private void btnDRF_Click(object sender, EventArgs e)
        {
            if (btnDRF.Text.Contains("New"))
                AddEditDRFReport(true);
            else
                AddEditDRFReport(false);
        }
        #endregion

        #endregion
    }
}
