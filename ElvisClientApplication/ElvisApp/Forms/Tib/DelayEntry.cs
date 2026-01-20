using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using System.ComponentModel;

namespace Elvis.Forms.Tib
{
    public partial class DelayEntry : Form
    {
        #region Variables + Properties
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private TIBEvent tibEvent;
        private Unit unit;
        private int? durationToUse;
        private DateTime onGoingEndTime;
        private Bitmap memoryImage;
        private Boolean pagePrint;
        /// <summary>
        /// Used to determine if delays have changed and need refreshing on scheduler
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DirtyDelays { get; set; }
        #endregion

        public DelayEntry(int tibIndex)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            DirtyDelays = false;
            this.tibEvent = GetTibEvent(tibIndex);
            delayDetailGrid.OnSelectionChange += gdvDelays_SelectionChanged;
            delayDetailGrid.OnChange += gdvDelays_Changed;

            if (this.tibEvent != null)//Check if found record in DB
            {
                this.unit = GetUnit(this.tibEvent.UnitNumber);
                PopulateScreen();
                BindGridview();
                AddTotalsToList();
                tibDelayEntryEvent.ConfigureTreatmentDetails(unit, tibEvent);
                CustomiseColours();
            }
            else //Close if no record found
            {
                MessageBox.Show("Unable to find event.",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                this.Close();
            }
        }

        #region Methods
        /// <summary>
        /// Gets a TIB Event using the entity helper and logs
        /// any errors.
        /// </summary>
        /// <param name="tibIndex">The Tib Event Index you wish to get.</param>
        /// <returns>The TIB Event.</returns>
        private TIBEvent GetTibEvent(int tibIndex)
        {
            try
            {
                return EntityHelper.TIBEvents.GetSingle(tibIndex);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetTibEvent() -- " +
                    "Getting Tib Event data from database -- tibIndex: " + tibIndex +
                    " -- ", ex);
            }
            return null;
        }

