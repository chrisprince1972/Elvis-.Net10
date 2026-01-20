using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElvisDataModel;
using Elvis.Common;

namespace Elvis.Model
{
    class RFTData
    {
        /// <summary>
        /// Generates and returns a list of RFT Records ready to 
        /// be bound to a Data Gridview.
        /// </summary>
        /// <param name="dateTime">The Date Time of the record to process.</param>
        /// <returns>A List of RFTRecord Objects.</returns>
        internal static List<RFTRecord> GetRFTRecords(DateTime dateTime)
        {
            List<RFTRecord> rfts = new List<RFTRecord>();
            ElvisDataModel.EDMX.RFTData rftUnprocessed = EntityHelper.RFTData.GetByDate(dateTime);

            if (rftUnprocessed != null)
            {
                rfts.Add(
                    GetRFTRecord(
                        rftUnprocessed,
                        RFTRecord.RFTType.PrecisionRFT,
                        rftUnprocessed.SlabsRFT,
                        rftUnprocessed.CC1SlabsRFT,
                        rftUnprocessed.CC2SlabsRFT,
                        rftUnprocessed.CC3SlabsRFT)
                    );

                rfts.Add(
                    GetRFTRecord(
                        rftUnprocessed,
                        RFTRecord.RFTType.GradeRFT,
                        rftUnprocessed.ShedGradeOk,
                        rftUnprocessed.CC1ShedGradeOk,
                        rftUnprocessed.CC2ShedGradeOk,
                        rftUnprocessed.CC3ShedGradeOk)
                    );

                rfts.Add(
                    GetRFTRecord(
                        rftUnprocessed,
                        RFTRecord.RFTType.WidthRFT,
                        rftUnprocessed.ShedWidthOk,
                        rftUnprocessed.CC1ShedWidthOk,
                        rftUnprocessed.CC2ShedWidthOk,
                        rftUnprocessed.CC3ShedWidthOk)
                    );

                rfts.Add(
                    GetRFTRecord(
                        rftUnprocessed,
                        RFTRecord.RFTType.LengthRFT,
                        rftUnprocessed.ShedLengthOk,
                        rftUnprocessed.CC1ShedLengthOk,
                        rftUnprocessed.CC2ShedLengthOk,
                        rftUnprocessed.CC3ShedLengthOk)
                    );
            }

            return rfts;
        }

