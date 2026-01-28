using System;
using System.Drawing;
using System.Windows.Forms;
using Elvis.Model;
using Elvis.Properties;
using ElvisDataModel.EDMX;

namespace Elvis.Common
{
    public static class Colours
    {
        /// <summary>
        /// Gets the colour settings for each caster
        /// </summary>
        /// <param name="caster">A short description of caster e.g. CC1</param>
        /// <param name="isPlanning">Whether or not event is planning</param>
        /// <returns>Color</returns>
        public static Color GetColourByCaster(string caster, bool isPlanning, int programNo = 0)
        {
            switch (caster)
            {
                case "CC1":
                    if (isPlanning) return Settings.Default.ColourCaster1Plan;//Planning
                    else return Settings.Default.ColourCaster1;//Normal - Yellow
                case "CC2":
                    if (isPlanning) return Settings.Default.ColourCaster2Plan;//Planning Light Purple
                    else return Settings.Default.ColourCaster2;//Normal Purple
                case "CC3":
                    if (isPlanning) return Settings.Default.ColourCaster3Plan;//Planning Light Blue
                    else return Settings.Default.ColourCaster3;//Normal Blue
                default:
                    return GetColourByProgramNo(isPlanning, programNo);
            }
        }

        /// <summary>
        /// Gets the colour settings for each vessel
        /// </summary>
        /// <param name="caster">A short description of caster e.g. CC1</param>
        /// <param name="isPlanning">Whether or not event is planning</param>
        /// <returns>Color</returns>
        public static Color GetColourByVessel(int vessel, bool isPlanning)
        {
            switch (vessel)
            {
                case 1:
                    if (isPlanning) return Settings.Default.ColourVessel1Plan;//Planning
                    else return Settings.Default.ColourVessel1;//Normal
                case 2:
                    if (isPlanning) return Settings.Default.ColourVessel2Plan;//Planning
                    else return Settings.Default.ColourVessel2;//Normal
                default:
                    return Color.Gray;
            }
        }

        /// <summary>
        /// Gets the colour settings if caster name isn't available but program number is
        /// Just loops and gives the GetColourByCaster method a caster name.
        /// </summary>
        /// <param name="isPlanning">Bool whether or not event is planning</param>
        /// <param name="programNo">The Program Number</param>
        /// <returns>Color</returns>
        private static Color GetColourByProgramNo(bool isPlanning, int programNo)
        {
            if (programNo == 0)
                return Color.DarkGray;
            else if (programNo >= 600)
                return GetColourByCaster("CC3", isPlanning);
            else if (programNo < 300)
                return GetColourByCaster("CC1", isPlanning);
            else
                return GetColourByCaster("CC2", isPlanning);
        }

        /// <summary>
        /// Alternates the back colour for resources on the schedulers.
        /// </summary>
        /// <param name="backColour">The old Back Colour</param>
        /// <returns>A Colour.</returns>
        public static Color AlternateBackColour(Color backColour)
        {
            if (backColour == Settings.Default.ColourHeatScheduler1)
                return Settings.Default.ColourHeatScheduler2;
            return Settings.Default.ColourHeatScheduler1;
        }

        /// <summary>
        /// Gets the colour for the CBM Overview Table
        /// </summary>
        /// <param name="type">The Type of Cell e.g. Calculated, Constrained etc. Leave Blank for default</param>
        /// <param name="isForeColour">True for ForeColour, False for Background</param>
        /// <returns>Color</returns>
        public static Color GetCBMOverviewCellColour(CBMType type, bool isForeColour)
        {
            if (isForeColour) //Fore Colour
            {
                if (Settings.Default.CBMColourScheme.Equals("High Contrast")) //High Contrast
                {
                    switch (type)
                    {
                        case CBMType.Actual:
                        case CBMType.DesulphHM:
                            return Color.LimeGreen;
                        case CBMType.Calculated:
                            return Color.WhiteSmoke;
                        case CBMType.Constrained:
                            return Color.Red;
                        case CBMType.PouredHM:
                        case CBMType.Prepared:
                            return Color.DarkOrange;
                        default:
                            return ColorTranslator.FromHtml("#F6DA00");//Yellow
                    }
                }
                else //Default
                {
                    switch (type)
                    {
                        case CBMType.Actual:
                        case CBMType.DesulphHM:
                            return Color.Green;
                        case CBMType.Calculated:
                            return Color.Black;
                        case CBMType.Constrained:
                            return Color.Red;
                        case CBMType.PouredHM:
                        case CBMType.Prepared:
                            return Color.DarkOrange;
                        default:
                            return Color.Black;
                    }
                }
            }
            else//Background Colour
            {
                if (Settings.Default.CBMColourScheme.Equals("High Contrast"))
                {
                    return Color.Black;
                }
                else
                {
                    return Color.White;
                }
            }
        }

