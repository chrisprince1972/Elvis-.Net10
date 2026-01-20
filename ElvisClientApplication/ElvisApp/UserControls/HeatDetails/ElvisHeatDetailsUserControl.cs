using Elvis.Properties;

namespace Elvis.UserControls.HeatDetails
{
    public class ElvisHeatDetailsUserControl : Elvis.UserControls.Generic.ElvisUserControl
    {
        protected int heatNumberSet = 0;
        protected int heatNumber = 0;

        /// <summary>
        /// Entry point of the object.  This is what the client code calls to put the values into the control.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        public void SetHeatDetails(int heatNumber, int heatNumberSet)
        {
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;
            base.SetupUserControl(Resources.loading);
        }

        /// <summary>
        /// Entry point of the object.  This is what the client code calls to 
        /// put the values into the control when they want to display the data.
        /// </summary>
        /// <param name="heatNumberSet">Uniquely identify a heat.</param>
        /// <param name="heatNumber">Uniquely identify a heat.</param>
        public virtual void SetupUserControl(int heatNumber, int heatNumberSet)
        {
            SetHeatDetails(heatNumber, heatNumberSet);
        }
    }
}
