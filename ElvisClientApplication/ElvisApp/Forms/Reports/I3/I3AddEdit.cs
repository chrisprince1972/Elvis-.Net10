using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Forms.Tib;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.Forms.Reports.I3
{
    public partial class I3AddEdit : Form
    {
        private int i3Id = 0;
        private bool isEdit = false;
        private bool isDirty = false;
        private bool hasErrors = false;
        private DateTime reportCreated;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public I3AddEdit(int i3Id)
        {
            InitializeComponent();

            BindDropDowns();

            this.i3Id = i3Id;
            if (i3Id > 0)
            {
                this.isEdit = true;
                PopulateForm(GetI3FromDB());
            }

            CustomiseColours();
            AddSetDirtyEventHandler();

        }

        private I3s GetI3FromDB()
        {
            I3s returnValue = null;
            try
            {
                returnValue = EntityHelper.I3Report.GetSingle(this.i3Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to get report. This has been logged.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                logger.ErrorException("I3 faild to get report " + this.i3Id + ".", ex);
            }

            return returnValue;
        }


        /// <summary>
        /// Sets isDirty to true as soon as a control has changed inside the pnlDataEntry.
        /// </summary>
        private void SetDirty(object sender, EventArgs e) { this.isDirty = true; }
        private void AddSetDirtyEventHandler()
        {
            foreach (Control ctrl in pnlDataEntry.Controls)
            {
                if (ctrl is TextBox || ctrl is DateTimePicker)
                {
                    ctrl.TextChanged += new EventHandler(SetDirty);
                }
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).CheckedChanged += new EventHandler(SetDirty);
                }
                if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedValueChanged += new EventHandler(SetDirty);
                }
            }
        }

        #region Methods
        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlMain.BackColor =
                grpMain.BackColor =
                pnlDataEntry.BackColor =
                pnlButtons.BackColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlMain.ForeColor =
                grpMain.ForeColor =
                pnlDataEntry.ForeColor =
                pnlButtons.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Bind all of the drop downs on the form. Used for initial load.
        /// </summary>
        private void BindDropDowns()
        {
            List<string> ddl =
                
                Enumerable.DistinctBy(EntityHelper
                .DRFDropDownLookUp
                .GetAll(),l => l.Rota)
                .Where(l => l.Rota != null && l.Rota != "Please Select")
                .Select(s => s.Rota)
                .ToList();
            ddl.Add("Days");
            ddl.Remove("E");
            cmboRota.DataSource = ddl;
            cmboRota.DisplayMember = "Rota";
        }

        /// <summary>
        /// Fills the form with data if in edit mode.
        /// </summary>
        private void PopulateForm(I3s report)
        {
            if (report != null)
            {
                this.reportCreated = report.Created;
                cmboRota.SelectedItem = report.Shift.ToString();
                txtTitle.Text = report.Title;
                txtShiftManager.Text = report.ShiftManager;
                chkI3Within24hrs.Checked = report.CompleteIn24Hrs;
                chkHigherLevelInvestigationRequired.Checked = report.HigherLevelInvestigationRequired;
                txtTrio.Text = report.Trio;

                if (report.FeedBackBy.HasValue)
                {
                    DateTime dt = report.FeedBackBy.Value;
                    dtmDate.Value = dt;
                }

                chkComplete.Checked = report.Complete;
            }
        }

        /// <summary>
        /// Save existing or add a new Report.
        /// </summary>
        private bool SaveReport()
        {
            if (FormValidated())
            {
                this.hasErrors = false;
                I3s I3Report = BuildReport();
                try
                {
                    if (this.isEdit)//Save existing newReport
                    {
                        I3Report.Id = this.i3Id;
                        EntityHelper.I3Report.Update(I3Report);
                    }
                    else//Add new Report
                    {
                        I3Report.Created = MyDateTime.Now;
                        EntityHelper.I3Report.AddNew(I3Report);
                    }
                }
                catch (Exception ex)
                {
                    string i3Id = "Report";
                    if (this.isEdit)
                        i3Id = I3Report.Id.ToString();

                    MessageBox.Show(
                        "I3 report failed to save. This has been logged.",
                        "Save Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    logger.ErrorException("I3 report failed to save I3 Index: " + i3Id + ". ", ex);
                }

                this.isDirty = false;
                return true;
            }
            else
            {
                MessageBox.Show("Report failed to save due to validation errors. Please check your input is valid.",
                    "Validation Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            return false;
        }

        /// <summary>
        /// Validate user input and flag any bad inputs.
        /// </summary>
        private bool FormValidated()
        {
            bool valid = true;

            List<Control> controlList = HelperFunctions.GetControlList(this, typeof(ComboBox));
            controlList.AddRange(HelperFunctions.GetControlList(this, typeof(TextBox)));

            foreach (Control ctrl in controlList)
            {
                if (ctrl.Tag != null &&
                    ctrl.Tag.ToString().Contains("Required"))
                {
                    CommonMethods.HighlightControl(ctrl, false);
                    if (ctrl.Text == "Please Select" ||
                        string.IsNullOrWhiteSpace(ctrl.Text))
                    {
                        CommonMethods.HighlightControl(ctrl, true);
                        valid = false;
                    }
                }
            }
            return valid;
        }

        /// <summary>
        /// Builds and returns a new I3 Report from the form.
        /// </summary>
        private I3s BuildReport()
        {
            return new I3s()
            {
                Created = this.reportCreated,
                Shift = cmboRota.SelectedItem.ToString(),
                Title = txtTitle.Text,
                ShiftManager = txtShiftManager.Text,
                CompleteIn24Hrs = chkI3Within24hrs.Checked,
                HigherLevelInvestigationRequired = chkHigherLevelInvestigationRequired.Checked,
                Trio = txtTrio.Text,
                FeedBackBy = dtmDate.Value.Date,
                Complete = chkComplete.Checked
            };
        }


        /// <summary>
        /// Closes window if esc key hit
        /// </summary>
        private void AddEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Closes window on click.
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Save and Close the newReport event.
        /// </summary>
        private void saveCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
        }

        /// <summary>
        /// Save the Report event.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SaveReport();
            this.Cursor = Cursors.Default;
        }


        /// <summary>
        /// Cancel the form closing event if errors present on form.
        /// </summary>
        private void AddEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.isDirty && !this.hasErrors)
            {
                DialogResult result = MessageBox.Show(
                    "All unsaved changes will be lost. Continue?",
                    "Please Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;
            }
            else
            {
                e.Cancel = this.hasErrors;
                this.hasErrors = false;
            }
        }

        /// <summary>
        /// Save button click event handler.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (SaveReport())
                this.DialogResult = DialogResult.OK;
            else
                this.hasErrors = true;

            this.Cursor = Cursors.Default;
        }

        #endregion

    }
}