        /// <summary>
        /// Gets the colour for the CBM Analysis Tables
        /// </summary>
        /// <param name="type">The Type of Cell e.g. Title, value.</param>
        /// <param name="isForeColour">True for ForeColour, False for Background</param>
        /// <returns>Color</returns>
        public static Color GetCBMAnalysisCellColour(string type, bool isForeColour)
        {
            if (isForeColour) //Fore Colour
            {
                if (Settings.Default.CBMColourScheme.Equals("High Contrast")) //High Contrast
                {
                    switch (type)
                    {
                        case "Title":
                            return ColorTranslator.FromHtml("#F6DA00");//Yellow
                        default:
                            return Color.White;
                    }
                }
                else //Default
                {
                    return Color.Black;
                }
            }
            else//Background Colour
            {
                if (Settings.Default.CBMColourScheme.Equals("High Contrast"))
                {
                    return Color.Black;
                }
                else
                {
                    return Color.White;
                }
            }
        }

        /// <summary>
        /// Gets the colour for the Analysis Tables
        /// </summary>
        /// <param name="type">The Type of Cell e.g. AboveMax, Aim, BelowMin, MaxMin. Leave Blank for default</param>
        /// <param name="isForeColour">True for ForeColour, False for Background</param>
        /// <returns>Color</returns>
        public static Color GetAnalysisCellColour(string type, bool isForeColour)
        {
            if (isForeColour)
            {
                if (Settings.Default.TableTheme == "High Contrast")
                {
                    switch (type)
                    {
                        case "Text":
                        case "AboveMax":
                        case "Aim":
                            return ColorTranslator.FromHtml("#FFFFFF");//White
                        case "BelowMin":
                            return ColorTranslator.FromHtml("#00FFFF");//Light Blue
                        case "MaxMin":
                            return ColorTranslator.FromHtml("#FFFF00");//Yellow
                        default:
                            return ColorTranslator.FromHtml("#00FF00");//Green
                    }
                }
                else
                {
                    switch (type)
                    {
                        case "AboveMax":
                        case "BelowMin":
                            return ColorTranslator.FromHtml("#FF0000");//Red
                        case "Aim":
                        case "MaxMin":
                        default:
                            return ColorTranslator.FromHtml("#000000");//Black
                    }
                }
            }
            else//Background Colour
            {
                if (Settings.Default.TableTheme == "High Contrast")
                {
                    if (type == "AboveMax")
                        return ColorTranslator.FromHtml("#FF0000");//Red
                    else
                        return ColorTranslator.FromHtml("#000000");//Black
                }
                else
                {
                    return ColorTranslator.FromHtml("#FFFFFF");//White
                }
            }
        }

        /// <summary>
        /// Gets the colour for the Analysis Tables
        /// </summary>
        /// <param name="backColour">The back colour of the object</param>
        /// <returns>SolidBrush</returns>
        public static SolidBrush GetAppointmentTextColour(Color backColour)
        {
            switch (ColorTranslator.ToHtml(backColour))
            {
                case "#122EFF"://Blue
                case "#CC00FF"://Purple
                case "Gray":
                    return new SolidBrush(ColorTranslator.FromHtml("#FFFFFF"));
                default:
                    return new SolidBrush(ColorTranslator.FromHtml("#000000"));
            }
        }

