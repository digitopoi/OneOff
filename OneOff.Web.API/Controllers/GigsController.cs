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

namespace OneOff.Web.API.Controllers
{
    public class GigsController : ApiController
    {
        private OneOffEntities db = new OneOffEntities();

        // GET: api/Gigs
        public IQueryable<Gig> GetGigs()
        {
            return db.Gigs;
        }

        // GET: api/Gigs/5
        [ResponseType(typeof(Gig))]
        public async Task<IHttpActionResult> GetGig(int id)
        {
            Gig gig = await db.Gigs.FindAsync(id);
            if (gig == null)
            {
                return NotFound();
            }

            return Ok(gig);
        }

        // PUT: api/Gigs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGig(int id, Gig gig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gig.GigId)
            {
                return BadRequest();
            }

            db.Entry(gig).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GigExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Gigs
        [ResponseType(typeof(Gig))]
        public async Task<IHttpActionResult> PostGig(Gig gig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gigs.Add(gig);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GigExists(gig.GigId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gig.GigId }, gig);
        }

        // DELETE: api/Gigs/5
        [ResponseType(typeof(Gig))]
        public async Task<IHttpActionResult> DeleteGig(int id)
        {
            Gig gig = await db.Gigs.FindAsync(id);
            if (gig == null)
            {
                return NotFound();
            }

            db.Gigs.Remove(gig);
            await db.SaveChangesAsync();

            return Ok(gig);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GigExists(int id)
        {
            return db.Gigs.Count(e => e.GigId == id) > 0;
        }
    }
}