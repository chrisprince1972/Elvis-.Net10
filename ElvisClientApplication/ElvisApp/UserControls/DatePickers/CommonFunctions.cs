using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Elvis.Common;

namespace Elvis.UserControls.DatePickers
{
    public static class CommonFunctions
    {
        public static void SetupWeekNoControl(NumericUpDown numWeek, int year)
        {
            if (DateTimeExtensions.IsWeek53Valid(year))
                numWeek.Maximum = 53;
            else
                numWeek.Maximum = 52;
        }

        public static void SetupYearControl(NumericUpDown numYear)
        {
            numYear.Maximum = DateTime.Now.Year;
            numYear.Minimum = DateTime.Now.Year - 5;
            numYear.Value = DateTime.Now.Year;
        }

        public static void AddUserControlToGroupBox(GroupBox grpBoxParent, 
            UserControl ucToAdd, Padding padding)
        {
            grpBoxParent.Controls.Clear();
            grpBoxParent.Controls.Add(ucToAdd);
            grpBoxParent.Padding = padding;
            ucToAdd.Dock = DockStyle.Top;
        }
    }
}
