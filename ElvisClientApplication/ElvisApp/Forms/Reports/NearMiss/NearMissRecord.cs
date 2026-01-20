using System;

namespace Elvis.Forms.Reports.NearMiss
{

    public class NearMissRecord
    {
        public int No { get; set; }
        public string Initiator { get; set; }
        public string Rota { get; set; }
        public string NearMissType { get; set; }
        public DateTime Date { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
