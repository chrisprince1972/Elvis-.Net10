using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;
using Data = ElvisDataModel.EDMX;
using System.ComponentModel;

namespace Elvis.Forms.Reports.Miscasts
{
    public partial class MiscastAddNew : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private bool hasError = false;
        private bool isAdmin;
        private List<MiscastRota> rotas;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HeatNumber { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int HeatNumberSet { get; set; }

        public MiscastAddNew(bool isMiscastAdmin)
        {
            InitializeComponent();
            this.isAdmin = isMiscastAdmin;
            GetRotas();
        }

        /// <summary>
        /// Pre-Populate Heat Number.
        /// </summary>
        /// <param name="heatNumber">The Heat Number of the Miscast.</param>
        /// <param name="heatNumberSet">The Heat Number Set of the Miscast.</param>
        /// <param name="isMiscastAdmin">Is the user a Miscast Admin.</param>
        public MiscastAddNew(int heatNumber, int heatNumberSet, bool isMiscastAdmin)
        {
            InitializeComponent();
            this.isAdmin = isMiscastAdmin;
            GetRotas();
            txtHeatNo.Text = heatNumber.ToString();
            txtHeatNumberSet.Text = heatNumberSet.ToString();
        }

        private void GetRotas()
        {
            try
            {
                this.rotas = EntityHelper.MiscastRota.GetAll();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Could not get Rotas from Elvis database -- GetRotas() -- ",
                    ex);
            }
        }

        private void MiscastAddNew_Load(object sender, EventArgs e)
        {
            txtDateRaised.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if (string.IsNullOrWhiteSpace(txtHeatNumberSet.Text))
            {
                LoadHeatNumberSet();
            }
            this.Cursor = Cursors.Default;
        }

        private void LoadHeatNumberSet()
        {
            try
            {
                int hns = EntityHelper.Tracking.GetLatestHNS();
                txtHeatNumberSet.Text = hns.ToString();
            }
            catch (Exception ex)
            {
                logger.ErrorException("DATA ERROR -- Could not get HNS from database -- LoadHeatNumberSet() -- ", ex);
            }
        }

        private void btnAddMiscast_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            AddMiscast();
            this.Cursor = Cursors.Default;
        }

        private void txtHeatNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Enter Key
            {
                AddMiscast();
            }

            //Checks input for numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void AddMiscast()
        {
            int heatNumber = 0;
            int heatNumberSet = 0;
            DateTime dateRaised = new DateTime();

            if (int.TryParse(txtHeatNo.Text, out heatNumber) && //Good Heat Number
                int.TryParse(txtHeatNumberSet.Text, out heatNumberSet) && //Good Heat Number Set
                DateTime.TryParse(txtDateRaised.Text, out dateRaised))//Good Date Raised
            {
                if (MiscastAlreadyExists(heatNumber, heatNumberSet))
                {
                    DialogResult result = MessageBox.Show(string.Format(
                        "Miscast already exists for Heat Number: {0}.  Would you like to edit the Miscast Record now?",
                            heatNumber),
                        "Heat Number Already Exists",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );
                    if (result == DialogResult.Yes)
                    {
                        OpenEditMiscast(heatNumber, heatNumberSet);
                    }
                }
                else
                {
                    if (heatNumber >= Settings.Default.MinHeatNumber &&
                        heatNumber <= Settings.Default.MaxHeatNumber)
                    {
                        try
                        {
                            DateTime tapTime = GetTapTime(dateRaised, heatNumber, heatNumberSet);
                            string rota = "#";
                            try
                            {
                                rota = EntityHelper.DateInfo.GetRotaByDate(tapTime);
                                if (string.IsNullOrWhiteSpace(rota))
                                {
                                    rota = "#";
                                }
                            }
                            catch (Exception ex)
                            {
                                logger.ErrorException(
                                    "DATA ERROR -- Error getting Rota for new Miscast -- AddMiscast()",
                                    ex);
                            }

                            Data.MiscastMain newMiscast = new Data.MiscastMain()
                            {
                                HeatNumberSet = heatNumberSet,
                                HeatNumber = heatNumber,
                                HotConnect = false,
                                MiscastRotaID = GetRotaID(rota.Trim()),
                                ProblemStatementName = txtName.Text,
                                ShiftComplete = false,
                                TechComplete = false,
                                DateRaised = dateRaised,
                                LastEdit = dateRaised,
                                TapTime = tapTime,
                                InstallationGoodCondition = false,
                                StandardPracticeFollowedID 
                                = (int)ElvisDataModel
                                        .EntityHelper
                                        .LookupStandardPracticeFollowed
                                        .StandarPrictiseFollowedTypes
                                        .NotFollowed,
                                //Opening Status - 'Shift Investigation Open'
                                MiscastStatusID = 1,
                                RootCauseID = 
                                    (int)ElvisDataModel
                                    .EntityHelper
                                    .MiscastRootCause
                                    .MiscastRootCauseTypes
                                    .NotSet
                            };

                            EntityHelper.MiscastMain.AddNew(newMiscast);
                            HeatNumber = newMiscast.HeatNumber;
                            HeatNumberSet = newMiscast.HeatNumberSet;
                            return;
                        }
                        catch (Exception ex)
                        {
                            logger.ErrorException(
                                "DATA ERROR -- Error adding new miscast record -- AddMiscast()",
                                ex);
                            MessageBox.Show(
                                "Error adding Miscast Report. This has been logged.",
                                "Error Adding Miscast Report",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            string.Format("Heat Number must be between {0} and {1}.",
                                Settings.Default.MinHeatNumber,
                                Settings.Default.MaxHeatNumber),
                            "Invalid Heat Number",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Data entry values invalid.  Please check your input and try again.",
                    "Invalid Data Entry",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
            this.hasError = true;
        }

        private void OpenEditMiscast(int heatNumber, int heatNumberSet)
        {
            MiscastReportHolder miscastReport = new MiscastReportHolder(
                heatNumber, heatNumberSet, this.isAdmin);
            miscastReport.ShowDialog();
            this.Close();
        }

        private bool MiscastAlreadyExists(int heatNumber, int heatNumberSet)
        {
            try
            {
                Data.MiscastMain miscast = EntityHelper.MiscastMain.GetByHeatNumber(
                    heatNumber,
                    heatNumberSet);

                if (miscast != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error checking if Miscast exists -- MiscastAlreadyExists() -- ",
                    ex);
            }
            return false;
        }

        private DateTime GetTapTime(DateTime backupDateTime, int heatNumber, int heatNumberSet)
        {
            try
            {
                Vessel vesselRecord = EntityHelper.Vessel.GetByHeat(
                    heatNumber, heatNumberSet
                    );
                if (vesselRecord != null && vesselRecord.StartTapTime.HasValue)
                {
                    return vesselRecord.StartTapTime.Value;
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting TapTime for Miscast Record -- GetTapTime()",
                    ex);
            }
            //Returns the backup time for this value (which is the DateRaised).
            //This only occurs if no TapTime is present for that heat.
            return backupDateTime;
        }

        private int GetRotaID(string rota)
        {
            if (this.rotas != null)
            {
                MiscastRota miscastRota = this.rotas.FirstOrDefault(r =>
                    r.Rota.Contains(rota));

                if (miscastRota != null)
                {
                    return miscastRota.RotaID;
                }
            }
            return 1;//default safe value
        }

        private void FindHeat_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = this.hasError;
            this.hasError = false;
        }
    }
}
