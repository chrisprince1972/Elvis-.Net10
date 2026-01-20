using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Elvis.Common;
using Elvis.Properties;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using NLog;

namespace Elvis.UserControls.HeatDetails.HotMetalUCs
{
    public partial class SkimQuality : UserControl
    {
        private int heatNumber;
        private int heatNumberSet;
        private Image skimPic;
        private List<DesulphSkimPercentage> skimList;
        private BackgroundWorker worker = new BackgroundWorker();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public SkimQuality()
        {
            InitializeComponent();
            dgvSkimQuality.AutoGenerateColumns = false;
            SetupBackgroundWorker();
            CustomiseColours();
        }

        /// <summary>
        /// Customises Colours Depending on User Settings
        /// </summary>
        private void CustomiseColours()
        {
            this.BackColor =
                pnlSkimQuality.BackColor =
                pnlImage.BackColor =
                grpSkimQuality.BackColor =
                dgvSkimQuality.BackgroundColor =
                    Settings.Default.ColourBackground;

            this.ForeColor =
                pnlSkimQuality.ForeColor =
                pnlImage.ForeColor =
                grpSkimQuality.ForeColor =
                    Settings.Default.ColourText;
        }

        /// <summary>
        /// Sets up the user control with the heats data.
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        public void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            CommonMethods.LoadImageIntoChildPanel(Resources.loading, grpSkimQuality, pnlSkimQuality);
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;
            this.skimList = new List<DesulphSkimPercentage>();

            if (!this.worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Populates the Form.
        /// </summary>
        private void PopulateForm()
        {
            pbSkim.Image = null;
            grpSkimQuality.Controls.Clear();
            grpSkimQuality.Controls.Add(pnlSkimQuality);
            pnlSkimQuality.Visible = true;
            pnlSkimQuality.Dock = DockStyle.Fill;
            pnlSkimQuality.BringToFront();
            dgvSkimQuality.DataSource = null;

            if (this.skimList != null &&
                this.skimList.Count > 0)
            {
                dgvSkimQuality.DataSource = this.skimList;
                dgvSkimQuality.ClearSelection();
            }

            if (this.skimPic != null)
            {
                pbSkim.SizeMode = PictureBoxSizeMode.Zoom;
                pbSkim.Image = this.skimPic;
                pbSkim.Cursor = Cursors.Hand;

                if (pbSkim.Tag != null && pbSkim.Tag.ToString().Equals("Error"))
                {
                    pbSkim.SizeMode = PictureBoxSizeMode.CenterImage;
                    pbSkim.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Gets the image for the Skim for a specific heat.
        /// ********************************************************************
        /// *** There will be an issue with this on the next heat wrap *********
        /// *** The file structure on the HMSkimImageLocation needs updating ***
        /// ********************************************************************
        /// </summary>
        /// <returns>The Skim Image.</returns>
        private Image GetDesulphSkimImage()
        {
            try
            {
                if (this.heatNumber >= Settings.Default.MinHeatNumber &&
                    this.heatNumber <= Settings.Default.MaxHeatNumber)
                {
                    pbSkim.Tag = "Good";
                    return new Bitmap(GetSkimImagePathName());
                }
            }
            catch (ArgumentException)
            {
                //Image was not found, we don't need to log this as it is a common occurrance
                pbSkim.Tag = "Error";
                return Resources.RedCrossSmall;
            }
            catch (Exception ex)
            {
                logger.ErrorException(string.Format(
                    "IMAGE ERROR -- GetDesulphSkimImage() -- Could not get Skim Desulph image -- HeatNumber: {0} -- ",
                    this.heatNumber),
                    ex);
            }
            pbSkim.Tag = "Error";
            return Resources.RedCrossSmall;
        }

        /// <summary>
        /// Open's skim image using the default windows application.
        /// ********************************************************************
        /// *** There will be an issue with this on the next heat wrap *********
        /// *** The file structure on the HMSkimImageLocation needs updating ***
        /// ********************************************************************
        /// </summary>
        public void OpenSkimImage()
        {
            try
            {
                if (this.heatNumber >= Settings.Default.MinHeatNumber &&
                    this.heatNumber <= Settings.Default.MaxHeatNumber)
                {
                    Process process = new Process();

                    process.StartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = GetSkimImagePathName()
                    };

                    process.Start();
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException(string.Format(
                    "ERROR RETRIEVING FILE -- OpenSkimImage() -- HeatNumber: {0} -- ", this.heatNumber),
                    ex);

                MessageBox.Show(
                    "Error opening the requested file. This has been logged.",
                    "Error Opening File",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Builds the path for the skim image
        /// </summary>
        /// <returns>A path as a string.</returns>
        private string GetSkimImagePathName()
        {
            return Path.Combine(
                Settings.Default.HMSkimImageLocation,
                this.heatNumber.ToString() + ".jpg"
            );
        }

        /// <summary>
        /// Gets the DesulphSkinPercentages by heat.
        /// </summary>
        /// <returns>A list of DesulphSkimPercentage.</returns>
        private List<DesulphSkimPercentage> GetDesulphSkimPercentages()
        {
            try
            {
                return EntityHelper.DesulphSkimPercentage.GetByHeat(
                    this.heatNumber, this.heatNumberSet
                    );
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- Error getting desulph skim percentages -- GetDesulphSkimPercentages() -- ",
                    ex);
            }
            return new List<DesulphSkimPercentage>();
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

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateForm();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.skimList = new List<DesulphSkimPercentage>();
            this.skimPic = null;

            this.skimList = GetDesulphSkimPercentages();
            this.skimPic = GetDesulphSkimImage();
        }

        private void SkimQuality_Load(object sender, EventArgs e)
        {
            dgvSkimQuality.ClearSelection();
        }

        private void dgvSkimQuality_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvSkimQuality.ClearSelection();
        }

        private void pbSkim_MouseEnter(object sender, EventArgs e)
        {
            if (pbSkim.Tag != null && 
                pbSkim.Tag.ToString().Equals("Good"))
            {
                pbSkim.BackColor = ColorTranslator.FromHtml("#303030");
                toolTip1.SetToolTip(pbSkim, "Open Skim Image");
            }
            else if (pbSkim.Tag != null && 
                pbSkim.Tag.ToString().Equals("Error"))
            {
                toolTip1.SetToolTip(pbSkim, "Skim Image Not Found!");
            }
        }

        private void pbSkim_MouseLeave(object sender, EventArgs e)
        {
            pbSkim.BackColor = ColorTranslator.FromHtml("#101010");
        }

        private void pbSkim_Click(object sender, EventArgs e)
        {
            if (pbSkim.Tag.ToString().Equals("Good"))
            {
                OpenSkimImage();
            }
        }
    }
}
