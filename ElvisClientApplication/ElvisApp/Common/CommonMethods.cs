using System;
using System.Collections.Generic;
using System.Data;
//using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using Elvis.EmailServiceReference;
using Elvis.Forms.General;
using Elvis.Forms.Reports.DRF;
using ElvisDataModel;
using NLog;
using Elvis.Forms.Reports.I3;
using ExportToExcel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Elvis.Common.ThirdPartyControls;

namespace Elvis.Common
{
    public static class CommonMethods
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Checks the server for the latest version of the software.
        /// </summary>
        /// <param name="checkSilently">Check silently i.e. hide it from the user.</param>
        public static void CheckForUpdates(bool checkSilently, Timer timer)
        {
            //TODO: fix this block commented out on conversiom
            //if (timer != null)
            //{
            //    timer.Stop();
            //    timer.Enabled = false;
            //}
            //UpdateCheckInfo info = null;
            ////Only update if deployed software
            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

            //    try
            //    {
            //        info = ad.CheckForDetailedUpdate();
            //    }
            //    catch (DeploymentDownloadException dde)
            //    {
            //        if (!checkSilently)
            //        {
            //            MessageBox.Show(
            //                "The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " +
            //                dde.Message, "Failed Update",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (InvalidDeploymentException ide)
            //    {
            //        if (!checkSilently)
            //        {
            //            MessageBox.Show(
            //                "Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " +
            //                ide.Message, "Failed Update",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (InvalidOperationException ioe)
            //    {
            //        if (!checkSilently)
            //        {
            //            MessageBox.Show(
            //                "This application cannot be updated. It is likely not a ClickOnce application. Error: " +
            //                ioe.Message, "Failed Update",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }
            //    }

            //    if (info != null &&
            //        info.UpdateAvailable)
            //    {
            //        Boolean doUpdate = true;

            //        if (!info.IsUpdateRequired)
            //        {
            //            DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?",
            //                "Update Available",
            //                MessageBoxButtons.YesNo);

            //            if (dr == DialogResult.No)
            //                doUpdate = false;
            //        }
            //        else
            //        {
            //            // Display a message that the app MUST reboot. Display the minimum required version.
            //            MessageBox.Show("This application has detected a mandatory update from your current " +
            //                "version to version " + info.MinimumRequiredVersion.ToString() +
            //                ". The application will now install the update and restart.",
            //                "Update Available",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);
            //        }

            //        if (doUpdate)
            //        {
            //            try
            //            {
            //                ad.Update();
            //                MessageBox.Show("The application has been upgraded, and will now restart.",
            //                    "Update Successful");
            //                Application.Restart();
            //            }
            //            catch (DeploymentDownloadException dde)
            //            {
            //                MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " +
            //                    dde, "Failed Update",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    else if (!checkSilently)
            //    {
            //        MessageBox.Show(string.Format(
            //                "Software is running the latest version (v{0}).",
            //                HelperFunctions.GetVersionNumber()),
            //            "Update Information",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            //}
            //if (timer != null)
            //{
            //    timer.Enabled = true;
            //    timer.Start();
            //}
        }

