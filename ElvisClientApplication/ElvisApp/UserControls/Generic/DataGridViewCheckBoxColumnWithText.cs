using System.Drawing;
using System.Windows.Forms;

namespace Elvis.UserControls.Generic
{

    public class DataGridViewCheckBoxColumnWithText : DataGridViewCheckBoxColumn
    {
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return new DataGridViewCheckBoxCellWithText();
            }
        }
    }
    public class DataGridViewCheckBoxCellWithText : DataGridViewCheckBoxCell
    {
        public string Text { get; set; }

        public DataGridViewCheckBoxCellWithText(){}
        public DataGridViewCheckBoxCellWithText(string text)
        {
            this.Text = text;
        }

        protected override void Paint(
            Graphics graphics, 
            Rectangle clipBounds, 
            Rectangle cellBounds, 
            int rowIndex, 
            DataGridViewElementStates elementState, 
            object value, 
            object formattedValue, 
            string errorText, 
            DataGridViewCellStyle cellStyle, 
            DataGridViewAdvancedBorderStyle advancedBorderStyle, 
            DataGridViewPaintParts paintParts)
        {
            // the base Paint implementation paints the check box
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            // now let's paint the text
            // Get the check box bounds: they are the content bounds
            System.Drawing.Rectangle contentBounds = this.GetContentBounds(rowIndex);
            // Compute the location where we want to paint the string.
            Point stringLocation = new Point();
            // Compute the Y.
            // NOTE: the current logic does not take into account padding.
            stringLocation.Y = cellBounds.Y + 2;
            // Compute the X.
            // Content bounds are computed relative to the cell bounds
            // - not relative to the DataGridView control.
            stringLocation.X = cellBounds.X + contentBounds.Right + 2;
            // Paint the string.
            graphics.DrawString(Text, Control.DefaultFont, System.Drawing.Brushes.Red, stringLocation);
        }
    }
}
