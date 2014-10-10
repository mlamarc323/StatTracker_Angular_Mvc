using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StatTracker_Angular_Mvc.Data;
using StatTracker_Angular_Mvc.Data.Models;
using StatTracker_Angular_Mvc.Models;

namespace StatTracker_Angular_Mvc.Controllers
{
    public class FacilitiesController : ApiController
    {
        private DataModelRepository _repo;

        public FacilitiesController()
        {
            _repo = new DataModelRepository(new DataModelContext());
        }

        //[Authorize]
        public IEnumerable<Facility> Get(bool includeCourses = false, bool includeEverything = false)
        {
            IEnumerable<Facility> results;
            if (includeCourses)
            {
                results = _repo.GetFacilitiesWithCourses();
            }
            else if (includeEverything)
            {
                results = _repo.GetFacilitiesWithEverything();
            }
            else
            {
                results = _repo.GetFacilities();
            }

            IEnumerable<Facility> results2;
            results2 = results.ToList();

            return results2;
        }

        [HttpGet]
        public IEnumerable<Course> Courses(int facilityId)
        {
            IEnumerable<Course> results;
            results = _repo.GetCoursesForFacility(facilityId);
            return results;
        }



        public IEnumerable<Facility> Get(int id)
        {
            IQueryable<Facility> results;
            results = _repo.GetFacility(id);
            return results;
        }

        public HttpResponseMessage Post([FromBody]Facility newFacility)
        {
            if (_repo.AddFacility(newFacility) &&
                _repo.Save())
            {
                return Request.CreateResponse();
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage Delete(int id)
        {
            if (_repo.DeleteFacility(id) &&
                _repo.Save())
            {
                return Request.CreateResponse();
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}