        /// <summary>
        /// Gets a Unit using the entity helper and logs
        /// any errors.
        /// </summary>
        /// <param name="tibIndex">The Unit Number of the Unit you wish to get.</param>
        /// <returns>A Unit.</returns>
        private Unit GetUnit(int unitNo)
        {
            try
            {
                return EntityHelper.Units.GetSingle(unitNo);
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetUnit() -- " +
                    "Getting Unit data from database -- UnitNo: " + unitNo +
                    " -- ", ex);
            }
            return null;
        }

        /// <summary>
        /// Binds the data gridview to the tib delay data associated
        /// with the tib event.
        /// </summary>
        private void BindGridview()
        {
            try
            {
                SetupDelayDetailGrid();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- GetTibDelaysView() -- " +
                    "Getting TIB Delays View data from database -- TibIndex: " +
                    this.tibEvent.TibIndex + " -- ", ex);

                MessageBox.Show(
                    "An error occurred getting the delays for this event. Please try again later or contact your administrator if problem persists.",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                this.Close();
            }

            btnDown.Enabled = false;
            btnUp.Enabled = false;
        }

        /// <summary>
        /// Setup the event delays in the data grid view.
        /// </summary>
        private void SetupDelayDetailGrid()
        {
            if (this.tibEvent != null && this.tibEvent.TibIndex > 0)
            {
                List<int> tibIndexList = new List<int>();
                tibIndexList.Add(this.tibEvent.TibIndex);
                delayDetailGrid.SetupUserControl(tibIndexList);
                delayDetailGrid.ShowData();

                SetOverviewBox();
                AddTotalsToList();
                SetButtonsEnabled();
            }
        }

        /// <summary>
        /// Draw the overview box showing relative size of delays inside TIB event.
        /// </summary>
        private void SetOverviewBox()
        {
            if (this.durationToUse.HasValue)
            {
                delayDetailGrid.BuildBoxDisplay(pnlBoxDisplay, this.durationToUse.Value);
            }
        }

        /// <summary>
        /// Loads the form with all the necessary data.
        /// </summary>
        private void PopulateScreen()
        {
            toolStripStatusLabelArea.Text += this.unit.UnitText;

            if (this.tibEvent.HeatNumber.HasValue &&
                this.tibEvent.HeatNumber.Value.ToString().Length > 2 &&
                this.tibEvent.HeatNumber.Value.ToString().Length < 6)
            {//Check it's a valid HeatNumber
                txtHeatNo.Text = this.tibEvent.HeatNumber.Value.ToString();
                toolStripStatusLabelHeatNo.Text += this.tibEvent.HeatNumber.Value.ToString();
            }
            else
            {//Hide toolstrip label if no heat number
                toolStripStatusLabelHeatNo.Visible = false;
            }

            if (this.tibEvent.ProgramNumber.HasValue &&
                this.tibEvent.ProgramNumber.Value > 0)
            {//Check for valid program number
                txtProgramNo.Text = this.tibEvent.ProgramNumber.Value.ToString();
            }

            txtUnit.Text = this.unit.UnitShort;

            lblStartTime.Text = txtStartTime.Text =
                DateTimeExtensions.FormatAndGetDateTime(this.tibEvent.EventStart, 0);

            if (this.tibEvent.EventEnd.HasValue)
            {
                lblEndTime.Text = txtEndTime.Text =
                    DateTimeExtensions.FormatAndGetDateTime(tibEvent.EventEnd, 0);
                txtDuration.Text = tibEvent.TibDuration.ToString() + " mins";//Calculate duration
                this.durationToUse = tibEvent.TibDuration.Value;
            }
            else//No End Time so it's ongoing.
            {
                lblEndTime.Text = DateTimeExtensions.FormatAndGetDateTime(DateTime.Now, 0);
                txtEndTime.Text = "Ongoing";
                this.onGoingEndTime = DateTime.Now;
                this.durationToUse = HelperFunctions.GetDuration(
                    tibEvent.EventStart,
                    this.onGoingEndTime);
                txtDuration.Text = this.durationToUse + " mins";//Calculate duration
            }

            txtStatus.Text = EntityHelper.TIBStates.GetDescription(tibEvent.TibStatus);
        }

        /// <summary>
        /// Adds the time totals to the listview on the form.
        /// </summary>
        private void AddTotalsToList()
        {
            lstTotals.BackColor = Color.White;
            lstTotals.ForeColor = Color.Black;
            btnAddDelay.Enabled = true;
            addNewDelayToolStripMenuItemNewDelay.Enabled = true;
            lstTotals.Items.Clear();
            int wholeDuration = 0;
            int sumOfDelays = delayDetailGrid.GetTotalDelayAccountedForMins();

            if (this.durationToUse.HasValue &&
                this.durationToUse > 0)
            {
                wholeDuration = this.durationToUse.Value;
            }

            int minsRemain = wholeDuration - sumOfDelays;

            string[] items = new string[3] { 
                wholeDuration.ToString(), 
                sumOfDelays.ToString(), 
                minsRemain.ToString()
            };
            lstTotals.Items.Add(new ListViewItem(items));

            if (sumOfDelays >= wholeDuration)
            {
                addNewDelayToolStripMenuItemNewDelay.Enabled = false;
                btnAddDelay.Enabled = false;
            }

            if (minsRemain < 0)
            {//We have a problem
                lstTotals.BackColor = Color.Red;
                lstTotals.ForeColor = Color.White;
            }
        }

        //Customises Colours Depending on User Settings
        private void CustomiseColours()
        {
            this.BackColor =
                Settings.Default.ColourBackground;

            this.ForeColor =
            grpDelays.ForeColor =
            grpEvent.ForeColor =
            grpTotals.ForeColor =
            grpTreatmentDetail.ForeColor =
                Settings.Default.ColourText;
        }

        /// <summary>
        /// Checks to see which buttons to enable depending on selected row in gridview
        /// </summary>
        private void SetUpDownButtons()
        {
            btnDown.Enabled = false;
            btnUp.Enabled = false;

            int rowCount = delayDetailGrid.GetRowCount();
            int selectedIndex = delayDetailGrid.GetSelectedIndex();

            if (selectedIndex >= 0 && rowCount > 1 && selectedIndex < rowCount - 1)
            {
                btnDown.Enabled = true;
            }
            if (selectedIndex >= 1 && selectedIndex < rowCount)
            {
                btnUp.Enabled = true;
            }
        }

        /// <summary>
        /// Deletes the Selected Delay from the Database.
        /// </summary>
        private void DeleteSelectedDelay()
        {
            int rowCount = delayDetailGrid.GetRowCount();

            ElvisDataModel.EDMX.TIBDelaysView tibDelay  = delayDetailGrid.GetSelectedDelay();
            if (rowCount > 0 && tibDelay != null && 
                this.tibEvent != null && this.tibEvent.EventStart.HasValue)
            {
                DialogResult result = MessageBox.Show(
                    string.Format(
                        "Are you sure you wish to delete delay #{0}? This process cannot be undone.",
                        tibDelay.DelayNumber),
                    "Delete Delay - Please Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EntityHelper.DRFReport.RemoveTibDelayLinks(tibDelay.TibDelayIndex);
                        EntityHelper.TIBDelays.DeleteRecord(
                            EntityHelper.TIBDelays.GetSingle(tibDelay.TibDelayIndex),
                            this.tibEvent.EventStart.Value);
                        SetupDelayDetailGrid();

                        DirtyDelays = true;
                    }
                    catch (Exception ex)
                    {
                        logger.ErrorException("DELETE DELAY ERROR -- DeleteSelectedDelay() -- " +
                            "Delay Number: " + tibDelay.TibDelayIndex + " -- " +
                            "An error occurred when trying to delete a delay on the delay entry screen -- ",
                            ex);
                        MessageBox.Show("Unable to delete delay.",
                            "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                            );
                    }
                }
            }
        }

        /// <summary>
        /// Display buttons status.
        /// </summary>
        private void SetButtonsEnabled()
        {
            int delayDetailGridRowCount = delayDetailGrid.GetRowCount();
            int delayDetailGridSelectedIndex = delayDetailGrid.GetSelectedIndex();

            bool showDel =
                 delayDetailGridRowCount > 0 
                && delayDetailGridSelectedIndex > -1;

            btnDeleteDelay.Enabled = showDel;
            menuDeleteDelay.Enabled = showDel;
            if (delayDetailGrid.GetRowCount() > 0)
            {
                SetUpDownButtons();
            }
        }

        #region Events
        /// <summary>
        /// Any changes in selection sets up the up down and delete buttons.
        /// </summary>
        private void gdvDelays_SelectionChanged(object sender, EventArgs e)
        {
            if (delayDetailGrid.GetRowCount() > 0)
            {
                SetUpDownButtons();
            }
        }

        /// <summary>
        /// Any changes in selection sets up the up down and delete buttons.
        /// </summary>
        private void gdvDelays_Changed(object sender, EventArgs e)
        {
            SetButtonsEnabled();
            AddTotalsToList();
            SetOverviewBox();
            this.DirtyDelays = true;
        }

        /// <summary>
        /// Helper function for the two functions below.
        /// </summary>
        private void AddNewDelayWindow()
        {
            if (this.tibEvent != null && this.durationToUse.HasValue)
            {
                bool success
                    = delayDetailGrid
                    .ShowNewDelayPopup(this.tibEvent.TibIndex, this.durationToUse.Value, this.onGoingEndTime);
                if (success)
                {
                    SetupDelayDetailGrid();
                    this.DirtyDelays = true;
                }
            }
        }

        /// <summary>
        /// Click event for adding a new delay via the on screen button
        /// </summary>
        private void btnAddDelay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddNewDelayWindow();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Click event for adding a new delay via the on screen menu item
        /// </summary>
        private void addNewDelayToolStripMenuItemNewDelay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddNewDelayWindow();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Allows the user to press esc to close form
        /// </summary>
        private void DelayEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Close Event for Menu Close Button
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Move delay record up or down.
        /// </summary>
        /// <param name="moveUp">Direction in which the delay should move.</param>
        private void MoveDelay(bool moveUp)
        {
            delayDetailGrid.MoveDelay(moveUp);
            SetOverviewBox();
            this.DirtyDelays = true;
            SetButtonsEnabled();
        }

        /// <summary>
        /// Move delay up button click event
        /// </summary>
        private void btnUp_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MoveDelay(true);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Move delay down button click event
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            MoveDelay(false);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Form shown event. Clears the selection on the gridview
        /// </summary>
        private void DelayEntry_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            delayDetailGrid.ClearSelection();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Delete Delay Event Handler
        /// </summary>
        private void btnDeleteDelay_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DeleteSelectedDelay();
            this.DirtyDelays = true;
            this.Cursor = Cursors.Default;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.Document = printDocument1;
            // Display the dialog. This returns true if the user presses the Print button.
            DialogResult print = pDialog.ShowDialog();
            if (print == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.Print();
                pagePrint = false;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.DefaultPageSettings.Landscape = true;
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            ((ToolStripButton)((ToolStrip)dlg.Controls[1]).Items[0]).Visible = false;
            dlg.Document = printDocument1;
            ((Form)dlg).WindowState = FormWindowState.Maximized;
            dlg.ShowDialog();
            pagePrint = false;
        }

        /// <summary>
        /// Store form data for print form.
        /// </summary>
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // pagePrint added due to control fireing twice, one image
            // and then a smaller one on top which is reduced again.
            if (pagePrint == false)
            {
                e.Graphics.ScaleTransform(0.94F, 0.94F);
                e.Graphics.DrawImage(memoryImage, 0, 0);
                pagePrint = true;
            }
        }
        #endregion

        #endregion
    }
}
