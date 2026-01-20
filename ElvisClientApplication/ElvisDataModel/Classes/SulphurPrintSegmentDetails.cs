using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElvisDataModel.Classes
{
    public class SulphurPrintSegmentDetails
    {
        public string Segment { get; set; }
        public string ICAssessment { get; set; }
        public DateTime DateInstalled { get; set; }
        public int DaysInService { get; set; }
        public float TonnesCast { get; set; }

        public float GreenLookup { get; set; }
        public float RedLookup { get; set; }
    }
}
