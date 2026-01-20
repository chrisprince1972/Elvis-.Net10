using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elvis.UserControls.Generic
{
    public partial class LegendForChart : CheckBoxGrid
    {

        /// <summary>
        /// Ctor.
        /// </summary>
        public LegendForChart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The real entry point of the function, this is prefered as you cannot drag and drop
        /// components that have parameters on their ctors.
        /// </summary>
        /// <param name="series">List of series to generate the check boxes from.</param>
        /// <param name="width">How many columns wide the grid should be.</param>
        public void SetupUserControl(
            List<
            ElvisDataModel
            .EDMX
            .ChartSery> series, int width)
        {
            base.SetupUserControl(GetCheckBoxList(series), width);
        }

        /// <summary>
        /// Returns a list of series for a list of ChartsSeriesSets the rational was to allow more than one chart series set to be on a chart.
        /// This can then be fed into the SetupUserControlByDateRange.
        /// </summary>
        /// <param name="getDataTypes">List of chart series sets to get the series for.</param>
        /// <returns>List of all of the series to show. </returns>
        static public List<ElvisDataModel.EDMX.ChartSery> GetChartData
            (List<ElvisDataModel.EntityHelper.ChartSeriesSet.ChartSeriesSetTypes> getDataTypes)
        {
            return ElvisDataModel
                .EntityHelper
                .ChartSery
                .GetByChartID(getDataTypes);
        }


        /// <summary>
        /// Take a list of all of the series from the database and generate a list of objects that can
        /// be turned into checkboxes on the grid.
        /// </summary>
        /// <param name="series">List of series to be converted to checkbox descriptions.</param>
        /// <returns>List of checkbox specifications ready to be put onto the grid.</returns>
        List<CheckBoxGrid.CheckBoxInfo> GetCheckBoxList(
            List<
            ElvisDataModel
            .EDMX
            .ChartSery> series)
        {
            List<CheckBoxGrid.CheckBoxInfo> listOfCheckBoxes = new List<CheckBoxGrid.CheckBoxInfo>();

            foreach (ElvisDataModel.EDMX.ChartSery chartSeries in series)
            {
                CheckBox chb = new CheckBox();
                chb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                chb.Padding = new System.Windows.Forms.Padding(0, 0, 2, 1);
                chb.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                chb.AutoSize = true;
                chb.Dock = DockStyle.Left;
                chb.BringToFront();
                chb.Text = chartSeries.Name;
                chb.AutoSize = true;
                chb.Checked = chartSeries.VisableByDefault;

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(chb, GetToolTip(chartSeries.ID));

                chb.ForeColor = Color.SlateGray;
                if (chb.Checked)
                {
                    chb.ForeColor = System.Drawing.ColorTranslator.FromHtml(chartSeries.Colour);
                }

                CheckBoxGrid.CheckBoxInfo chkBoxInfo = new CheckBoxGrid.CheckBoxInfo()
                {
                    ObjCheckBox = chb,
                    ObjColor = System.Drawing.ColorTranslator.FromHtml(chartSeries.Colour),
                    ObjHighContrastColor = System.Drawing.ColorTranslator.FromHtml(chartSeries.ColourHighContrast),
                    ObjForTag = (object)chartSeries,
                    GroupTypeID = chartSeries.SeriesGroup
                };

                listOfCheckBoxes.Add(chkBoxInfo);
            }

            return listOfCheckBoxes;
        }



        /// <summary>
        /// Gets a string that describes what the checkbox values represent.
        /// </summary>
        /// <param name="dataLocationId">The data location to get the full name and reference id.</param>
        /// <returns>A string that describes the checkbox values.</returns>
        private string GetToolTip(int dataLocationId)
        {
            string toolTip = String.Empty;

            ElvisDataModel
                .EDMX
                .ChartDataLocation chartDataLocation
                    = ElvisDataModel
                    .EntityHelper
                    .ChartDataLocations
                    .GetByChartDataLocationsID(dataLocationId);

            if (chartDataLocation != null)
            {
                toolTip = chartDataLocation.Name + " [" + chartDataLocation.ReferenceId + "]";
            }

            return toolTip;
        }


    }
}
