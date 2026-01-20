using System.Drawing;
using Elvis.Properties;

namespace Elvis.Common
{
    class DefaultSettings
    {
        #region Colours

        /// <summary>
        /// Tata Blue
        /// </summary>
        public static Color TataBlue
        {
            get { return ColorTranslator.FromHtml("#3d7edb"); }
        }

        /// <summary>
        /// Default Background Colour
        /// </summary>
        public static Color Background
        {
            get { return Color.FromKnownColor(KnownColor.ControlLight); }
        }

        /// <summary>
        /// Default Text Colour
        /// </summary>
        public static Color Text
        {
            get { return Color.FromKnownColor(KnownColor.ControlText); }
        }

        #region Casters
        /// <summary>
        /// Default Caster 1 Colour
        /// </summary>
        public static Color Caster1
        {
            get { return ColorTranslator.FromHtml("#5EFFFC"); }
        }

        /// <summary>
        /// Default Caster 1 Planning Colour
        /// </summary>
        public static Color Caster1Planning
        {
            get { return ColorTranslator.FromHtml("#BFFFFE"); }
        }

        /// <summary>
        /// Default Caster 2 Colour
        /// </summary>
        public static Color Caster2
        {
            get { return ColorTranslator.FromHtml("#FF47EA"); }
        }

        /// <summary>
        /// Default Caster 2 Planning Colour
        /// </summary>
        public static Color Caster2Planning
        {
            get { return ColorTranslator.FromHtml("#FFB8F7"); }
        }

        /// <summary>
        /// Default Caster 3 Colour
        /// </summary>
        public static Color Caster3
        {
            get { return ColorTranslator.FromHtml("#F9FF45"); }
        }

        /// <summary>
        /// Default Caster 3 Planning Colour
        /// </summary>
        public static Color Caster3Planning
        {
            get { return ColorTranslator.FromHtml("#FDFFC4"); }
        }

        /// <summary>
        /// Default Slow Cast Planning Colour
        /// </summary>
        public static Color SlowCastPlan
        {
            get { return Color.Red; }
        }

        #region Caster Trends
        /// <summary>
        /// Default N Tundish Temp Colour
        /// </summary>
        public static Color NTundishTemp
        {
            get { return Color.Blue; }
        }

        /// <summary>
        /// Default S Tundish Temp Colour
        /// </summary>
        public static Color STundishTemp
        {
            get { return Color.Black; }
        }

        /// <summary>
        /// Default Tundish Weight Colour
        /// </summary>
        public static Color TundishWeight
        {
            get { return Color.Pink; }
        }

        /// <summary>
        /// Default Ladle Weight Colour
        /// </summary>
        public static Color LadleWeight
        {
            get { return Color.Lime; }
        }

        /// <summary>
        /// Default S1 Speed Colour
        /// </summary>
        public static Color S1Speed
        {
            get { return Color.Chocolate; }
        }

        /// <summary>
        /// Default S2 Speed Colour
        /// </summary>
        public static Color S2Speed
        {
            get { return Color.Gold; }
        }

        /// <summary>
        /// Default S1 Mould Level Colour
        /// </summary>
        public static Color S1MouldLvl
        {
            get { return Color.Red; }
        }

        /// <summary>
        /// Default S2 Mould Level Colour
        /// </summary>
        public static Color S2MouldLvl
        {
            get { return Color.LightBlue; }
        }

        /// <summary>
        /// Default S1 Stopper Position Colour
        /// </summary>
        public static Color S1StopperPos
        {
            get { return Color.CadetBlue; }
        }

        /// <summary>
        /// Default S2 Stopper Position Colour
        /// </summary>
        public static Color S2StopperPos
        {
            get { return Color.DarkRed; }
        }

        /// <summary>
        /// Default S1 Slab Width Colour
        /// </summary>
        public static Color S1SlabWidth
        {
            get { return Color.Cyan; }
        }

