using System;
using ElvisDataModel.EDMX;

namespace Elvis.Model
{
    [Serializable]
    public class ProductionEvent
    {
        #region Variables
        private int trackIndex;
        private int heatNumber;
        private int heatNumberSet;
        private int unitId;
        private int delayType;
        private DateTime planStartTime;//Used for detecting delayed planning blocks
        private DateTime startTime;
        private DateTime? endTime;
        private int programNumber;
        private string casterName;//Short Desc as String e.g. CC1
        private int vesselNumber;
        private bool isPlanningBlock;
        private bool isInProgress;
        private bool isFalseEndTime;
        private int grade;
        private int ladleNo;
        private int idealCastingTime;
        private int castDuration;
        private string miscastType;
        private bool isHotConnect;
        #endregion

        #region Properties
        public int TrackIndex
        {
            get { return this.trackIndex; }
            set { this.trackIndex = value; }
        }
        public int UnitId
        {
            get { return this.unitId; }
            set { this.unitId = value; }
        }
        public int DelayType
        {
            get { return this.delayType; }
            set { this.delayType = value; }
        }
        public DateTime StartTime
        {
            get { return this.startTime; }
            set { this.startTime = value; }
        }
        public DateTime PlanStartTime
        {
            get { return this.planStartTime; }
            set { this.planStartTime = value; }
        }
        public DateTime? EndTime
        {
            get { return this.endTime; }
            set { this.endTime = value; }
        }
        public int HeatNumber
        {
            get { return this.heatNumber; }
            set { this.heatNumber = value; }
        }
        public int HeatNumberSet
        {
            get { return this.heatNumberSet; }
            set { this.heatNumberSet = value; }
        }
        public int ProgramNumber
        {
            get { return this.programNumber; }
            set { this.programNumber = value; }
        }
        public string CasterName
        {
            get { return this.casterName; }
            set { this.casterName = value; }
        }
        public int VesselNumber
        {
            get { return this.vesselNumber; }
            set { this.vesselNumber = value; }
        }
        public bool IsPlanningBlock
        {
            get { return this.isPlanningBlock; }
            set { this.isPlanningBlock = value; }
        }
        public bool IsInProgress
        {
            get { return this.isInProgress; }
        }
        public bool IsFalseEndTime
        {
            get { return this.isFalseEndTime; }
        }
        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }
        public int LadleNumber
        {
            get { return this.ladleNo; }
            set { this.ladleNo = value; }
        }
        public int CastDuration
        {
            get { return this.castDuration; }
            set { this.castDuration = value; }
        }
        public int IdealCastingTime
        {
            get { return this.idealCastingTime; }
            set { this.idealCastingTime = value; }
        }
        public string MiscastType
        {
            get { return miscastType; }
            set { this.miscastType = value; }
        }
        public bool IsHotConnect
        {
            get { return isHotConnect; }
            set { this.isHotConnect = value; }
        }
        #endregion

        #region Constructors

        public ProductionEvent() { }//Blank Constructor If Needed

        /// <summary>
        /// Constructor for Planning Events
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        /// <param name="unitID">The Unit ID of the Event</param>
        /// <param name="startTime">Start Time of the Event</param>
        /// <param name="endTime">End Time of the Event</param>
        /// <param name="programNumber">The Current Program Number of the Event</param>
        /// <param name="casterNumber">Caster Number</param>
        /// <param name="vesselNumber">Vessel Number</param>
        /// <param name="isPlanning">Boolean stating if planning event or not</param>
        /// <param name="grade">The Grade Number.</param>
        public ProductionEvent(int heatNumber, int heatNumberSet, int unitID, DateTime startTime,
                               DateTime? endTime, int programNumber, string casterNumber,
                               int vesselNumber, bool isPlanning, int grade, int ladleNo)
        {
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;
            this.unitId = unitID;
            this.planStartTime = startTime;
            this.startTime = startTime;
            this.endTime = endTime;
            this.programNumber = programNumber;
            this.casterName = casterNumber;
            this.vesselNumber = vesselNumber;
            this.isPlanningBlock = isPlanning;
            this.grade = grade;
            this.ladleNo = ladleNo;
        }

        /// <summary>
        /// Constructor for Production Events
        /// </summary>
        /// <param name="heatNumber">The Heat Number</param>
        /// <param name="heatNumberSet">The Heat Number Set</param>
        /// <param name="unitID">The Unit ID of the Event</param>
        /// <param name="delayType">Delay Type</param>
        /// <param name="startTime">Start Time of the Event</param>
        /// <param name="endTime">End Time of the Event</param>
        /// <param name="programNumber">The Current Program Number of the Event</param>
        /// <param name="isPlanning">Boolean stating if planning event or not</param>
        public ProductionEvent(int trackIndex,
                               int heatNumber, int heatNumberSet,
                               int unitID, int delayType,
                               DateTime startTime, DateTime? endTime,
                               int programNumber, string casterName,
                               int vesselNumber, bool isPlanning, 
                               int grade, int ladleNo)
        {
            this.trackIndex = trackIndex;
            this.heatNumber = heatNumber;
            this.heatNumberSet = heatNumberSet;
            this.unitId = unitID;
            this.delayType = delayType;
            this.startTime = startTime;
            this.endTime = endTime;
            this.programNumber = programNumber;
            this.casterName = casterName;
            this.vesselNumber = vesselNumber;
            this.isPlanningBlock = isPlanning;
            this.grade = grade;
            this.ladleNo = ladleNo;

            if (!this.endTime.HasValue && EventShouldHaveEnded())//Check if Event should have ended
                AddFalseEndTime();

            if (this.endTime.HasValue)//Has value therefore event has ended and not in progress
                this.isInProgress = false;
            else
                this.isInProgress = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Checks if the event should have ended by now
        /// </summary>
        /// <returns>Boolean stating whether or not event should have ended.</returns>
        private bool EventShouldHaveEnded()
        {
            TimeSpan tsExpectedMaxLength = GetExpectedLength();
            //If time now exceeds the expected finish time
            if (DateTime.Now > this.startTime.Add(tsExpectedMaxLength))
            {
                return true;//Event should have finished
            }
            return false;//Event is possibly still in progress
        }

        /// <summary>
        /// Gets expected MAX length of process depending on the UnitID
        /// </summary>
        /// <returns>TimeSpan of expected maximum length for process.</returns>
        private TimeSpan GetExpectedLength()
        {
            if (this.unitId < 7)//Hot Metal, Desulph and Vessels
            {
                return new TimeSpan(1, 0, 0);
            }
            else if (this.unitId < 11)//RH, RD and CAS
            {
                return new TimeSpan(1, 30, 0);
            }
            else if (this.unitId < 14)//Casters
            {
                return new TimeSpan(2, 0, 0);
            }
            else
            {
                return new TimeSpan(0, 0, 0);//Error
            }
        }

        /// <summary>
        /// Give the event a false end time as it has exceeded the
        /// recommended maximum time for that Unit
        /// </summary>
        private void AddFalseEndTime()
        {
            this.endTime = this.startTime.AddHours(0.5);
            this.isFalseEndTime = true;
        }
        #endregion
    }
}
