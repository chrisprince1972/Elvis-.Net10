using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Model.ViewModels;

namespace Elvis.UserControls.HeatDetails
{
    public partial class SteelInMouldSpeedRatio : UserControl
    {
        private SteelInMouldViewModel _viewModel;

        public DataGridView CastersDataGridView
        {
            get { return castersDataGridView; }
        }

        public SteelInMouldSpeedRatio()
        {
            InitializeComponent();

            _viewModel = new SteelInMouldViewModel();

            castersDataGridView.AutoGenerateColumns = false;
            dayColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Cc1SpeedRatioColumn.DefaultCellStyle.Format = "n3";
            Cc2SpeedRatioColumn.DefaultCellStyle.Format = "n3";
            Cc3SpeedRatioColumn.DefaultCellStyle.Format = "n3";
        }

        public void SetViewModel(SteelInMouldViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel",
                    "A non-null instance of the View Model must be supplied");
            }
            _viewModel = viewModel;
            castersDataGridView.DataSource = _viewModel.Items;
        }
    }
}
