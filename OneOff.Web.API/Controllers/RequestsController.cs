using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OneOff.Data.Entities;
using OneOff.Services;
using OneOff.Models.Resources;

namespace OneOff.Web.API.Controllers
{
    public class RequestsController : ApiController
    {
        // GET: api/Requests
        public IHttpActionResult GetRequests()
        {
            var requestService = new RequestService();
            var requests = requestService.GetRequests();
            return Ok(requests);
        }

        // GET: api/Requests/5
        [ResponseType(typeof(RequestResource))]
        public IHttpActionResult GetRequest(int id)
        {
            var requestService = new RequestService();
            var request = requestService.GetRequestById(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/Requests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequest(int id, RequestUpdateResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requestService = new RequestService();

            if (!requestService.UpdateRequest(id, request))
                return InternalServerError();

            return Ok();
        }

        // POST: api/Requests
        [ResponseType(typeof(RequestResource))]
        public IHttpActionResult PostRequest(RequestResource request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var requestService = new RequestService();
            if (!requestService.CreateRequest(request))
                return InternalServerError();

            return Ok();
        }

        // DELETE: api/Requests/5
        [ResponseType(typeof(RequestResource))]
        public IHttpActionResult DeleteRequest(int id)
        {
            var requestService = new RequestService();

            if (!requestService.DeleteRequest(id))
                return InternalServerError();

            return Ok();
        }

    }
}