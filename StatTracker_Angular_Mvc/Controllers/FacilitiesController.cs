using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StatTracker_Angular_Mvc.Data;
using StatTracker_Angular_Mvc.Models;

namespace StatTracker_Angular_Mvc.Controllers
{
    public class FacilitiesController : ApiController
    {
        private DataModelRepository _repo;

        public FacilitiesController(DataModelRepository repo)
        {
            _repo = repo;
        }

        public IQueryable<Facility> Get(bool includeCourses = false)
        {
            IQueryable<Facility> results;
            if (includeCourses == true)
            {
                results = _repo.GetFacilitiesWithCourses();
            }
            else
            {
                results = _repo.GetFacilities();
            }
            return results;
        }

        public IEnumerable<Facility> Get(int id)
        {
            IQueryable<Facility> results;
            results = _repo.GetFacility(id);
            return results;
        }
    }
}