        /// <summary>
        /// Default S2 Slab Width Colour
        /// </summary>
        public static Color S2SlabWidth
        {
            get { return Color.DarkGray; }
        }

        /// <summary>
        /// Default S1 Auto Colour
        /// </summary>
        public static Color S1Auto
        {
            get { return Color.Peru; }
        }

        /// <summary>
        /// Default S2 Auto Colour
        /// </summary>
        public static Color S2Auto
        {
            get { return Color.MidnightBlue; }
        }

        /// <summary>
        /// Default S1 Immersion Colour
        /// </summary>
        public static Color S1Immersion
        {
            get { return Color.Purple; }
        }

        /// <summary>
        /// Default S2 Immersion Colour
        /// </summary>
        public static Color S2Immersion
        {
            get { return Color.Firebrick; }
        }

        /// <summary>
        /// Default NTC in Position Colour
        /// </summary>
        public static Color NTCinPosition
        {
            get { return Color.Orchid; }
        }

        /// <summary>
        /// Default STC in Position Colour
        /// </summary>
        public static Color STCinPosition
        {
            get { return Color.OliveDrab; }
        }
        #endregion

        #endregion

        #region Vessels
        /// <summary>
        /// Default Vessel 1 Colour
        /// </summary>
        public static Color Vessel1
        {
            get { return ColorTranslator.FromHtml("#122EFF"); }
        }

        /// <summary>
        /// Default Vessel 1 Planning Colour
        /// </summary>
        public static Color Vessel1Planning
        {
            get { return ColorTranslator.FromHtml("#8A97FF"); }
        }

        /// <summary>
        /// Default Vessel 2 Colour
        /// </summary>
        public static Color Vessel2
        {
            get { return ColorTranslator.FromHtml("#FF9D00"); }
        }

        /// <summary>
        /// Default Vessel 2 Planning Colour
        /// </summary>
        public static Color Vessel2Planning
        {
            get { return ColorTranslator.FromHtml("#FFD38C"); }
        }
        #endregion

        #region Heat Scheduler
        /// <summary>
        /// Default Heat Scheduler Background 1
        /// </summary>
        public static Color HeatSchedulerBackground1
        {
            get { return ColorTranslator.FromHtml("#D6DBFF"); }
        }

        /// <summary>
        /// Default Heat Scheduler Background 2
        /// </summary>
        public static Color HeatSchedulerBackground2
        {
            get { return ColorTranslator.FromHtml("#DCFFCF"); }
        }
        #endregion

        #region Tib

        #region Background
        /// <summary>
        /// Default Tib External Colour
        /// </summary>
        public static Color TibExternal
        {
            get { return Color.Red; }
        }
        /// <summary>
        /// Default Tib MultiServ Colour
        /// </summary>
        public static Color TibMultiServ
        {
            get { return Color.BlueViolet; }
        }
        /// <summary>
        /// Default Tib HM & Scrap Colour
        /// </summary>
        public static Color TibHMScrap
        {
            get { return Color.Gold; }
        }
        /// <summary>
        /// Default Tib Vessels Colour
        /// </summary>
        public static Color TibVessels
        {
            get { return Color.SeaGreen; }
        }
        /// <summary>
        /// Default Tib Plan Colour
        /// </summary>
        public static Color TibPlan
        {
            get { return Color.HotPink; }
        }
        /// <summary>
        /// Default Tib Sec-Steel Colour
        /// </summary>
        public static Color TibSecSteel
        {
            get { return Color.YellowGreen; }
        }
        /// <summary>
        /// Default Tib Casters Colour
        /// </summary>
        public static Color TibCasters
        {
            get { return Color.SkyBlue; }
        }
        /// <summary>
        /// Default Tib Cranes Colour
        /// </summary>
        public static Color TibCranes
        {
            get { return Color.Peru; }
        }
        /// <summary>
        /// Default Tib No Reason Colour
        /// </summary>
        public static Color TibNoReason
        {
            get { return Color.DarkGray; }
        }
        /// <summary>
        /// Default Lime Plant Colour
        /// </summary>
        public static Color LimePlant
        {
            get { return Color.White; }
        }
        /// <summary>
        /// Default LP Changeover Colour
        /// </summary>
        public static Color LPChangeover
        {
            get { return Color.HotPink; }
        }
        #endregion