        /// <summary>
        /// Sets Data Gridview to either default colour scheme or high contrast
        /// </summary>
        /// <param name="dgv">Data Gridview to change</param>
        public static void FormatGridview(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultTableHeaderBackground;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultTableHeaderForeColor;
            dgv.DefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultTableCellBackground;
            dgv.DefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultTableCellForeColor;
            dgv.RowsDefaultCellStyle.SelectionBackColor =
                Common.DefaultSettings.DefaultTableCellHighlight;
            dgv.RowsDefaultCellStyle.SelectionForeColor =
                Common.DefaultSettings.DefaultTableCellHighlightText;
        }

        /// <summary>
        /// Sets Data Gridview to either default colour scheme or high contrast
        /// </summary>
        /// <param name="dgv">Data Gridview to change</param>
        public static void FormatCBMGridview(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultCBMTableHeaderBackground;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultCBMTableHeaderForeColor;
            dgv.DefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultCBMTableCellBackground;
            dgv.DefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultCBMTableCellForeColor;
            dgv.RowsDefaultCellStyle.SelectionBackColor =
                Common.DefaultSettings.DefaultCBMTableCellHighlight;
            dgv.RowsDefaultCellStyle.SelectionForeColor =
                Common.DefaultSettings.DefaultCBMTableCellHighlightText;
        }

        /// <summary>
        /// Gets the current Highlight Colour Setting
        /// </summary>
        /// <returns>A Color Object.</returns>
        public static Color GetHighlightColour()
        {
            return Settings.Default.ColourHighlight;
        }

        /// <summary>
        /// Gets the relevant Tib Delay/Event Colour.
        /// </summary>
        /// <returns>A Color Object.</returns>
        public static Color GetTibEventColour(int? tibStatus, int? unitNo, int? programNo)
        {
            if (unitNo.HasValue && unitNo.Value == 14 &&
                tibStatus.HasValue && tibStatus.Value != 2)
            {//Limeplant changeover event.
                return Settings.Default.LimePlantChangeOverColour;
            }
            switch (tibStatus)
            {
                case 2://Producing
                    {
                        if (unitNo == 14)//LimePlant Production Event
                            return Settings.Default.LimePlantEventColour;

                        string caster = "";

                        if (unitNo == 11)
                            caster = "CC1";
                        else if (unitNo == 12)
                            caster = "CC2";
                        else if (unitNo == 13)
                            caster = "CC3";

                        if (programNo.HasValue)
                            return GetColourByCaster(caster, false, programNo.Value);
                        else
                            return GetColourByCaster(caster, false);
                    }
                default://All other event types
                    return Settings.Default.TibNoReason;
            }
        }

        /// <summary>
        /// Gets colour for a TIB Delay.
        /// </summary>
        /// <param name="area">The area that dictates the colour, leave blank for "No Reason"</param>
        /// <returns>The Colour</returns>
        public static Color GetTibDelayColour(string area)
        {
            switch (area.Trim().ToUpper())
            {
                case "EXTERNAL":
                    return Settings.Default.TibExternal;
                case "MULTISERV":
                    return Settings.Default.TibMultiServ;
                case "HM & SCRAP":
                    return Settings.Default.TibHMScrap;
                case "VESSELS":
                    return Settings.Default.TibVessels;
                case "PLAN":
                    return Settings.Default.TibPlan;
                case "SEC-STEEL":
                    return Settings.Default.TibSecSteel;
                case "CASTERS":
                    return Settings.Default.TibCasters;
                case "CRANES":
                    return Settings.Default.TibCranes;
                default:
                    return Settings.Default.TibNoReason;
            }
        }

