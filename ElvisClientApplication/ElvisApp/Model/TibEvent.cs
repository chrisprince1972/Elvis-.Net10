using System;
using System.Collections.Generic;
using ElvisDataModel.EDMX;

namespace Elvis.Model
{
    [Serializable]
    /// <summary>
    /// A class to store the Tib Events
    /// </summary>
    public class TibEvent
    {
        public int TibIndex { get; set; }
        public int? HeatNumber { get; set; }
        public int? HeatNumberSet { get; set; }
        public int UnitNumber { get; set; }
        public int? UnitGroupNo { get; set; }
        public int? ProgramNumber { get; set; }
        public int? Grade { get; set; }
        public int? LadleNumber { get; set; }
        public int? TibStatus { get; set; }
        public int? Duration { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string PlantArea { get; set; }
        public List<TIBDelay> Delays { get; set; }
        public bool Ongoing { get; set; }
    }
}
