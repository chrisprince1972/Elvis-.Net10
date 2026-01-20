using BusinessLogic.Constants;
using BusinessLogic.Constants.Trending.Dashboards;
using BusinessLogic.Models.ViewModels;
using ElvisDataModel;
using ElvisDataModel.EDMX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BusinessLogic.Models.TrendingShifts
{
    public class KpiConfigShiftWrapper
    {
        public int Index { get; protected set; }
        public int Level { get; protected set; }
        public string Description { get; protected set; }
        public float? Minimum { get; set; }
        public float? Maximum { get; set; }
        public int SubLevel { get; set; }
        public KpiAction Action { get; set; }
        public bool ShowValue { get; set; }
        public string ToolTip { get; set; }
        public DashboardType Dashboard { get; set; }
        public string StringFormat { get; set; }
        public string Info { get; set; }
        public ElvisSettings Settings { get; protected set; }

        public KpiConfigShiftWrapper(ElvisSettings settings,
            KPIConfigShift kpiConfig,
            IEnumerable<GroupConfig> groupConfigs)
        {
            Settings = settings;
            Index = kpiConfig.KPIINdex;
            SetLevel(kpiConfig.KPILevel);
            SetSubLevel(kpiConfig.KPISubLevel);
            Description = kpiConfig.KPIDescription;
            Minimum = kpiConfig.Minimum;
            Maximum = kpiConfig.Maximum;
            SubLevel = kpiConfig.KPISubLevel.Value;
            SetAction(kpiConfig.KPIActionIndex, kpiConfig.KPIActionGroup,
                groupConfigs);
            ShowValue = kpiConfig.ShowValue;
            ToolTip = kpiConfig.ToolTip;
            SetDashboard(kpiConfig.Dashboard);
            StringFormat = kpiConfig.StringFormat;
            Info = kpiConfig.KPIInfo;
        }

        public KpiConfigShiftWrapper(KpiConfigShiftWrapper kpiConfig)
        {
            Settings = kpiConfig.Settings;
            Index = kpiConfig.Index;
            Level = kpiConfig.Level;
            SubLevel = kpiConfig.SubLevel;
            Description = kpiConfig.Description;
            Minimum = kpiConfig.Minimum;
            Maximum = kpiConfig.Maximum;
            Action = kpiConfig.Action;
            ShowValue = kpiConfig.ShowValue;
            ToolTip = kpiConfig.ToolTip;
            Dashboard = kpiConfig.Dashboard;
            StringFormat = kpiConfig.StringFormat;
            Info = kpiConfig.Info;
        }
        
        public string GetToolTip(DateTime startDate, Rota rota, 
            Shift shift, bool lineBreaks)
        {
            string returnValue = "";
            if (!string.IsNullOrWhiteSpace(ToolTip))
            {
                if (lineBreaks)
                {
                    returnValue += Environment.NewLine;
                }
                else
                {
                    returnValue += " ";
                }

                returnValue += ToolTip;
            }

            string dateAsString = startDate.ToString("dddd, dd MMM yyyy");

            string shiftAsString = Enum.GetName(typeof(Shift), shift);

            returnValue = string.Format("{0} Rota: {1} Shift: {2}{3}{4}",
                dateAsString, rota, shiftAsString, returnValue,
                GetAdditionalToolTipInfo());

            return returnValue;
        }
        public bool Update(TrendSchemaEntities ctx)
        {
            bool returnValue = false;
            KPIConfigShift kpiConfig = 
                ctx.KPIConfigShifts.FirstOrDefault(t =>
                t.KPIINdex == Index);

            if (kpiConfig != null)
            {
                ToEntityFrameworkModel(ref kpiConfig);
                ctx.SaveChanges();
                returnValue = true;
            }

            return returnValue;
        }

        public bool Content()
        {
            return SubLevel > 0;
        }

        public bool Spacer()
        {
            return SubLevel == 0;
        }

        public string GetLevelText()
        {
            return string.Format("{0}.{1}", Level.ToString(), 
                SubLevel.ToString());
        }

        public Color GetKpiTextColour()
        {
            Color returnValue = Color.Black;
            if (Level % 2 == 0)
            {
                returnValue = Settings.ColourDashAltRowText;
            }
            else
            {
                returnValue = Settings.ColourDashRowText;
            }

            return returnValue;
        }

        public Color GetKpiBackgroundColour()
        {
            Color returnValue = Color.Black;
            if (Level % 2 == 0)
            {
                returnValue = Settings.ColourDashAltRowBackground;
            }
            else
            {
                returnValue = Settings.ColourDashRowBackground;
            }

            return returnValue;
        }


        public MiscastFunctionArea GetMiscastFunctionArea()
        {
            MiscastFunctionArea returnValue = MiscastFunctionArea.Unknown;

            if (SubLevel > 0)
            {
                if (Description.Contains("Manufacturing"))
                {
                    returnValue = MiscastFunctionArea.Manufacturing;
                }
                else if (Description.Contains("Technical"))
                {
                    returnValue = MiscastFunctionArea.Technical;
                }
                else if (Description.Contains("Engineering"))
                {
                    returnValue = MiscastFunctionArea.Engineering;
                }
            }

            return returnValue;
        }

        public static IEnumerable<KpiConfigShiftWrapper> All(
            ElvisSettings settings, IEnumerable<GroupConfig> groupConfigs)
        {
            using (TrendSchemaEntities ctx = new TrendSchemaEntities(
                EntityHelper.ElvisDBSettings.ConnectionString))
            {
                return (from kcs in ctx.KPIConfigShifts
                        select kcs).ToList()
                    .Select
                    (r =>
                        new KpiConfigShiftWrapper(settings, r, groupConfigs)
                    );
            }
        }

        private void ToEntityFrameworkModel(ref KPIConfigShift kpiConfig)
        {
            int? actionIndex = null;
            int? actionGroup = null;
            if (Action != null)
            {
                actionIndex = (int)Action.Index;
                if (Action.Group != null)
                {
                    actionGroup = Action.Group.GroupIndex;
                }
            }

            kpiConfig.KPILevel = Level;
            kpiConfig.KPISubLevel = SubLevel;
            kpiConfig.KPIDescription = Description;
            kpiConfig.Minimum = Minimum;
            kpiConfig.Maximum = Maximum;
            kpiConfig.KPIActionIndex = actionIndex;
            kpiConfig.KPIActionGroup = actionGroup;
            kpiConfig.ShowValue = ShowValue;
            kpiConfig.ToolTip = ToolTip;
            kpiConfig.Dashboard = (int)Dashboard;
            kpiConfig.StringFormat = StringFormat;
            kpiConfig.KPIInfo = Info;
        }

        private void SetAction(int? index, int? groupIndex, 
            IEnumerable<GroupConfig> groupConfigs)
        {
            if(index.HasValue && index > 0)
            {
                GroupConfig groupConf = null;
                if (groupIndex.HasValue)
                {
                    groupConf = (
                        from gc in groupConfigs
                        where gc.GroupIndex == groupIndex
                        select gc).FirstOrDefault();
                }

                Action = new KpiAction(index.Value, groupConf);
            }
        }

        protected string GetAdditionalToolTipInfo()
        {
            string returnValue = string.Empty;
            if (Action != null && Action.Group != null)
            {
                if (Action.Index == DashboardActionType.Trending)
                {
                    returnValue = " for " + Action.Group.GroupDesc;
                }
            }

            return returnValue;
        }

        private void SetLevel(float? level)
        {
            Level = GetInt(level);
        }
        private void SetSubLevel(float? subLevel)
        {
            SubLevel = GetInt(subLevel);
        }
        private void SetDashboard(float? dashboard)
        {
            Dashboard = (DashboardType) GetInt(dashboard);
        }

        // for incorrectly specified db types
        private int GetInt(float? val)
        {
            int returnValue = 0;
            int temp = 0;
            if (val.HasValue && int.TryParse(val.ToString(), out temp))
            {
                returnValue = temp;
            }
            return returnValue;
        }
    }
}
