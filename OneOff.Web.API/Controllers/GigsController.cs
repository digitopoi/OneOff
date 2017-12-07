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
    public class GigsController : ApiController
    {

        // GET: api/Gigs
        // TODO: make async
        public IHttpActionResult GetGigs()
        {
            var gigService = new GigService();
            var gigs = gigService.GetGigs();
            return Ok(gigs);
        }

        // GET: api/Gigs/5
        [ResponseType(typeof(GigResource))]
        public IHttpActionResult GetGig(int id)
        {
            var gigService = new GigService();
            var gig = gigService.GetGigById(id);
            if (gig == null)
            {
                return NotFound();
            }

            return Ok(gig);
        }

        // PUT: api/Gigs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGig(int id, GigUpdateResource gig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gigService = new GigService();

            if (!gigService.UpdateGig(id, gig))
                return InternalServerError();

            return Ok();
        }

        // POST: api/Gigs
        [ResponseType(typeof(GigResource))]
        public IHttpActionResult PostGig(GigResource gig)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gigService = new GigService();
            if (!gigService.CreateGig(gig))
                return InternalServerError();

            return Ok();
        }

        // DELETE: api/Gigs/5
        [ResponseType(typeof(GigUpdateResource))]
        public IHttpActionResult DeleteGig(int id)
        {
            var gigService = new GigService();

            if (!gigService.DeleteGig(id))
                return InternalServerError();

            return Ok();
        }
    }
}