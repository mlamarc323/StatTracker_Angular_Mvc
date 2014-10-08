using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data
{
    public class Course
    {
        public Course()
        {
        }
    
        public int CourseId { get; set; }
        public int FacilityId { get; set; }
        public string Name { get; set; }

        public ICollection<Tee> Tees { get; set; }
    }
}