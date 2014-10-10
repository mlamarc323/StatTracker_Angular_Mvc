using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data.Models
{
    public class RoundDetail
    {
        public int RoundDetailId { get; set; }
        public int RoundId { get; set; }
        public int HoleId { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> Putts { get; set; }
        public Nullable<bool> GIR { get; set; }
        public Nullable<bool> FIR { get; set; }
    
    }
}