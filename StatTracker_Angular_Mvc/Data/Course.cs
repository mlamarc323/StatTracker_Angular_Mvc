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
            //this.Tees = new HashSet<Tee>();
        }
    
        public int CourseId { get; set; }
        public int FacilityId { get; set; }
        public string Name { get; set; }
    
        public virtual Facility Facility { get; set; }
        //public virtual ICollection<Tee> Tees { get; set; 
    }
}