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
using OneOff.Models.Resources;
using OneOff.Services;

namespace OneOff.Web.API.Controllers
{
    public class VenuesController : ApiController
    {
        // POST: api/Venues
        [ResponseType(typeof(VenueCreateResource))]
        public async Task<IHttpActionResult> PostVenue(VenueCreateResource venue)
        {
            var venueService = new VenueService();
            await venueService.CreateVenue(venue);

            return Ok(venue);
        }

    }
}