        /// <summary>
        /// Gets fore-colour (text) for a TIB Delay.
        /// </summary>
        /// <param name="area">The area that dictates the colour, leave blank for "No Reason"</param>
        /// <returns>The Colour</returns>
        public static Color GetTibDelayForeColour(string area)
        {
            switch (area.Trim().ToUpper())
            {
                case "EXTERNAL":
                    return Settings.Default.TibExternalText;
                case "MULTISERV":
                    return Settings.Default.TibMultiServText;
                case "HM & SCRAP":
                    return Settings.Default.TibHMScrapText;
                case "VESSELS":
                    return Settings.Default.TibVesselsText;
                case "PLAN":
                    return Settings.Default.TibPlanText;
                case "SEC-STEEL":
                    return Settings.Default.TibSecSteelText;
                case "CASTERS":
                    return Settings.Default.TibCastersText;
                case "CRANES":
                    return Settings.Default.TibCranesText;
                default:
                    return Settings.Default.TibNoReasonText;
            }
        }

        /// <summary>
        /// Gets the back colour for planned slow casting.
        /// </summary>
        /// <returns>The Colour as a Color object</returns>
        public static Color GetSlowCastBackColour()
        {
            return Settings.Default.SlowCastColour;
        }

        ///<summary>
        ///Converts a given colour to a hex based string value. Used for some colour changes on RDLC reports
        ///</summary>
        ///<param name="colourToConvert">The System>drawing.Color value to be converted.</param>
        ///<returns>The colour as a hex string</returns>
        public static string ConvertSystemColourToHex(Color colourToConvert)
        {
            return "#" +
                colourToConvert.R.ToString("X2") +
                colourToConvert.G.ToString("X2") +
                colourToConvert.B.ToString("X2");
        }

        /// <summary>
        /// Sets Chart to either default colour scheme or high contrast
        /// </summary>
        /// <param name="dgv">The DataGridview to format.</param>
        public static void FormatEBMGridview(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultEBMTableHeaderBackground;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultEBMTableHeaderForeColor;
            dgv.DefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultEBMTableCellBackground;
            dgv.DefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultEBMTableCellForeColor;
            dgv.RowsDefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultEBMTableCellBackground;
            dgv.RowsDefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultEBMTableCellForeColor;
            dgv.RowTemplate.DefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultEBMTableCellBackground;
            dgv.RowTemplate.DefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultEBMTableCellForeColor;
            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Common.DefaultSettings.DefaultEBMTableAlternateRow;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor =
                Common.DefaultSettings.DefaultEBMTableAlternateRowText;
            dgv.Refresh();
        }

        /// <summary>
        /// Gets the caster trend tag colour for a specific description.
        /// e.g. N Tundish Temp, S1 Speed, S1 Immersion
        /// These tag descriptions can be found in CasterTrend.cs
        /// </summary>
        /// <param name="tagDescription">The description of the tag.</param>
        /// <returns>A Color object for the requested tag description.</returns>
        public static Color GetCasterTrendTagColour(string tagDescription)
        {
            switch (tagDescription)
            {
                case "N Tundish Temp":
                    return DefaultSettings.NTundishTemp;
                case "S Tundish Temp":
                    return DefaultSettings.STundishTemp;
                case "Tundish Weight":
                    return DefaultSettings.TundishWeight;
                case "Ladle Weight":
                    return DefaultSettings.LadleWeight;
                case "S1 Speed":
                    return DefaultSettings.S1Speed;
                case "S2 Speed":
                    return DefaultSettings.S2Speed;
                case "S1 Mould Lvl":
                    return DefaultSettings.S1MouldLvl;
                case "S2 Mould Lvl":
                    return DefaultSettings.S2MouldLvl;
                case "S1 Stopper Pos":
                    return DefaultSettings.S1StopperPos;
                case "S2 Stopper Pos":
                    return DefaultSettings.S2StopperPos;
                case "S1 Slab Width":
                    return DefaultSettings.S1SlabWidth;
                case "S2 Slab Width":
                    return DefaultSettings.S2SlabWidth;
                case "S1 Auto":
                    return DefaultSettings.S1Auto;
                case "S2 Auto":
                    return DefaultSettings.S2Auto;
                case "S1 Immersion":
                    return DefaultSettings.S1Immersion;
                case "S2 Immersion":
                    return DefaultSettings.S2Immersion;
                case "NTC in Position":
                    return DefaultSettings.NTCinPosition;
                case "STC in Position":
                    return DefaultSettings.STCinPosition;
                default:
                    return Color.Black;
            }
        }

