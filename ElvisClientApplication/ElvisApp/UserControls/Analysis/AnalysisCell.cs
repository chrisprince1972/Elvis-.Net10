using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Elvis.UserControls.Analysis
{
    class AnalysisCell
    {
        #region Attributes
        private int rowIndex;
        private string columnName;
        private double value;
        private double maxValue;
        private double minValue;
        private double aimValue;
        private int decimalPlaces;
        private Color backColour;
        private Color foreColour;
        #endregion

        #region Constructor
        public AnalysisCell(int rowIndex, 
                            string columnName, 
                            double value, 
                            double maxValue, 
                            double minValue, 
                            double aimValue, 
                            int decimalPlaces)
        {
            this.rowIndex = rowIndex;
            this.columnName = columnName;
            this.value = Math.Round(value, decimalPlaces);
            this.maxValue = maxValue;
            this.minValue = minValue;
            this.aimValue = aimValue;
            this.decimalPlaces = decimalPlaces;
        }
        #endregion

        #region Properties
        public int RowIndex 
        {
            get { return this.rowIndex; } 
        }
        public string ColumnName
        {
            get { return this.columnName; }
        }
        public double Value
        {
            get { return this.value; }
        }
        public double MaxValue
        {
            get { return this.maxValue; }
        }
        public double MinValue
        {
            get { return this.minValue; }
        }
        public double AimValue
        {
            get { return this.aimValue; }
        }
        public int DecimalPlaces
        {
            get { return this.decimalPlaces; }
        }
        public Color BackColour
        {
            get { return this.backColour; }
        }
        public Color ForeColour
        {
            get { return this.foreColour; }
        }
        #endregion
    }
}
