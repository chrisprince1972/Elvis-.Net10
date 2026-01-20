using System;
using System.Collections.Generic;
using ElvisDataModel.EDMX;
using System.ComponentModel;

namespace Elvis.UserControls.HeatDetails
{
    public partial class TibUserControl : ElvisHeatDetailsUserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TIBEvent> Event { get; set; }

        public TibUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets a TIB Event using the entity helper and logs
        /// any errors.
        /// </summary>
        protected override string GetData()
        {
            tibDelayDetailGrid.SetupUserControl(this.heatNumber, this.heatNumberSet);
            return String.Empty;
        }

        protected override void ShowMainPanel()
        {
            ShowMainPanel(main);
        }

        protected override void PopulateForm()
        {
            tibDelayDetailGrid.ShowData();
        }
    }
}