        #region Foreground
        /// <summary>
        /// Default Tib External Colour
        /// </summary>
        public static Color TibExternalFore
        {
            get { return Color.White; }
        }
        /// <summary>
        /// Default Tib MultiServ Colour
        /// </summary>
        public static Color TibMultiServFore
        {
            get { return Color.White; }
        }
        /// <summary>
        /// Default Tib HM & Scrap Colour
        /// </summary>
        public static Color TibHMScrapFore
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Tib Vessels Colour
        /// </summary>
        public static Color TibVesselsFore
        {
            get { return Color.White; }
        }
        /// <summary>
        /// Default Tib Plan Colour
        /// </summary>
        public static Color TibPlanFore
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Tib Sec-Steel Colour
        /// </summary>
        public static Color TibSecSteelFore
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Tib Casters Colour
        /// </summary>
        public static Color TibCastersFore
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Tib Cranes Colour
        /// </summary>
        public static Color TibCranesFore
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Tib No Reason Colour
        /// </summary>
        public static Color TibNoReasonFore
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Lime Plant Text Colour
        /// </summary>
        public static Color LimePlantFore
        {
            get { return Color.Black; }
        }
        #endregion

        #endregion

        #region OEE

        #region Background
        /// <summary>
        /// Default OEE L1 Background Colour
        /// </summary>
        public static Color OEEL1Background
        {
            get { return ColorTranslator.FromHtml("#8080FF"); }
        }

        /// <summary>
        /// Default OEE L2 Background Colour
        /// </summary>
        public static Color OEEL2Background
        {
            get { return Color.White; }
        }
        #endregion

        #region Foreground
        /// <summary>
        /// Default OEE L1 Text Colour
        /// </summary>
        public static Color OEEL1Text
        {
            get { return Color.Black; }
        }

        /// <summary>
        /// Default OEE L2 Text Colour
        /// </summary>
        public static Color OEEL2Text
        {
            get { return Color.Black; }
        }
        #endregion

        #endregion

        #region Tables

