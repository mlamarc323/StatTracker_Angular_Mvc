using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Http;

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
            return _ctx.Facilities.Include("courses");
        }

        public IQueryable<Facility> GetFacilitiesWithEverything()
        {
            return _ctx.Facilities.Include("Courses.Tees.Holes");
        }

        public bool AddFacility(Facility newFacility)
        {
            try
            {
                _ctx.Facilities.Add(newFacility);
                return true;
            }
            catch (Exception ex)
            {
                // TODO log this error
                return false;
            }
        }

        public bool DeleteFacility(int facilityId)
        {
            try
            {
                var facility = _ctx.Facilities.Find(facilityId);
                if (facility == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    _ctx.Facilities.Remove(facility);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                // TODO log this error
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                // TODO log this error
                return false;
            }
        }

    }
}