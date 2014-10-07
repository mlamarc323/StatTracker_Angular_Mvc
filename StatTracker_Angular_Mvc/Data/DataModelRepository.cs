using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatTracker_Angular_Mvc.Data
{
    public class DataModelRepository
    {
        private DataModelContext _ctx;

        public DataModelRepository(DataModelContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Facility> GetFacilities()
        {
            return _ctx.Facilities;
        }

        public IQueryable<Facility> GetFacility(int id)
        {
            return _ctx.Facilities.Where(x => x.FacilityId == id);
        }

        public IQueryable<Facility> GetFacilitiesWithCourses()
        {
            return _ctx.Facilities.Include("Courses");
        }

    }
}