        /// <summary>
        /// Gets the Trend Series Colour by highlight type 
        /// and series name.
        /// </summary>
        /// <param name="highlightType">The Highlight Type.</param>
        /// <param name="highlightName">The Name of the Highlight Requirement 
        ///     e.g. Data1, Data2, Data3, Data4 or A Rota, B Rota, C Rota etc.</param>
        /// <returns>A colour associated with that Trend Series.</returns>
        public static Color GetTrendHighlightColour(string highlightName)
        {
            switch (highlightName)
            {
                case "Data1":
                case "A Rota":
                case "Hot Metal North":
                case "Desulph North":
                case "Vessel 1":
                case "CAS 1":
                case "Caster 1":
                    return Settings.Default.ColourHighlight1;
                case "Data2":
                case "B Rota":
                case "Hot Metal South":
                case "Desulph South":
                case "Vessel 2":
                case "CAS 2":
                case "Caster 2":
                    return Settings.Default.ColourHighlight2;
                case "Data3":
                case "C Rota":
                case "Caster 3":
                case "RH Degasser":
                    return Settings.Default.ColourHighlight3;
                case "Data4":
                case "D Rota":
                case "RD Degasser":
                    return Settings.Default.ColourHighlight4;
                default:
                    return Color.LightBlue;
            }
        }

        /// <summary>
        /// Gets the Back Colour for the KPI rows on the Dashboards.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        /// <returns>A Color object.</returns>
        public static Color GetKPIBackColour(KPIConfig config)
        {
            if (config != null &&
                config.KPILevel.HasValue)
            {
                int kpiNo = Convert.ToInt16(config.KPILevel.Value);
                if (kpiNo % 2 != 0)//If odd
                    return Settings.Default.ColourDashRowBack;
                return Settings.Default.ColourDashAltRowBack;//Evens
            }
            return Color.Transparent;//Default
        }

        /// <summary>
        /// Gets the Text Colour for the KPI rows on the Dashboards.
        /// </summary>
        /// <param name="config">The KPI Config.</param>
        /// <returns>A Color object.</returns>
        public static Color GetKPITextColour(ElvisDataModel.EDMX.KPIConfig config)
        {
            if (config != null &&
                config.KPILevel.HasValue)
            {
                int kpiNo = Convert.ToInt16(config.KPILevel.Value);
                if (kpiNo % 2 != 0)//If odd
                    return Settings.Default.ColourDashRowText;
                return Settings.Default.ColourDashAltRowText;//Evens
            }
            return Color.Black;//Default
        }

        /// <summary>
        /// Gets the Colour for the background of the
        /// data holders.
        /// </summary>
        /// <param name="isWithinLimits">Status check.</param>
        /// <returns>A Color object.</returns>
        public static Color GetKPIDataBackground(bool? isWithinLimits)
        {
            if (isWithinLimits.HasValue)
            {
                if (isWithinLimits.Value)
                    return Settings.Default.ColourDashGoodBack;
                else
                    return Settings.Default.ColourDashBadBack;
            }
            return Settings.Default.ColourDashMissingBack;
        }

        /// <summary>
        /// Gets the Colour for the Foreground of the
        /// data holders.
        /// </summary>
        /// <param name="isWithinLimits">Status check.</param>
        /// <returns>A Color object.</returns>
        public static Color GetKPIDataForeColour(bool? isWithinLimits)
        {
            if (isWithinLimits.HasValue)
            {
                if (isWithinLimits.Value)
                    return Settings.Default.ColourDashGoodText;
                else
                    return Settings.Default.ColourDashBadText;
            }
            return Settings.Default.ColourDashMissingText;
        }

        public static Color RandomColour()
        {
            Random randomNo = new Random(MyDateTime.Now.Millisecond);

            int r = randomNo.Next(0, 255);
            int g = randomNo.Next(0, 255);
            int b = randomNo.Next(0, 255);

            return Color.FromArgb(r, g, b);
        }
    }
}
