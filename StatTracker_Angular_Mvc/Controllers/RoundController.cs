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
    public class RoundController : ApiController
    {
        private DataModelRepository _repo;

        public RoundController()
        {
            _repo = new DataModelRepository(new DataModelContext());
        }

        public IEnumerable<Round> Get()
        {
            IEnumerable<Round> results;
            results = _repo.GetRounds();
            return results;
        }

        public HttpResponseMessage Post([FromBody]Round newRound)
        {
            if (_repo.AddRound(newRound) &&
                _repo.Save())
            {
                return Request.CreateResponse();
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage Delete(int id)
        {
            if (_repo.DeleteRound(id) &&
                _repo.Save())
            {
                return Request.CreateResponse();
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
