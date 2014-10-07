using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data
{
    public class Facility
    {
        public Facility()
        {
            //this.Courses = new HashSet<Course>();
        }

        public int FacilityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}