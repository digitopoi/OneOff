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
    public class RequestController : ApiController
    {
        private OneOffEntities db = new OneOffEntities();

        // GET: api/Request
        public IQueryable<Request> GetRequests()
        {
            return db.Requests;
        }

        // GET: api/Request/5
        [ResponseType(typeof(Request))]
        public async Task<IHttpActionResult> GetRequest(int id)
        {
            Request request = await db.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/Request/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRequest(int id, Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.RequestId)
            {
                return BadRequest();
            }

            db.Entry(request).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Request
        [ResponseType(typeof(Request))]
        public async Task<IHttpActionResult> PostRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requests.Add(request);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RequestExists(request.RequestId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = request.RequestId }, request);
        }

        // DELETE: api/Request/5
        [ResponseType(typeof(Request))]
        public async Task<IHttpActionResult> DeleteRequest(int id)
        {
            Request request = await db.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            db.Requests.Remove(request);
            await db.SaveChangesAsync();

            return Ok(request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(int id)
        {
            return db.Requests.Count(e => e.RequestId == id) > 0;
        }
    }
}