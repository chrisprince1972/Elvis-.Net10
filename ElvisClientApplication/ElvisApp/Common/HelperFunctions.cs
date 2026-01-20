using BusinessLogic.Models.ViewModels;
using Elvis.Properties;
using ElvisDataModel.EDMX;
using NLog;
using System;
using System.Collections.Generic;
//using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Elvis.Common
{
    public static class HelperFunctions
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets a string from an object if the object is not null
        /// </summary>
        /// <param name="value">Object to convert to string.</param>
        /// <returns>Value returned as string.</returns>
        public static string GetStringFromObjectSafely(object value)
        {
            if (value == null)
                return "";
            else
                return value.ToString();
        }

        /// <summary>
        /// Gets a string from a nullable float safely.
        /// </summary>
        /// <param name="value">The nullable float value to check.</param>
        /// <returns>A string representing the float. Empty string if null.</returns>
        public static string GetStringFromNullableFloat(float? value)
        {
            if (value.HasValue)
                return value.Value.ToString();
            return "";
        }

        /// <summary>
        /// Gets an Int Safely from an object.
        /// </summary>
        /// <param name="value">The Object to pass in.</param>
        /// <returns>The object as an int or 0 if failed.</returns>
        public static int GetIntSafely(object value)
        {
            try
            {
                if (value != null)
                {
                    int intValue = 0;
                    double doubleValue = 0;
                    //Check if value is an int
                    if (int.TryParse(value.ToString(), out intValue))
                    {
                        return intValue;
                    }
                    //Value could be a double
                    if (double.TryParse(value.ToString(), out doubleValue))
                    {
                        return Convert.ToInt32(Math.Round(doubleValue, 0));
                    }
                }
            }
            catch
            {
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// Gets an Int Safely from an object, if 0 then it returns null.
        /// </summary>
        /// <param name="value">The Object to pass in.</param>
        /// <returns>The object as an int or null if failed/zero value.</returns>
        public static int? GetIntOrNullSafely(object value)
        {
            try
            {
                if (value != null)
                {
                    int intValue = 0;
                    double doubleValue = 0;
                    //Check if value is an int
                    if (int.TryParse(value.ToString(), out intValue))
                    {
                        if (intValue == 0)
                        {
                            return null;
                        }
                        return intValue;
                    }
                    //Value could be a double
                    if (double.TryParse(value.ToString(), out doubleValue))
                    {
                        if (doubleValue == 0)
                        {
                            return null;
                        }
                        return Convert.ToInt32(Math.Round(doubleValue, 0));
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// Gets a Double Safely from an object.
        /// </summary>
        /// <param name="value">The Object to pass in.</param>
        /// <returns>The object as a double or 0 if failed.</returns>
        public static double GetDoubleSafely(object value)
        {
            try
            {
                if (value != null)
                {
                    double doubleValue = 0;
                    //Check if value can convert to double
                    if (double.TryParse(value.ToString(), out doubleValue))
                    {
                        return doubleValue;
                    }
                }
            }
            catch
            {
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// Safely converts a float to a decimal.
        /// </summary>
        /// <param name="floatValue">The float value to convert.</param>
        /// <returns>A decimal value.</returns>
        public static decimal GetDecimalFromFloat(float floatValue)
        {
            decimal decValue = 0;

            if (decimal.TryParse(floatValue.ToString(), out decValue))
            {
                return decValue;
            }
            return 0;
        }

        /// <summary>
        /// Safely converts a decimal to an int.
        /// </summary>
        /// <param name="decimalValue">The decimal value to convert.</param>
        /// <returns>An int value.</returns>
        public static int GetIntFromDecimal(decimal decimalValue)
        {
            int intValue = 0;

            if (int.TryParse(decimalValue.ToString(), out intValue))
            {
                return intValue;
            }
            return 0;
        }

        /// <summary>
        /// Safely converts a decimal to a float.
        /// </summary>
        /// <param name="decimalValue">The decimal value to convert.</param>
        /// <returns>A float value.</returns>
        public static float GetFloatFromDecimal(decimal decimalValue)
        {
            float floatValue = 0;

            if (float.TryParse(decimalValue.ToString(), out floatValue))
            {
                return floatValue;
            }
            return 0;
        }

        /// <summary>
        /// Gets Version Number of Published App
        ///  Will use the assembly version if not network deployed.
        /// </summary>
        /// <returns>Version Number as String</returns>
        //TODO:changed on conversion needs to work when deployed
        public static string GetVersionNumber()
        {
            return Assembly
                .GetEntryAssembly()?
                .GetName()
                .Version?
                .ToString()
                ?? "Unknown";
        }

        /// <summary>
        /// Gets actual TibDuration.  Database value is unreliable.
        /// </summary>
        /// <param name="start">Start Date Time</param>
        /// <param name="end">End Date Time</param>
        /// <returns>Duration in minutes as nullable Int</returns>
        public static int? GetDuration(DateTime? start, DateTime? end)
        {
            if (start.HasValue && end.HasValue)
                return Convert.ToInt32((end.Value - start.Value).TotalMinutes);
            return null;
        }

        /// <summary>
        /// Remove any delays or partial delays that occurred out of 
        /// the report times boundaries (i.e. in another shift)
        /// </summary>
        /// <param name="delayData">The List of Delay Data to interrogate</param>
        /// <param name="dateFrom">The Starting date of the report.</param>
        /// <param name="dateTo">The End date of the report.</param>
        public static void RemoveInvalidDelayData(List<TibReportsView> delayData,
            DateTime dateFrom, DateTime dateTo)
        {
            if (delayData != null)
            {
                //1st remove any delays that started and ended before the report start date
                //This is because they could have been part of an event 
                //that started before the report start and finished after the report start.
                delayData.RemoveAll(d => d.DelayStart < dateFrom && d.DelayEnd <= dateFrom);
                //2nd remove any delays that started after the report end date
                //This is because they could have been part of an event --
                //that ended after the report date end.
                delayData.RemoveAll(d => d.DelayStart > dateTo);

                //Ammend any delay record durations that crossed over the report start date!
                var delays = delayData.Where
                    (d => d.DelayStart < dateFrom);
                foreach (var d in delays)
                {
                    d.DelayStart = dateFrom;
                    d.DelayDuration = GetDuration(d.DelayStart, d.DelayEnd);
                }

                //Ammend any delay record durations that crossed over the report end date!
                delays = delayData.Where
                    (d => d.DelayStart > dateFrom && d.DelayStart <= dateTo
                        && d.DelayEnd > dateTo);
                foreach (var d in delays)
                {
                    //2015-10-27 Les Jones - modification so that dateTo ends at 6:59, not 7.
                    dateTo = dateTo.AddMinutes(-1);
                    d.DelayEnd = dateTo;
                    d.DelayDuration = GetDuration(d.DelayStart, d.DelayEnd);
                }
            }
        }

        /// <summary>
        /// Remove any events or partial events that occurred out of 
        /// the report times boundaries (i.e. in another shift)
        /// </summary>
        /// <param name="delayData">The List of Event Data to interrogate</param>
        /// <param name="dateFrom">The Starting date of the report.</param>
        /// <param name="dateTo">The End date of the report.</param>
        public static void RemoveInvalidEventData(List<TibTimeInProductionView> eventData,
            DateTime dateFrom, DateTime dateTo)
        {
            if (eventData != null)
            {
                //1st remove any delays that started and ended before the report start date
                //This is because they could have been part of an event 
                //that started before the report start and finished after the report start.
                eventData.RemoveAll(d => d.EventStart < dateFrom && d.EventEnd <= dateFrom);
                //2nd remove any delays that started after the report end date
                //This is because they could have been part of an event --
                //that ended after the report date end.
                eventData.RemoveAll(d => d.EventStart > dateTo);

                //Ammend any delay record durations that crossed over the report start date!
                var events = eventData.Where
                    (d => d.EventStart < dateFrom);
                foreach (var d in events)
                {
                    d.EventStart = dateFrom;
                    d.TibDuration = GetDuration(d.EventStart, d.EventEnd);
                }

                //Ammend any delay record durations that crossed over the report end date!
                events = eventData.Where
                    (d => d.EventStart > dateFrom && d.EventStart <= dateTo
                        && d.EventEnd > dateTo);
                foreach (var d in events)
                {
                    d.EventEnd = dateTo;
                    d.TibDuration = GetDuration(d.EventStart, d.EventEnd);
                }
            }
        }

        /// <summary>
        /// Remove any events or partial events that occurred out of 
        /// the report times boundaries (i.e. in another shift)
        /// </summary>
        /// <param name="delayData">The List of Event Data to interrogate</param>
        /// <param name="dateFrom">The Starting date of the report.</param>
        /// <param name="dateTo">The End date of the report.</param>
        public static void RemoveInvalidDelayData(List<TibOEEReport> delayData,
            DateTime dateFrom, DateTime dateTo)
        {
            if (delayData != null)
            {
                //1st remove any delays that started and ended before the report start date
                //This is because they could have been part of an event 
                //that started before the report start and finished after the report start.
                delayData.RemoveAll(d => d.DelayStart < dateFrom && d.DelayEnd <= dateFrom);
                //2nd remove any delays that started after the report end date
                //This is because they could have been part of an event --
                //that ended after the report date end.
                delayData.RemoveAll(d => d.DelayStart > dateTo);

                //Ammend any delay record durations that crossed over the report start date!
                var events = delayData.Where
                    (d => d.DelayStart < dateFrom);
                foreach (var d in events)
                {
                    d.DelayStart = dateFrom;
                    d.DelayDuration = GetDuration(d.DelayStart, d.DelayEnd);
                }

                //Ammend any delay record durations that crossed over the report end date!
                events = delayData.Where
                    (d => d.DelayStart > dateFrom && d.DelayStart <= dateTo
                        && d.DelayEnd > dateTo);
                foreach (var d in events)
                {
                    //2015-10-27 Les Jones - modification so that dateTo ends at 6:59, not 7.
                    dateTo = dateTo.AddMinutes(-1);
                    d.DelayEnd = dateTo;
                    d.DelayDuration = GetDuration(d.DelayStart, d.DelayEnd);
                }
            }
        }

        /// <summary>
        /// Method that verifies the filters selected by the user.
        /// Check for DateFrom being greater than now.
        /// Check for DateFrom being greater than or equals to DateTo.
        /// Check for Date Span larger than 60 days.
        /// </summary>
        /// <param name="dateFrom">The Date From.</param>
        /// <param name="dateTo">The Date To.</param>
        /// <returns>True or False depending on verification.</returns>
        public static bool VerifyFilterSelections(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > DateTime.Now)
            {
                MessageBox.Show(
                    "From date cannot be in the future.",
                    "Date Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return false;
            }

            if (dateFrom.Date >= dateTo.Date)
            {
                MessageBox.Show(
                    "From date must be before To date.",
                    "Date Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the Location from the Unit Number
        /// </summary>
        /// <param name="unitNo">The Unit Number.</param>
        /// <returns>A string with the location name associated with that unit number.</returns>
        public static string GetLocationFromUnitNo(int unitNo)
        {
            switch (unitNo)
            {
                case 1://HotMetalNorth
                case 2://HotMetalSouth
                    return "HM Pour";
                case 3://DesulphNorth
                    return "Other Unit";
                case 4://DesulphSouth
                    return "HM De-S";
                case 5://Vessel1
                    return "Converter 1";
                case 6://Vessel2
                    return "Converter 2";
                case 7://RH
                    return "RH";
                case 8://RD
                    return "RD";
                case 9://CAS1
                    return "Cas 1";
                case 10://CAS2
                    return "Cas 2";
                case 11://CC1
                    return "CC1";
                case 12://CC2
                    return "CC2";
                case 13://CC3
                    return "CC3";
                case 14://LimePlant
                    return "Lime Plant";
                case 15://SteelLadle
                    return "Other Unit";
                case 16://ScrapNorth
                case 17://ScrapSouth
                    return "Scrap";
                default:
                    return "Other Unit";
            }
        }

        /// <summary>
        /// Gets the font size in pixels of the given text and font.
        /// </summary>
        /// <param name="text">The text you wish to check.</param>
        /// <param name="font">The font of the text you wish to check (Different fonts give different sizes).</param>
        /// <returns>A SizeF object containing the information.</returns>
        public static SizeF GetFontSizeInPixels(string text, Font font)
        {
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                return graphics.MeasureString(text, font);
            }
        }
        
        // seemed to be more accurate than above but use with caution.
        public static Size GetFontSizeInPixels(Control c, Font font)
        {
            using (Graphics graphics = c.CreateGraphics())
            {
                Label l = c as Label;
                Panel p = new Panel();
                Button newLabel = new Button();
                newLabel.Text = l.Text;
                newLabel.Font = l.Font;
                newLabel.Size = new Size(0, 0);
                newLabel.AutoSize = true;
                newLabel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                newLabel.AutoEllipsis = false;
                p.Controls.Add(newLabel);

                return newLabel.Size;
            }
        }

        /// <summary>
        /// Places the form into fullscreen mode or takes it out of fullscreen mode.
        /// </summary>
        /// <param name="fullscreen">True for fullscreen, false for normal.</param>
        /// <param name="form">The Form you wish to change.</param>
        public static void GoFullscreen(bool fullscreen, Form form)
        {
            if (fullscreen)
            {
                form.WindowState = FormWindowState.Normal;
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                form.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Finds all of the controls of a certain type within a control or form.
        /// </summary>
        /// <param name="control">The control you wish to search.  
        /// You can use the current form to search everything.</param>
        /// <param name="type">The type of controls you are looking for.</param>
        /// <returns>A list of the controls within.</returns>
        public static List<Control> GetControlList(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetControlList(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type)
                                      .ToList();
        }

        /// <summary>
        /// Resizes an Image to fit the page for printing.
        /// </summary>
        /// <param name="rect">The Rectangle that contains the boundaries.</param>
        /// <param name="image">The image to check.</param>
        /// <returns>A new Rectangle with better aspect ratio if needed.</returns>
        public static Rectangle ResizeAndMaintainAspectRatio(Rectangle rect, Bitmap image)
        {
            if ((double)image.Width / (double)image.Height > (double)rect.Width / (double)rect.Height)
            {//Image is wider
                rect.Height = (int)((double)image.Height / (double)image.Width * (double)rect.Width);
            }
            else
            {
                rect.Width = (int)((double)image.Width / (double)image.Height * (double)rect.Height);
            }
            return rect;
        }

        /// <summary>
        /// Converts Bytes into Megabytes.
        /// </summary>
        /// <param name="bytes">Bytes as a long.</param>
        /// <returns>Mega bytes</returns>
        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        /// <summary>
        /// Gets the Abbreviated version of a miscast from the miscast type.
        /// Divert - S
        /// Not Set - Blank
        /// Downgrade - D
        /// Referal - R
        /// Wide Limits - W
        /// </summary>
        /// <param name="miscastType">The miscast type.</param>
        /// <returns>A letter abbreviating the miscast type.</returns>
        public static string GetMiscastShort(string miscastType)
        {
            switch (miscastType)
            {
                case "Divert":
                    return "S";
                case "Downgrade":
                    return "D";
                case "Referal":
                    return "R";
                case "Wide Limits":
                    return "W";
                default://Not Set or Unknown
                    return "";
            }
        }

        //make elvis settings more portable so that they can be used by 
        // external projects.
        public static ElvisSettings GetElvisSettings()
        {
            return new ElvisSettings(
                colourDashGoodBackground: Settings.Default.ColourDashGoodBack,
                colourDashGoodText: Settings.Default.ColourDashGoodText,
                colourDashBadBackground: Settings.Default.ColourDashBadBack,
                colourDashBadText: Settings.Default.ColourDashBadText,
                colourDashMissingBackground: Settings.Default.ColourDashMissingBack,
                colourDashMissingText: Settings.Default.ColourDashMissingText,
                colourDashRowBackground: Settings.Default.ColourDashRowBack,
                colourDashRowText: Settings.Default.ColourDashRowText,
                colourDashAltRowBackground: Settings.Default.ColourDashAltRowBack,
                colourDashAltRowText: Settings.Default.ColourDashAltRowText);
        }
    }
}
