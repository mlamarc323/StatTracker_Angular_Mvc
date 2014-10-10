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
    public class TeeController : ApiController
    {
        private DataModelRepository _repo;

        public TeeController()
        {
            _repo = new DataModelRepository(new DataModelContext());
        }

        public IEnumerable<Tee> Get()
        {
            return _repo.GetTees();
        }

        public IEnumerable<Tee> Get(int courseId)
        {
            IEnumerable<Tee> results;
            results = _repo.GetTeesForCourses(courseId);
            return results;
        }
    }
}
