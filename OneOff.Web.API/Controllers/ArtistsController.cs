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
    public class ArtistsController : ApiController
    {
        // POST: api/Artists
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> PostArtist(ArtistCreateResource artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artistService = new ArtistService();
            await artistService.CreateArtist(artist);

            return Ok(artist);
        }

    }
}