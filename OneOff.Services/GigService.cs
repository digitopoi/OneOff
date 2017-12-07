using OneOff.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOff.Models.Resources;
using OneOff.Data.Entities;
using System.Data.Entity;

namespace OneOff.Services
{
    public class GigService : IGigService
    {
        public async Task<bool> CreateGig(GigResource gig)
        {
            var entity =
                new Gig()
                {
                    Date = gig.Date,
                    PostalCode = gig.PostalCode,
                    ArtistId = gig.ArtistId
                };

            using (var context = new OneOffEntities())
            {
                context.Gigs.Add(entity);
                return await context.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteGig(int id)
        {
            using (var context = new OneOffEntities())
            {
                var entity = context
                                    .Gigs
                                    //  TODO: check ownership
                                    .Single(e => e.GigId == id);

                context.Gigs.Remove(entity);
                return await context.SaveChangesAsync() == 1;
            }
        }

        public async Task<GigResource> GetGigById(int id)
        {
            using (var context = new OneOffEntities())
            {
                var entity = await context
                                          .Gigs
                                          //  TODO: check ownership
                                          .SingleOrDefaultAsync(e => e.GigId == id);

                return
                    new GigResource
                    {
                        Date = entity.Date,
                        PostalCode = entity.PostalCode,
                        ArtistId = entity.ArtistId
                    };
            }
        }

        public async Task<IEnumerable<GigResource>> GetGigs()
        {
            using (var context = new OneOffEntities())
            {
                var query = await
                    context
                            .Gigs
                            .Select(
                                e =>
                                    new GigResource
                                    {
                                        Date = e.Date,
                                        PostalCode = e.PostalCode,
                                        ArtistId = e.ArtistId
                                    }
                            )
                            .ToArrayAsync();

                return query;
            }
        }

        public async Task<bool> UpdateGig(GigUpdateResource gig)
        {
            using (var context = new OneOffEntities())
            {
                var entity = await context
                                        .Gigs
                                        .SingleOrDefaultAsync(e => e.GigId == gig.GigId);

                entity.Date = gig.Date;
                entity.PostalCode = gig.PostalCode;

                return await context.SaveChangesAsync() == 1;
            }
        }
    }
}