        /// <summary>
        /// Add or edit a DRF report
        /// </summary>
        /// <param name="drfIndex">The DRF index to edit (Set to 
        /// zero to add a new DRF Report).</param>
        /// <param name="tibDelayIndex">The Delay Index that the Report is 
        /// associated with (set to zero if no delay).</param>
        /// <returns>Boolean stating if any changes have been made and if
        /// you should refresh your results or not.</returns>
        public static bool AddEditDRF(int drfIndex, int tibDelayIndex)
        {
            using (AddEditDRF newDRF = new AddEditDRF(drfIndex, tibDelayIndex))
            {
                DialogResult result = newDRF.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return true;
                }
                return false;
            }
        }


        /// <summary>
        /// Add or edit a I3 report
        /// </summary>
        /// <param name="id">The Id index to edit (Set to 
        /// zero to add a new I3 Report).</param>
        public static bool AddEditI3(int id)
        {
            using (I3AddEdit newI3 = new I3AddEdit(id))
            {
                DialogResult result = newI3.ShowDialog();

                return result == DialogResult.OK;
            }
        }

        /// <summary>
        /// Display message box prompting input from the user whether or 
        /// not they want to record additional info for debugging.
        /// </summary>
        public static string UnknownErrorHandled()
        {
            using (ErrorBox errorBox = new ErrorBox())
            {
                errorBox.ShowDialog();
                return errorBox.UserInfo;
            }
        }

        /// <summary>
        /// Highlights or returns a Control to normal for validation.
        /// </summary>
        /// <param name="ctrl">The Control you wish to modify the appearance of.</param>
        /// <param name="state">True for higlight, false for normal.</param>
        public static void HighlightControl(Control ctrl, bool state)
        {
            ctrl.BackColor = SystemColors.Window;
            ctrl.ForeColor = SystemColors.ControlText;
            if (state)
            {
                ctrl.BackColor = ColorTranslator.FromHtml("#FF3C2B");//Red
                ctrl.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Used to format the column headers of the DataGridview manually.
        /// There is a bug where the Datagridview will always change the fontsize to the
        /// parent container font size.  This overwrites that issue.
        /// </summary>
        /// <param name="dgv">The Datagridview to format.</param>
        /// <param name="font">The font to set the column header to.</param>
        public static void FormatColumnFont(DataGridView dgv, Font font)
        {
            dgv.ColumnHeadersDefaultCellStyle.Font = font;
            dgv.AutoResizeRows();
            dgv.ClearSelection();
        }

        /// <summary>
        /// Method that e-mails the new owner of the report/action.
        /// </summary>
        /// <param name="type">The Type of E-Mail. Current Valid Values: 'New DRF Report', 'New DRF Actions'.</param>
        /// <param name="drfIndex">The index of the DRF Report.</param>
        /// <param name="additionalText">Additional text to be used as a description.</param>
        /// <param name="recipient">The recipients e-mail address.</param>
        public static bool EmailDRFOwner(string type, int drfIndex, string additionalText, string recipient)
        {
            try
            {
                StringBuilder message = new StringBuilder();
                string[] recipients = new string[1];
                recipients[0] = recipient;

                if (drfIndex == 0)
                    drfIndex = EntityHelper.DRFReport.GetMaxDRFIndex();

                if (type == "New DRF Report")
                {
                    message.Append("This is an automatic e-mail to inform you that you are the owner of a newly created/updated DRF Report.<br />");
                    message.Append("To access this report, please open your Elvis application and navigate to the DRF section.<br /><br />");
                    message.AppendFormat("<b>DRF Index:</b> {0}<br />", drfIndex);
                    message.AppendFormat("<b>Description:</b> {0}<br /><br />", additionalText);
                    message.Append("<b>Tip:</b> You can quickly search using the DRF Index on the DRF Overview screen (Ctrl+F).<br /><br />");
                }
                else if (type == "New DRF Action")
                {
                    message.Append("This is an automatic e-mail to inform you that an action has been created/updated against you on a <b>DRF Report</b>.<br />");
                    message.Append("To access this action, please open your Elvis application and navigate to the DRF Report.<br /><br />");
                    message.AppendFormat("<b>DRF Index:</b> {0}<br />", drfIndex);
                    message.AppendFormat("<b>Action:</b> {0}<br /><br />", additionalText);
                    message.Append("<b>Tip:</b> You can quickly search using the DRF Index on the DRF Overview screen (Ctrl+F).<br /><br />");
                }
                //using (EmailServiceClient emServ = new EmailServiceClient())
                //{
                //    emServ.SendEmailNew(
                //        "Elvis", recipients, "",
                //        "DRFReporting@Elvis.com",
                //        "Elvis - DRF Reporting", "", type,
                //        true, message.ToString(), false, "");
                //    return true;
                //}
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "ERROR SENDING EMAIL - EmailOwner(type='{0}', drfIndex={1}, additionalText='{2}', recipient='{3}'",
                        type, drfIndex, additionalText, recipient),
                        ex);
            }
            return false;
        }

        /// <summary>
        /// Method that e-mails the new owner of a miscast action.
        /// </summary>
        /// <param name="type">The Type of E-Mail. Current Valid Values: 'New Miscast Action'.</param>
        /// <param name="heatNumber">The Heat Number of the Miscast Report.</param>
        /// <param name="actionText">Additional text to be used as a description.</param>
        /// <param name="recipient">The recipients e-mail address.</param>
        public static bool EmailMiscastOwner(string type, int heatNumber, 
            string actionText, string recipient)
        {
            try
            {
                StringBuilder message = new StringBuilder();
                string[] recipients = new string[1];
                recipients[0] = recipient;

                if (type == "New Miscast Action")
                {
                    message.Append("This is an automatic e-mail to inform you that an action has been created/updated against you on a <b>Miscast Report</b>.<br />");
                    message.Append("To access this action, please open your Elvis application and navigate to the Miscast Report.<br /><br />");
                    message.AppendFormat("<b>Heat Number:</b> {0}<br />", heatNumber);
                    message.AppendFormat("<b>Action:</b> {0}<br /><br />", actionText);
                    message.Append("<b>Tip:</b> You can quickly search using the Heat Number on the Miscast Reports screen (Ctrl+F).<br /><br />");
                }
                //using (EmailServiceClient emServ = new EmailServiceClient())
                //{
                //    emServ.SendEmailNew(
                //        "Elvis", recipients, "",
                //        "MiscastReporting@Elvis.com",
                //        "Elvis - Miscast Reporting", "", type,
                //        true, message.ToString(), false, "");
                //    return true;
                //}
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    string.Format(
                        "ERROR SENDING EMAIL - EmailOwner(type='{0}', heatNumber={1}, actionText='{2}', recipient='{3}'",
                        type, heatNumber, actionText, recipient),
                        ex);
            }
            return false;
        }

        /// <summary>
        /// Finds the user settings from the last time the user 
        /// opened the window.  Uses the groupbox to search and the settings
        /// string to confirm if the checkbox should be checked or not.
        /// </summary>
        /// <param name="grp">The groupbox to search through for checkboxes.</param>
        /// <param name="settings">The Settings variable to use.</param>
        public static void SetupFilters(GroupBox grp, string settings)
        {
            if (!string.IsNullOrEmpty(settings))
            {
                foreach (CheckBox chb in grp.Controls)
                {
                    if (chb.Tag != null)
                    {
                        chb.Checked = settings.Contains("," + chb.Tag.ToString() + ",");
                    }
                }
            }
        }

        public static void SetupFilters(Panel pnl, string settings)
        {
            if (!string.IsNullOrEmpty(settings))
            {
                foreach (CheckBox chb in pnl.Controls)
                {
                    if (chb.Tag != null)
                    {
                        chb.Checked = settings.Contains("," + chb.Tag.ToString() + ",");
                    }
                }
            }
        }

        /// <summary>
        /// Builds a string to store off as a user setting for the report screens.
        /// Pass a groupbox and it will search it for checkboxes and automatically
        /// build a string to store.
        /// </summary>
        /// <param name="grp">The Groupbox you wish to search.</param>
        /// <returns>A string to store off as a user setting.</returns>
        public static string BuildSettingsString(GroupBox grp)
        {
            string settings = ",";
            foreach (CheckBox chb in grp.Controls)
            {
                if (chb.Tag != null && chb.Checked)
                {
                    settings += chb.Tag.ToString() + ",";
                }
            }
            return settings;
        }

        public static string BuildSettingsString(Panel pnl)
        {
            string settings = ",";
            foreach (CheckBox chb in pnl.Controls)
            {
                if (chb.Tag != null && chb.Checked)
                {
                    settings += chb.Tag.ToString() + ",";
                }
            }
            return settings;
        }

        /// <summary>
        /// Check if unit ID is a caster.
        /// True if caster.
        /// False if other unit.
        /// </summary>
        /// <param name="unitID">Unit ID to Check.</param>
        /// <returns>Boolean - True if Caster.</returns>
        public static bool IsCasterUnit(int unitID)
        {
            if (unitID > 10 && unitID < 14)
                return true;
            return false;
        }

        /// <summary>
        /// Loads an image into a uc
        /// </summary>
        public static void LoadImageIntoPanel(Image image, UserControl uc, Panel pnlMain)
        {
            pnlMain.Visible = false;
            PictureBox picBox = new PictureBox();
            picBox.Image = image;
            picBox.SizeMode = PictureBoxSizeMode.CenterImage;

            uc.Controls.Clear();
            uc.Controls.Add(picBox);
            picBox.Dock = DockStyle.Fill;
            picBox.BringToFront();
            picBox.Refresh();
        }

        /// <summary>
        /// Loads an image into a form with a panel.
        /// </summary>
        public static void LoadImageIntoPanel(Image image, Panel pnlMain)
        {
            PictureBox picBox = new PictureBox();
            picBox.Image = image;
            picBox.SizeMode = PictureBoxSizeMode.CenterImage;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(picBox);
            picBox.Dock = DockStyle.Fill;
            picBox.BringToFront();
            picBox.Refresh();
        }

        /// <summary>
        /// Loads an image into a Panel within a Groupbox
        /// </summary>
        public static void LoadImageIntoChildPanel(Image image, GroupBox grp, Panel pnl)
        {
            pnl.Visible = false;
            PictureBox picBox = new PictureBox();
            picBox.Image = image;
            picBox.SizeMode = PictureBoxSizeMode.CenterImage;

            grp.Controls.Clear();
            grp.Controls.Add(picBox);
            picBox.Dock = DockStyle.Fill;
            picBox.BringToFront();
            picBox.Refresh();
        }

        /// <summary>
        /// Converts a DataTable to a List of objects provided.
        /// </summary>
        /// <typeparam name="TSource">The object type you wish to convert to.</typeparam>
        /// <param name="dataTable">The DataTable to convert.</param>
        /// <returns>A list of objects.</returns>
        public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new
                                 {
                                     Name = aProp.Name,
                                     Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                                 }).ToList();
            var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                     select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();
            var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var aTSource = new TSource();
                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                    propertyInfos.SetValue(aTSource, dataRow[aField.Name], null);
                }
                dataList.Add(aTSource);
            }
            return dataList;
        }

        /// <summary>
        /// Basic ping function to establish a connection
        /// with the hostname provided.
        /// </summary>
        /// <param name="host">The host name of the machine you wish to ping.</param>
        /// <returns>An IPStatus object with the outcome of the ping.</returns>
        public static IPStatus PingHost(string host)
        {
            Ping ping = new Ping();
            try
            {
                PingReply pingReply = ping.Send(host, 1000);

                if (pingReply != null)
                {
                    return pingReply.Status;
                }
            }
            catch
            {
                return IPStatus.Unknown;
            }
            return IPStatus.Unknown;
        }

        /// <summary>
        /// Method to export data into an excel file.
        /// </summary>
        /// <param name="data">The data to export.  Entity Framwork objects
        /// could cause errors when converting if there are links to other
        /// tables.</param>
        /// <param name="onlyValueTypes">boolean stating whether or not to use
        /// different types in the conversion.  Setting to true can resolve some
        /// errors when converting entity framework objects.</param>
        public static void ExportDataToExcel<T>(List<T> data, bool onlyValueTypes)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Export Excel File To";
                saveFileDialog.FileName = "Sample.xlsx";
                saveFileDialog.Filter = "Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.OverwritePrompt = true;

                saveFileDialog.ShowDialog();

                if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    if (onlyValueTypes)
                    {
                        CreateExcelFile.CreateExcelDocumentValueType(data, saveFileDialog.FileName);
                    }
                    else
                    {
                        CreateExcelFile.CreateExcelDocument(data, saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("ERROR -- Error creating excel export -- ExportDataToExcel() -- CommonMethods.cs", ex);
                MessageBox.Show(
                    "Error creating Excel Export!", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Method to export data in xls format.
        /// This method uses the NPOI DLL to create an in memory representation of an Excel 2000 workbook and
        /// allows the user to save it to a location of their choice.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Data to export</param>
        public static void ExportDataToExcel<T>(List<T> data)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            HSSFWorkbook exportWbk = new HSSFWorkbook();
            ISheet sheet = exportWbk.CreateSheet("TibAdminData");
            IRow rowHeader = sheet.CreateRow(0);
            Type propType = data[0].GetType();
            int rowIndex = 0;

            try
            {
                saveFileDialog.Title = "Export Excel File To";
                saveFileDialog.FileName = "Data.xls";
                saveFileDialog.Filter = "Excel 2000 files (*.xls)|*.xls";
                saveFileDialog.ShowDialog();

                if (!string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    CreateXLSHeaderRow(data, sheet, true, 0);
                    foreach (var item in data)
                    {
                        CreateXLSHeaderRow(data, sheet, false, rowIndex);
                        rowIndex++;
                    }
                    using (Stream s = File.OpenWrite(saveFileDialog.FileName))
                    {
                        exportWbk.Write(s);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.ErrorException("ERROR -- Error creating XLS export -- ExportDataToExcel() -- CommonMethods.cs", ex);
                MessageBox.Show(
                    "Error creating Excel Export!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates an NPOI worksheet row. Dependent on the value of isHeader, will either create
        /// a header row at position 0 with object property names or a data row with
        /// the respective values for each property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">List of data objects to be exported - needed to get the actual object
        /// to be created as a row</param>
        /// <param name="sheet">The NPOI worksheet the row will be added to </param>
        /// <param name="isHeader">If this is true, then the row is created with index 0. If false the row is
        /// created at position rowIndex + 1</param>
        /// <param name="rowIndex">The position of the object in the data list</param>
        /// <returns></returns>
        private static IRow CreateXLSHeaderRow<T>(List<T> data, ISheet sheet, bool isHeader, int rowIndex)
        {
            //Get the property names of a list object, to act as column headers in the spreadsheet
            IRow newRow = isHeader == true ? sheet.CreateRow(0) : sheet.CreateRow(rowIndex + 1);
            Type propType = data[rowIndex].GetType();
            var item = data[rowIndex];
            int colIndex = 0;
            string cellValue = string.Empty;
             
            foreach (PropertyInfo pi in propType.GetProperties())
            {
                cellValue = string.Empty;
                //Lists formed from entity framework objects have 2 properties called EntityState and EntityKey, derived from
                //System.Data.Entity.dll. This check makes sure they are not exported with the required list data.
                if (!pi.Module.Name.Contains("System.Data.Entity"))
                {
                    if (isHeader)
                    {
                        cellValue = pi.Name;
                    }
                    else
                    {
                        if (pi.GetValue(item, null) != null)
                        {
                            cellValue = pi.GetValue(item, null).ToString();
                        }
                    }
                    newRow.CreateCell(colIndex, CellType.String).SetCellValue(cellValue);
                    colIndex++;
                }
            }
            return newRow;
        }

        /// <summary>
        /// Readies a combobox for data binding by
        /// clearing the current data.
        /// </summary>
        /// <param name="cmbo">The Combo box to ready.</param>
        public static void ReadyComboBox(ComboBox cmbo)
        {
            cmbo.DataSource = null;
            cmbo.Items.Clear();
        }

        /// <summary>
        /// Readies a checked combobox for data binding by
        /// clearing the current data and setting properties.
        /// </summary>
        /// <param name="ccb">The Checked Combo Box to ready.</param>
        /// <param name="maxDropDownItems">The Max amount of Drop Down Items (without scrolling).</param>
        /// <param name="displayMember">The Display Member Property.</param>
        /// <param name="valueSeparator">The Value Seperator between values selected 
        /// e.g. set to ',' would result in 'Item1, Item2, Item3, etc.'</param>
        public static void ReadyCheckedComboBox(CheckedComboBox ccb, int maxDropDownItems, string valueSeparator)
        {
            ccb.Text = "";
            ccb.DataSource = null;
            ccb.Items.Clear();
            ccb.MaxDropDownItems = maxDropDownItems;
            ccb.DisplayMember = "Name";
            ccb.ValueSeparator = valueSeparator;
        }

        /// <summary>
        /// Saves the Settings of the Application Safely.
        /// </summary>
        public static void SaveElvisSettings()
        {
            try
            {
                Elvis.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "SAVE SETTINGS ERROR -- SaveElvisSettings() -- Error saving user settings -- ", 
                    ex);
                MessageBox.Show(
                    "Error: " + ex.Message + " Failed to save user settings.", 
                    "Save Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