        #region Analysis
        /// <summary>
        /// Default Table Header Background
        /// </summary>
        public static Color DefaultTableHeaderBackground
        {
            get
            {
                if (Settings.Default.TableTheme == "Default")
                    return Color.FromKnownColor(KnownColor.ControlDark);
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Header Fore Color
        /// </summary>
        public static Color DefaultTableHeaderForeColor
        {
            get
            {
                if (Settings.Default.TableTheme == "Default")
                    return Color.Black;
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Fore Color
        /// </summary>
        public static Color DefaultTableCellForeColor
        {
            get
            {
                if (Settings.Default.TableTheme == "Default")
                    return Color.Black;
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Background
        /// </summary>
        public static Color DefaultTableCellBackground
        {
            get
            {
                if (Settings.Default.TableTheme == "Default")
                    return Color.White;
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Highlight
        /// </summary>
        public static Color DefaultTableCellHighlight
        {
            get
            {
                if (Settings.Default.TableTheme == "Default")
                    return Color.FromKnownColor(KnownColor.Highlight);
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Highlight Text
        /// </summary>
        public static Color DefaultTableCellHighlightText
        {
            get
            {
                if (Settings.Default.TableTheme == "Default")
                    return Color.FromKnownColor(KnownColor.HighlightText);
                else
                    return Color.Black;//High Contrast
            }
        }
        #endregion

        #region CBM 
        /// <summary>
        /// Default Table Header Background
        /// </summary>
        public static Color DefaultCBMTableHeaderBackground
        {
            get
            {
                if (Settings.Default.CBMColourScheme == "Default")
                    return Color.FromKnownColor(KnownColor.ControlDark);
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Header Fore Color
        /// </summary>
        public static Color DefaultCBMTableHeaderForeColor
        {
            get
            {
                if (Settings.Default.CBMColourScheme == "Default")
                    return Color.Black;
                else
                    return ColorTranslator.FromHtml("#F6DA00");//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Fore Color
        /// </summary>
        public static Color DefaultCBMTableCellForeColor
        {
            get
            {
                if (Settings.Default.CBMColourScheme == "Default")
                    return Color.Black;
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Background
        /// </summary>
        public static Color DefaultCBMTableCellBackground
        {
            get
            {
                if (Settings.Default.CBMColourScheme == "Default")
                    return Color.White;
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Highlight
        /// </summary>
        public static Color DefaultCBMTableCellHighlight
        {
            get
            {
                if (Settings.Default.CBMColourScheme == "Default")
                    return Color.FromKnownColor(KnownColor.Highlight);
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Highlight Text
        /// </summary>
        public static Color DefaultCBMTableCellHighlightText
        {
            get
            {
                if (Settings.Default.CBMColourScheme == "Default")
                    return Color.FromKnownColor(KnownColor.HighlightText);
                else
                    return Color.Black;//High Contrast
            }
        }
        #endregion

        #region EBM
        /// <summary>
        /// Default Table Header Background
        /// </summary>
        public static Color DefaultEBMTableHeaderBackground
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.FromKnownColor(KnownColor.ControlDark);
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Header Fore Color
        /// </summary>
        public static Color DefaultEBMTableHeaderForeColor
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.Black;
                else
                    return ColorTranslator.FromHtml("#F6DA00");//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Fore Color
        /// </summary>
        public static Color DefaultEBMTableCellForeColor
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.Black;
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Background
        /// </summary>
        public static Color DefaultEBMTableCellBackground
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.White;
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Highlight
        /// </summary>
        public static Color DefaultEBMTableCellHighlight
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.FromKnownColor(KnownColor.Highlight);
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default Table Cell Highlight Text
        /// </summary>
        public static Color DefaultEBMTableCellHighlightText
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.FromKnownColor(KnownColor.HighlightText);
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Alternate Table Row Back Colour
        /// </summary>
        public static Color DefaultEBMTableAlternateRow
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.WhiteSmoke;
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default Alternate Table Row Fore Colour
        /// </summary>
        public static Color DefaultEBMTableAlternateRowText
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.Black;
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        #endregion

        #endregion

        #region Charts

        #region EBM
        /// <summary>
        /// Default EBM Chart Background.
        /// </summary>
        public static Color DefaultEBMChartBackground
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.White;
                else
                    return Color.Black;//High Contrast
            }
        }
        /// <summary>
        /// Default EBM Chart Fore Colour.
        /// </summary>
        public static Color DefaultEBMChartForeColour
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.Black;
                else
                    return Color.WhiteSmoke;//High Contrast
            }
        }
        /// <summary>
        /// Default EBM Chart Lance Height Colour.
        /// </summary>
        public static Color DefaultEBMChartLanceHeight
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.LimeGreen;
                else
                    return Color.Lime;//High Contrast
            }
        }
        /// <summary>
        /// Default EBM Chart Oxy Flow Colour.
        /// </summary>
        public static Color DefaultEBMChartOxyFlow
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.Red;
                else
                    return Color.Red;//High Contrast
            }
        }
        /// <summary>
        /// Default EBM Chart Audio Colour.
        /// </summary>
        public static Color DefaultEBMChartAudio
        {
            get
            {
                if (Settings.Default.EBMColourScheme == "Default")
                    return Color.DarkTurquoise;
                else
                    return Color.Cyan;//High Contrast
            }
        }
        #endregion

        #endregion

        #region Trending
        /// <summary>
        /// Default Highlight Colour 1
        /// </summary>
        public static Color ColourHighlight1
        {
            get { return ColorTranslator.FromHtml("#14C8FA"); }
        }
        /// <summary>
        /// Default Highlight Colour 2
        /// </summary>
        public static Color ColourHighlight2
        {
            get { return ColorTranslator.FromHtml("#F43C3C"); }
        }
        /// <summary>
        /// Default Highlight Colour 3
        /// </summary>
        public static Color ColourHighlight3
        {
            get { return ColorTranslator.FromHtml("#18A018"); }
        }
        /// <summary>
        /// Default Highlight Colour 4
        /// </summary>
        public static Color ColourHighlight4
        {
            get { return ColorTranslator.FromHtml("#FF8E1E"); }
        }
        #endregion

        #region Dashboards
        /// <summary>
        /// Default Dashboard Header Back Colour
        /// </summary>
        public static Color DashHeaderBack
        {
            get { return Color.PowderBlue; }
        }
        /// <summary>
        /// Default Dashboard Row Back Colour
        /// </summary>
        public static Color DashRowBack
        {
            get { return Color.WhiteSmoke; }
        }
        /// <summary>
        /// Default Dashboard Alt Row Back Colour
        /// </summary>
        public static Color DashAltRowBack
        {
            get { return ColorTranslator.FromHtml("#DAEBFF"); }
        }
        /// <summary>
        /// Default Dashboard Good Back Colour
        /// </summary>
        public static Color DashGoodBack
        {
            get { return ColorTranslator.FromHtml("#26F43E"); }
        }
        /// <summary>
        /// Default Dashboard Bad Back Colour
        /// </summary>
        public static Color DashBadBack
        {
            get { return ColorTranslator.FromHtml("#e12301"); }
        }
        /// <summary>
        /// Default Dashboard Missing Back Colour
        /// </summary>
        public static Color DashMissingBack
        {
            get { return Color.White; }
        }
        /// <summary>
        /// Default Dashboard Header Text Colour
        /// </summary>
        public static Color DashHeaderText
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Dashboard Dash Row Text Colour
        /// </summary>
        public static Color DashRowText
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Dashboard Dash alternate row text Colour
        /// </summary>
        public static Color DashAltRowText
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Dashboard Good Text Colour
        /// </summary>
        public static Color DashGoodText
        {
            get { return Color.Black; }
        }
        /// <summary>
        /// Default Dashboard Bad Text Colour
        /// </summary>
        public static Color DashBadText
        {
            get { return Color.White; }
        }
        /// <summary>
        /// Default Dashboard Missing Text Colour
        /// </summary>
        public static Color DashMissingText
        {
            get { return Color.Black; }
        }
        #endregion

        #endregion

        #region Values
        /// <summary>
        /// Default Height for Tib Not Producing Event
        /// </summary>
        public static int TibNotProducingHeight
        {
            get { return 8; }
        }
        /// <summary>
        /// Default Height for Tib Producing Event
        /// </summary>
        public static int TibProducingHeight
        {
            get { return 20; }
        }
        /// <summary>
        /// Default Height for Tib In Process Event
        /// </summary>
        public static int TibInProcessHeight
        {
            get { return 18; }
        }
        /// <summary>
        /// Default Height for Tib Out Process Event
        /// </summary>
        public static int TibOutProcessHeight
        {
            get { return 12; }
        }
        /// <summary>
        /// Default Height for Tib Unproductive Event
        /// </summary>
        public static int TibUnproductiveHeight
        {
            get { return 8; }
        }
        /// <summary>
        /// Average Iron Consumption per Blow.
        /// Possibly needs to be changed in future or added to the configurable parameters.
        /// </summary>
        public static double AvgIronPerBlow
        {
            get { return 300.0; }
        }
        #endregion

        #region Fonts
        /// <summary>
        /// Default Font for Schedulers
        /// </summary>
        public static Font FontSchedulerDefault
        {
            get { return new Font("Courier New", 8, FontStyle.Regular); }
        }
        #endregion
    }
}
