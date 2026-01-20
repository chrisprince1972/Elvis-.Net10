using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel.EDMX;
using ElvisDataModel;
using NLog;

namespace Elvis.Forms.Reports.Miscasts
{
    public class MiscastLookups
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public List<MiscastAreaResponsible> Areas { get; set; }
        public List<MiscastFailureMode> FailureModes { get; set; }
        public List<MiscastFunction> Functions { get; set; }
        public List<MiscastOwner> Owners { get; set; }
        public List<MiscastRootCause> RootCauses { get; set; }
        public List<MiscastRota> Rotas { get; set; }
        public List<MiscastType> Types { get; set; }
        public List<MiscastUnit> Units { get; set; }
        public List<MiscastStatu> Statuses { get; set; }
        public List<LookupStandardPracticeFollowed> StandardPracticeFollowed { get; set; }

        /// <summary>
        /// Constructor for Miscast Lookups.  Pass in a string
        /// to use as first record if needed.  E.g. when using
        /// for the population of a drop down list and you
        /// need to first record to display "Please Select" or "All".
        /// </summary>
        /// <param name="firstRecord">Optional parameter; allows for the 
        /// creation of the first records for the lookups.</param>
        public MiscastLookups(string firstRecord = "")
        {
            Areas = new List<MiscastAreaResponsible>();
            FailureModes = new List<MiscastFailureMode>();
            Functions = new List<MiscastFunction>();
            Owners = new List<MiscastOwner>();
            RootCauses = new List<MiscastRootCause>();
            Rotas = new List<MiscastRota>();
            Types = new List<MiscastType>();
            Units = new List<MiscastUnit>();
            Statuses = new List<MiscastStatu>();
            StandardPracticeFollowed = new List<LookupStandardPracticeFollowed>();

            if (!string.IsNullOrWhiteSpace(firstRecord))
            {
                AddFirstRecord(firstRecord);
            }

            BuildLookups();
        }

        private void BuildLookups()
        {
            try
            {
                Areas.AddRange(EntityHelper.MiscastAreaResponsible.GetAll());
                FailureModes.AddRange(EntityHelper.MiscastFailureMode.GetAll());
                Functions.AddRange(EntityHelper.MiscastFunction.GetAll());
                Owners.AddRange(EntityHelper.MiscastOwners.GetAll());
                RootCauses.AddRange(EntityHelper.MiscastRootCause.GetAll());
                Rotas.AddRange(EntityHelper.MiscastRota.GetAll());
                Types.AddRange(EntityHelper.MiscastType.GetAll());
                Units.AddRange(EntityHelper.MiscastUnit.GetAll());
                Statuses.AddRange(EntityHelper.MiscastStatus.GetAll());
                StandardPracticeFollowed.AddRange(EntityHelper.LookupStandardPracticeFollowed.GetAll());
            }
            catch (Exception ex)
            {
                logger.ErrorException(
                    "DATA ERROR -- BuildLookups() -- Error building Miscast Lookups -- ", 
                    ex);
            }
        }

        private void AddFirstRecord(string firstRecord)
        {
            Areas.Add(new MiscastAreaResponsible() { AreaResponsibleID = 0, AreaResponsible = firstRecord, Sort = 0 });
            FailureModes.Add(new MiscastFailureMode() { FailureModeID = 0, FailureMode = firstRecord, Sort = 0 });
            Functions.Add(new MiscastFunction() { FunctionID = 0, TrioFunction = firstRecord, Sort = 0 });
            Owners.Add(new MiscastOwner() { MiscastOwnerID = 0, OwnerName = firstRecord, Sort = 0, IsTechnical = true });
            //RootCauses.Add(new MiscastRootCause() { RootCauseID = 0, RootCause = firstRecord, Sort = 0 });
            Rotas.Add(new MiscastRota() { RotaID = 0, Rota = firstRecord, Sort = 0 });
            Types.Add(new MiscastType() { MiscastTypeID = 0, Type = firstRecord, Sort = 0 });
            Units.Add(new MiscastUnit() { MiscastUnitID = 0, MiscastUnit1 = firstRecord, Sort = 0 });
            Statuses.Add(new MiscastStatu() { MiscastStatusID = 0, Status = firstRecord, Sort = 0 });
        }
    }
}
