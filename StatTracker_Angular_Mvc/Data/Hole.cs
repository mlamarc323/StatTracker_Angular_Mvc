using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data
{
    public class Hole
    {
        public int HoleId { get; set; }
        public int TeeId { get; set; }
        public int Number { get; set; }
        public Nullable<int> Yardage { get; set; }
        public Nullable<int> Par { get; set; }
        public Nullable<int> Handicap { get; set; }
    }
}