        /// <summary>
        /// Function that creates the RFT Record ready 
        /// to return to the RFT Summary form.
        /// </summary>
        /// <param name="rftUnprocessed">The raw database object RFTData.</param>
        /// <param name="type">The enum Type that you wish to create e.g. PrecisionRFT, GradeRFT, WidthRFT, LengthRFT.</param>
        /// <param name="rft">The Value for RFT.</param>
        /// <param name="cc1RFT">The Value for CC1 RFT.</param>
        /// <param name="cc2RFT">The Value for CC2 RFT.</param>
        /// <param name="cc3RFT">The Value for CC3 RFT.</param>
        /// <returns>A RFTRecord ready to be added to a list.</returns>
        private static RFTRecord GetRFTRecord(
            ElvisDataModel.EDMX.RFTData rftUnprocessed,
            RFTRecord.RFTType type,
            int? rft, int? cc1RFT,
            int? cc2RFT, int? cc3RFT)
        {
            RFTRecord rftRecord = new RFTRecord(type,
                HelperFunctions.GetDoubleSafely(rft),
                HelperFunctions.GetDoubleSafely(cc1RFT),
                HelperFunctions.GetDoubleSafely(cc2RFT),
                HelperFunctions.GetDoubleSafely(cc3RFT)
                );

            if (rftUnprocessed != null)
            {
                rftRecord.AddSlabsData(
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.SlabsMadeSchedule),
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.SlabsMade),
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.CC1SlabsMadeSchedule),
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.CC1SlabsMade),
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.CC2SlabsMadeSchedule),
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.CC2SlabsMade),
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.CC3SlabsMadeSchedule),
                    HelperFunctions.GetDoubleSafely(rftUnprocessed.CC3SlabsMade)
                    );
            }
            return rftRecord;
        }
    }

    #region Supporting Classes
    public class RFTRecord
    {
        private RFTType type;
        private double totalRFT;
        private double totalSlabsMadeSchedule;
        private double totalSlabsMade;
        private double cc1RFT;
        private double cc1SlabsMadeSchedule;
        private double cc1SlabsMade;
        private double cc2RFT;
        private double cc2SlabsMadeSchedule;
        private double cc2SlabsMade;
        private double cc3RFT;
        private double cc3SlabsMadeSchedule;
        private double cc3SlabsMade;

        public enum RFTType { PrecisionRFT, GradeRFT, WidthRFT, LengthRFT };

        public string Type
        {
            get
            {
                switch (this.type)
                {
                    case RFTType.PrecisionRFT:
                        return "Precision RFT %";
                    case RFTType.GradeRFT:
                        return "Grade RFT %";
                    case RFTType.WidthRFT:
                        return "Width RFT %";
                    case RFTType.LengthRFT:
                        return "Length RFT %";
                    default:
                        return "Unknown";
                }
            }
        }

        public double TotalSlabsMade
        {
            get { return this.totalSlabsMade; }
        }

        public double TotalPercRFT
        {
            get
            {
                if (this.totalSlabsMadeSchedule > 0)
                {
                    return Math.Round(
                        (this.totalRFT / this.totalSlabsMadeSchedule) * 100, 1);
                }
                return 0;
            }
        }

        public double CC1SlabsMade
        {
            get { return this.cc1SlabsMade; }
        }

        public double CC1PercRFT
        {
            get
            {
                if (this.cc1SlabsMadeSchedule > 0)
                {
                    return Math.Round(
                        (this.cc1RFT / this.cc1SlabsMadeSchedule) * 100, 1);
                }
                return 0;
            }
        }

        public double CC2SlabsMade
        {
            get { return this.cc2SlabsMade; }
        }

        public double CC2PercRFT
        {
            get
            {
                if (this.cc2SlabsMadeSchedule > 0)
                {
                    return Math.Round(
                        (this.cc2RFT / this.cc2SlabsMadeSchedule) * 100, 1);
                }
                return 0;
            }
        }

        public double CC3SlabsMade
        {
            get { return this.cc3SlabsMade; }
        }

        public double CC3PercRFT
        {
            get
            {
                if (this.cc3SlabsMadeSchedule > 0)
                {
                    return Math.Round(
                        (this.cc3RFT / this.cc3SlabsMadeSchedule) * 100, 1);
                }
                return 0;
            }
        }

        /// <summary>
        /// Creates an instance of the RFTRecord class,
        /// which holds information for the RFT Table on
        /// the RFT Summary Form.
        /// </summary>
        /// <param name="type">The Type of RFT Row e.g. Precision RFT, Grade RFT.</param>
        /// <param name="totalRFT">
        ///     This value is used for calculating the RFT %.  It is the numerator
        ///     for the calculation. Column names from database are - 
        ///         Total   - [SlabsRFT], [ShedGradeOk], [ShedWidthOk], [ShedLengthOk]
        /// </param>
        /// <param name="cc1RFT">
        ///     This value is used for calculating the RFT %.  It is the numerator
        ///     for the calculation. Column names from database are - 
        ///         CC1     - [CC1SlabsRFT], [CC1ShedGradeOk], [CC1ShedWidthOk], [CC1ShedLengthOk]
        /// </param>
        /// <param name="cc2RFT">
        ///     This value is used for calculating the RFT %.  It is the numerator
        ///     for the calculation. Column names from database are - 
        ///         CC2     - [CC2SlabsRFT], [CC2ShedGradeOk], [CC2ShedWidthOk], [CC2ShedLengthOk]
        /// </param>
        /// <param name="cc3RFT">
        ///     This value is used for calculating the RFT %.  It is the numerator
        ///     for the calculation. Column names from database are - 
        ///         CC3     - [CC3SlabsRFT], [CC3ShedGradeOk], [CC3ShedWidthOk], [CC3ShedLengthOk]
        /// </param>
        public RFTRecord(RFTType type,
            double totalRFT, double cc1RFT,
            double cc2RFT, double cc3RFT)
        {
            this.type = type;
            this.totalRFT = totalRFT;
            this.cc1RFT = cc1RFT;
            this.cc2RFT = cc2RFT;
            this.cc3RFT = cc3RFT;
        }

        /// <summary>
        /// Adds the additional data for calculating
        /// the RFT Values.  This method must be run 
        /// for any calculations to work.  This has been
        /// seperated from the constructor to stop code 
        /// duplication.
        /// </summary>
        /// <param name="totalSlabsMadeSchedule">The Total Slabs Made To Schedule - [SlabsMadeSchedule]</param>
        /// <param name="totalSlabsMade">The Total Slabs Made - [SlabsMade]</param>
        /// <param name="cc1SlabsMadeSchedule">The Slabs Made to Shedule for CC1 - [CC1SlabsMadeSchedule]</param>
        /// <param name="cc1SlabsMade">The Slabs Made for CC1 - [CC1SlabsMade]</param>
        /// <param name="cc2SlabsMadeSchedule">The Slabs Made to Shedule for CC2 - [CC2SlabsMadeSchedule]</param>
        /// <param name="cc2SlabsMade">The Slabs Made for CC2 - [CC2SlabsMade]</param>
        /// <param name="cc3SlabsMadeSchedule">The Slabs Made to Shedule for CC3 - [CC3SlabsMadeSchedule]</param>
        /// <param name="cc3SlabsMade">The Slabs Made for CC3 - [CC3SlabsMade]</param>
        public void AddSlabsData(
            double totalSlabsMadeSchedule, double totalSlabsMade,
            double cc1SlabsMadeSchedule, double cc1SlabsMade,
            double cc2SlabsMadeSchedule, double cc2SlabsMade,
            double cc3SlabsMadeSchedule, double cc3SlabsMade)
        {
            this.totalSlabsMadeSchedule = totalSlabsMadeSchedule;
            this.totalSlabsMade = totalSlabsMade;
            this.cc1SlabsMadeSchedule = cc1SlabsMadeSchedule;
            this.cc1SlabsMade = cc1SlabsMade;
            this.cc2SlabsMadeSchedule = cc2SlabsMadeSchedule;
            this.cc2SlabsMade = cc2SlabsMade;
            this.cc3SlabsMadeSchedule = cc3SlabsMadeSchedule;
            this.cc3SlabsMade = cc3SlabsMade;
        }
    }
    #endregion
}
