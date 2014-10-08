using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data
{
    public class Tee
    {
        public Tee()
        {
        }

        public int TeeId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Slope { get; set; }
        public Nullable<decimal> Rating { get; set; }
        public int Yardage { get; set; }

        public  ICollection<Hole> Holes { get; set; }

    }
}