using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using Data = ElvisDataModel.EDMX;
using System.ComponentModel;

namespace Elvis.Forms.Reports.Miscasts.UserControls
{
    public partial class RCAInvestigation : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private MiscastInvestigation investigation;
        private int investigationNo = 0;
        private bool readOnly = false;
        private bool dataLoaded;

        /// <summary>
        /// Fires when a Miscast Investigation is Deleted.
        /// </summary>
        public delegate void MiscastInvestigationDeletedEventHandler(int deletedInvestigationID);

        public event MiscastInvestigationDeletedEventHandler MiscastInvestigationDeletedEvent;

        /// <summary>
        /// Fires when a Miscast Investigation is Changed.
        /// </summary>
        public delegate void MiscastInvestigationChangedEventHandler();

        public event MiscastInvestigationChangedEventHandler MiscastInvestigationChangedEvent;

        /// <summary>
        /// Fires when a Miscast Why is Added
        /// </summary>
        public delegate void MiscastWhyAddedEventHandler();

        public event MiscastWhyAddedEventHandler MiscastWhyAddedEvent;

        public MiscastInvestigation MiscastInvestigation
        {
            get { return this.investigation; }
        }

        public int InvestigationID
        {
            get { return this.investigation.InvestigationID; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TabOrderNumber
        {
            get { return this.investigationNo; }
            set
            {
                this.investigationNo = value;
                grpInvestigation.Text = "Investigation No. " + this.investigationNo;
            }
        }

        public int InvestigationNumber
        {
            get { return this.investigation.InvestigationNumber; }
        }

        public RCAInvestigation(MiscastInvestigation investigation, 
            List<MiscastAreaResponsible> areas, bool readOnly, int investigationNo)
        {
            InitializeComponent();
            this.investigation = investigation;
            this.investigationNo = investigationNo;
            this.readOnly = readOnly;
            this.dataLoaded = false;
            PopulateDropDown(areas);
        }

        private void PopulateDropDown(List<MiscastAreaResponsible> areas)
        {
            if (areas != null)
            {
                cmboArea.DataSource = areas.Where(a => a.AreaResponsibleID > 0).ToList();
                cmboArea.DisplayMember = "AreaResponsible";
                cmboArea.ValueMember = "AreaResponsibleID";
            }
        }

        private void RCAInvestigation_Load(object sender, EventArgs e)
        {
            PopulateForm();
            SetupReadOnly();
            this.dataLoaded = true;
        }

        public void ForceLoad()
        {
            if (!this.dataLoaded)
            {
                RCAInvestigation_Load(null, null);
            }
        }

        private void SetupReadOnly()
        {
            cmboArea.Enabled = !this.readOnly;
            txtInvestigator.ReadOnly = this.readOnly;
            txtProblemStatement.ReadOnly = this.readOnly;
            txtRootCause.ReadOnly = this.readOnly;
            btnDeleteInvestigation.Visible = !this.readOnly;
            btnDeleteInvestigation.Enabled = !this.readOnly;
            btnAddWhy.Visible = !this.readOnly;
            btnAddWhy.Enabled = !this.readOnly;
            pnlAddWhy.Visible = !this.readOnly;

            if (this.investigation.InvestigationNumber == 0)
                btnDeleteInvestigation.Visible = false;
        }

        private void PopulateForm()
        {
            if (this.investigation != null)
            {
                grpInvestigation.Text = "Investigation No. " + this.investigationNo;
                cmboArea.SelectedValue = investigation.AreaResponsibleID;
                txtInvestigator.Text = investigation.Investigator;
                txtProblemStatement.Text = investigation.ProblemStatement;
                txtRootCause.Text = investigation.RootCause;

                FillMiscastWhys();
            }
        }

        private void FillMiscastWhys()
        {
            pnlWhys.Controls.Clear();

            if (investigation != null &&
                investigation.MiscastWhies != null &&
                investigation.MiscastWhies.Count > 0)
            {
                foreach (MiscastWhy why in investigation.MiscastWhies.OrderBy(m => m.SortNumber))
                {
                    AddWhyToPanel(why);
                }
            }
        }

        /// <summary>
        /// Returns empty string when form is ok.  Otherwise, the issue is returned.
        /// </summary>
        /// <returns>Empty string when form is ok.</returns>
        public string ValidateInvestigation()
        {
            string issue = string.Empty;
            if(txtInvestigator.Text == string.Empty)
            {
                txtInvestigator.BackColor = Color.Red;
                txtInvestigator.ForeColor = Color.White;
                issue = "Investigator must be populated on investigation.";
            }
            else
            {
                txtInvestigator.BackColor = SystemColors.Window;
                txtInvestigator.ForeColor = SystemColors.WindowText;
            }
            return issue;
        }

        public void UpdateValues()
        {
            this.investigation.AreaResponsibleID = HelperFunctions.GetIntSafely(cmboArea.SelectedValue);
            this.investigation.Investigator = txtInvestigator.Text;
            this.investigation.ProblemStatement = txtProblemStatement.Text;
            this.investigation.RootCause = txtRootCause.Text;

            foreach (Control ctrl in pnlWhys.Controls)
            {
                if (ctrl is RCAWhy)
                {
                    RCAWhy ucRCAWhy = (RCAWhy)ctrl;
                    ucRCAWhy.UpdateValues();
                }
            }
        }

        private void rcaWhy_MiscastWhyDeletedEvent(int deletedWhyID)
        {
            Control ctrlToRemove = new Control();
            foreach (Control ctrl in pnlWhys.Controls)
            {
                if (ctrl is RCAWhy)
                {
                    RCAWhy ucRCAWhy = (RCAWhy)ctrl;
                    if (ucRCAWhy != null && 
                        ucRCAWhy.WhyID == deletedWhyID)
                    {
                        ctrlToRemove = ctrl;
                    }
                }
            }
            pnlWhys.Controls.Remove(ctrlToRemove);
        }

        private void btnDeleteInvestigation_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DeleteInvestigation();
            this.Cursor = Cursors.Default;
        }

        private void DeleteInvestigation()
        {
            if (this.investigation != null &&
                FormControl.ConfirmDeleteRecord("Miscast Investigation"))
            {
                try
                {
                    EntityHelper.MiscastInvestigation.DeleteByID(this.investigation.InvestigationID);
                    if (this.MiscastInvestigationDeletedEvent != null)
                    {
                        this.MiscastInvestigationDeletedEvent(this.investigation.InvestigationID);
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- DeleteInvestigation() -- Error Deleting Miscast Investigation -- ", 
                        ex);
                    MessageBox.Show(
                        "Error Deleting Investigation!", 
                        "Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        private void btnAddWhy_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddWhy();
            this.Cursor = Cursors.Default;
        }

        private void AddWhy()
        {
            if (this.investigation != null)
            {
                try
                {
                    MiscastWhy why = new MiscastWhy()
                    {
                        InvestigationID = this.investigation.InvestigationID,
                        WhyText = ""
                    };
                    EntityHelper.MiscastWhy.AddNew(why);

                    if (this.MiscastWhyAddedEvent != null)
                    {
                        this.MiscastWhyAddedEvent();
                    }

                    //AddWhyToPanel(why);
                    //this.investigation.MiscastWhies.Add(why);
                }
                catch (Exception ex)
                {
                    logger.ErrorException(
                        "DATA ERROR -- AddWhy() -- Error Adding Miscast Why -- ", 
                        ex);
                }
            }
        }

        private void AddWhyToPanel(MiscastWhy why)
        {
            RCAWhy rcaWhy = new RCAWhy(why, this.readOnly);
            pnlWhys.Controls.Add(rcaWhy);
            rcaWhy.Dock = DockStyle.Top;
            rcaWhy.BringToFront();
            rcaWhy.Font = new Font("Tahoma", 8, FontStyle.Regular);
            rcaWhy.Padding = new Padding(0);
            rcaWhy.Margin = new Padding(0);
            rcaWhy.Height = 26;
            rcaWhy.MiscastWhyDeletedEvent += new
                RCAWhy.MiscastWhyDeletedEventHandler(rcaWhy_MiscastWhyDeletedEvent);
            rcaWhy.MiscastWhyChangedEvent += new 
                RCAWhy.MiscastWhyChangedEventHandler(rcaWhy_MiscastWhyChangedEvent);
        }

        private void rcaWhy_MiscastWhyChangedEvent()
        {
            if (this.dataLoaded && this.MiscastInvestigationChangedEvent != null)
            {
                this.MiscastInvestigationChangedEvent();
            }
        }

        private void Ctrl_Modified(object sender, EventArgs e)
        {
            if (this.dataLoaded && this.MiscastInvestigationChangedEvent != null)
            {
                this.MiscastInvestigationChangedEvent();
            }
        }
    }
}
