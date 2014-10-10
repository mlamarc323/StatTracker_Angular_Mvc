using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StatTracker_Angular_Mvc.Data;
using StatTracker_Angular_Mvc.Data.Models;

namespace StatTracker_Angular_Mvc.Controllers
{
    public class CourseController : ApiController
    {
        private DataModelRepository _repo;

        public CourseController()
        {
            _repo = new DataModelRepository(new DataModelContext());
        }

        public IEnumerable<Course> Get()
        {
            return _repo.GetCourses();
        }

        public IEnumerable<Course> Get(int id)
        {
            IEnumerable<Course> results;
            results = _repo.GetCourseById(id);
            return results;
        }

        [HttpGet]
        public IEnumerable<Tee> Tees(int courseId)
        {
            IEnumerable<Tee> results;
            results = _repo.GetTeesForCourses(courseId);
            return results;
        }
    }
}
