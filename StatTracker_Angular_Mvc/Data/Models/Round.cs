using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data.Models
{
    public class Round
    {
        public Round()
        {
            this.RoundDetails = new HashSet<RoundDetail>();
        }

        public int RoundId { get; set; }
        public int FacilityId { get; set; }
        public int CourseId { get; set; }
        public int TeeId { get; set; }
        public DateTime Date { get; set; }
        public bool Is_Official { get; set; }
        public bool Number_Of_Holes { get; set; }
        public bool HBH_Stats { get; set; }
        public int? TotalScore { get; set; }

        public virtual ICollection<RoundDetail> RoundDetails { get; set; }
    }
}