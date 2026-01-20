using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic.Models.Reports.DailyManagementAgendaThreats;
using BusinessLogic.Models.ViewModels.Reports;
using Elvis.UserControls.Generic;

namespace Elvis.Forms.Reports.ManagementAgendaThreats
{
    public partial class DMAThreatIndex : Form
    {
        private delegate bool OnEditFunction(object obj);
        private readonly string ThreatTime24 = ThreatTimeScale.GetTimeScaleDescription(BusinessLogic.Constants.ThreatTimescales.Hour24Threat);
        private readonly string ThreatTimeLongTerm = ThreatTimeScale.GetTimeScaleDescription(BusinessLogic.Constants.ThreatTimescales.LongTermPm);
        public DMAThreatIndex()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void LoadTable()
        {
            Cursor.Current = Cursors.WaitCursor;
            tableRowHeadersThreats.Visible = false;
            tableRowHeadersThreats.Controls.Clear();

            tableRowHeadersThreats.ColumnCount = 2;
            tableRowHeadersThreats.Height = 0;
            tableRowHeadersThreats.RowCount = 0;
            tableRowHeadersThreats.RowStyles.Clear();

            List<DailyManagementAgendaThreatIndex> listThreatAgendas = DailyManagementAgendaThreat.GetAllAgendas();
            foreach (DailyManagementAgendaThreatIndex threatAgenda in listThreatAgendas)
            {
                List<CellContents> threats = new List<CellContents>();
                Headers headers = GenerateHeaders(threatAgenda.LocationDescription);
                CellContents shortTermThreat = new CellContents(threatAgenda.ShortTermThreat.Threat, threatAgenda.ShortTermThreat, OnEdit);
                CellContents longTermThreat = new CellContents(threatAgenda.LongTermThreat.Threat, threatAgenda.LongTermThreat, OnEdit);
                threats.Add(shortTermThreat);
                threats.Add(longTermThreat);

                tableRowHeadersThreats.AddRow(headers, threats);
            }

            tableRowHeadersThreats.HorizontalScroll.Maximum = 0;
            tableRowHeadersThreats.AutoScroll = false;
            tableRowHeadersThreats.VerticalScroll.Visible = false;
            tableRowHeadersThreats.AutoScroll = true;

            tableRowHeadersThreats.Visible = true;
            Cursor.Current = Cursors.Default;
            tableRowHeadersThreats.SetFocusOnFirstButton();
        }

        private Headers GenerateHeaders(string topTitle)
        {
            Font f12 = new System.Drawing.Font("Microsoft Sans Serif", 12);
            Font f10 = new System.Drawing.Font("Microsoft Sans Serif", 10);
            ColumnHeaderInfo chi = new ColumnHeaderInfo(topTitle, 2, 30, f12);
            List<ColumnHeaderInfo> headerCols = new List<ColumnHeaderInfo>();
            headerCols.Add(chi);
            Header head = new Header(headerCols);

            List<ColumnHeaderInfo> headerColTimeSpan = new List<ColumnHeaderInfo>();

            ColumnHeaderInfo chi24 = new ColumnHeaderInfo(ThreatTime24, 1, 30, f10);
            ColumnHeaderInfo chiLongTerm = new ColumnHeaderInfo(ThreatTimeLongTerm, 1, 30, f10);
            headerColTimeSpan.Add(chi24);
            headerColTimeSpan.Add(chiLongTerm);
            Header headTimeSpan = new Header(headerColTimeSpan);

            List<Header> listOfHeaders = new List<Header>();
            listOfHeaders.Add(head);
            listOfHeaders.Add(headTimeSpan);


            Headers allHeaders = new Headers(listOfHeaders);

            return allHeaders;
        }

        private bool OnEdit(object dmaObj)
        {
            DailyManagementAgendaThreat dma = (DailyManagementAgendaThreat)dmaObj;

            DMAThreatEdit edit = new DMAThreatEdit(dma);
            edit.ShowDialog();
            LoadTable();
            return true;
        }


    }
}
