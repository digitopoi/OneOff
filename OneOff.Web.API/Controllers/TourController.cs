﻿using System;
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
    public class TourController : ApiController
    {
        private OneOffEntities db = new OneOffEntities();

        // GET: api/Tour
        public IQueryable<Tour> GetTours()
        {
            return db.Tours;
        }

        // GET: api/Tour/5
        [ResponseType(typeof(Tour))]
        public async Task<IHttpActionResult> GetTour(int id)
        {
            Tour tour = await db.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }

        // PUT: api/Tour/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTour(int id, Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tour.TourId)
            {
                return BadRequest();
            }

            db.Entry(tour).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // POST: api/Tour
        [ResponseType(typeof(Tour))]
        public async Task<IHttpActionResult> PostTour(Tour tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tours.Add(tour);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TourExists(tour.TourId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tour.TourId }, tour);
        }

        // DELETE: api/Tour/5
        [ResponseType(typeof(Tour))]
        public async Task<IHttpActionResult> DeleteTour(int id)
        {
            Tour tour = await db.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            db.Tours.Remove(tour);
            await db.SaveChangesAsync();

            return Ok(tour);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourExists(int id)
        {
            return db.Tours.Count(e => e.TourId == id) > 0;
        }
    }
}