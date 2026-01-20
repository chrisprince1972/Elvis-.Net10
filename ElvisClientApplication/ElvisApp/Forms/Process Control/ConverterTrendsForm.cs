using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Windows.Forms.DataVisualization.Charting;

namespace Elvis.Forms.Process_Control
{
    public partial class ConverterTrendsForm : Form
    {
        private string csPsmetRO = @"DSN=psmet; UID=int_ro; PWD=bosmis";
        private Color seriesColour = Color.SteelBlue;
        private Color seriesHighlightColour = Color.LightSteelBlue;
        private DateTime startDate, endDate;

        private int vesselNo = 0;

        private DataTable data;

        public ConverterTrendsForm()
        {
            InitializeComponent();

            GetData();
            ShowTapWeightData(data);
        }

        private void GetData()
        {
            startDate = DateTime.Parse("2014-04-03 07:00");
            endDate = DateTime.Parse("2014-04-04 07:00");

            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT   hv.heat_number heat, ");
            sql.Append("          hv.rota, ");
            sql.Append("          hv.yield, ");
            sql.Append("          hv.hm_ratio, ");
            sql.Append("          hv.hot_metal, ");
            sql.Append("          hv.scrap, ");
            sql.Append("          hv.gmc,");
            sql.Append("          cv.tap_weight, ");
            sql.Append("          cv.des_loss, ");
            sql.Append("          cv.hm_pour_difference, ");
            sql.Append("          cv.hm_charge_rate, ");
            sql.Append("          hv.actual_converter as vessel ");
            sql.Append(" FROM     pms_heat_view hv, ");
            sql.Append("          pms_crane_view cv ");
            sql.Append(" WHERE    hv.heat_number_set = cv.heat_number_set ");
            sql.Append(" AND      hv.heat_number = cv.heat_number ");
            sql.Append(" AND      hv.start_tap_time >= '" + startDate.ToString("dd-MMM-yyyy HH:mm:ss.ff") + "' ");
            sql.Append(" AND      hv.start_tap_time < '" + endDate.ToString("dd-MMM-yyyy HH:mm:ss.ff") + "' ");
            //if (vesselNo != 0) sql.Append(" AND      hv.actual_converter = " + vesselNo.ToString());
            //if (shift != 0) sql.Append(" AND      hv.shift_no = " + shift.ToString());
            sql.Append(" ORDER BY hv.start_tap_time ASC");
            //TODO: this wont be happening ever again
        //    data = FetchRdbData(sql.ToString(), csPsmetRO)
            data = null;
        }

        private void ShowTapWeightData(DataTable dt)
        {
            chart1.DataSource = dt;
            chart1.Series[0].Color = seriesColour;
            chart1.Series[0].XValueMember = "heat";
            chart1.Series[0].YValueMembers = "tap_weight";
            chart1.Series[0].Name = "Tap Weight";
            chart1.Series[0].ToolTip = "Tap Weight for #VALX was #VALY tonnes.";
            chart1.Series[0].LabelToolTip = "#VALY";
            chart1.DataBind();            
        }

//TODO: conversion fix not sure if this will be needed
//public DataTable FetchRdbData(string sql, string connectionString)
        //{
        //    using (OdbcDataAdapter adapt = new OdbcDataAdapter(sql, connectionString))
        //    {
        //        DataTable dt = new DataTable();
        //        adapt.Fill(dt);
        //        foreach (DataRow dr in dt.Rows)
        //            for (int c = 0; c < dt.Columns.Count; c++)
        //                if (dt.Columns[c].DataType == typeof(string)) dr[c] = dr[c].ToString().Trim();
        //        return dt;
        //    }
        //}

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult htrResult = chart1.HitTest(e.X, e.Y);
            foreach (DataPoint dp in chart1.Series[0].Points)
            {
                dp.BackSecondaryColor = Color.White;
                dp.BackHatchStyle = ChartHatchStyle.None;
                dp.BorderWidth = 0;
                dp.Color = seriesColour;
                dp.Label = string.Empty;
            }

            // If users mouse hovers over a datapoint or it's equivalent 
            // Legend Item then set cursor to hand to indicate that it is a link
            // Also we use some design elements to indicate which DataPoint is active
            if (htrResult.PointIndex >= 0)
            {
                if (htrResult.ChartElementType == ChartElementType.DataPoint)
                {
                    this.Cursor = Cursors.Hand;
                    DataPoint dpSelected;
                    dpSelected = chart1.Series[0].Points[htrResult.PointIndex];
                    dpSelected.BackSecondaryColor = Color.Black;
                    dpSelected.BorderColor = Color.White;
                    dpSelected.BorderWidth = 1;
                    dpSelected.Color = seriesHighlightColour;
                    dpSelected.Label = dpSelected.YValues.First().ToString("#0");
                }
            }
            else
            {
                //Set cursor back to default when leaving selected datapoint
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void datepickerStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datepickerEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkVessel1_CheckedChanged(object sender, EventArgs e)
        {
            vesselNo = (chkVessel1.Checked && chkVessel2.Checked) ? 0 :
                        chkVessel1.Checked ? 1 : 
                        chkVessel2.Checked ? 2 : 
                        -1;

            FilterByVessel();
           
        }

        private void chkVessel2_CheckedChanged(object sender, EventArgs e)
        {
            vesselNo = (chkVessel1.Checked && chkVessel2.Checked) ? 0 :
                        chkVessel1.Checked ? 1 :
                        chkVessel2.Checked ? 2 :
                        -1;

            FilterByVessel();
        }

        private void FilterByVessel()
        {
            switch (vesselNo)
            {
                case 0:
                    ShowTapWeightData(data);
                    break;

                case -1:
                case 1:
                case 2:
                    DataRow[] drs = data.Select("vessel = " + vesselNo);
                    //make a new "results" datatable via clone to keep structure
                    DataTable dt2 = data.Clone();
                    //Import the Rows
                    foreach (DataRow d in drs)
                    {
                        dt2.ImportRow(d);
                    }
                    ShowTapWeightData(dt2);
                    break;

            }
        }

    }

    enum VesselNo : int
    {
        Both, 
        Vessel1, 
        Vessel2, 
        None
    }
}
