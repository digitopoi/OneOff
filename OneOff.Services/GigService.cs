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
        public bool CreateGig(GigResource gig)
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
                Artist artist = context
                                        .Artists
                                        .SingleOrDefault(a => a.ArtistId == entity.ArtistId);

                artist.Gigs.Add(entity);
                context.Gigs.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteGig(int id)
        {
            using (var context = new OneOffEntities())
            {
                var entity = context
                                    .Gigs
                                    //  TODO: check ownership
                                    .SingleOrDefault(e => e.GigId == id);

                context.Gigs.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }

        public GigResource GetGigById(int id)
        {
            using (var context = new OneOffEntities())
            {
                var entity = context
                                   .Gigs
                                   //  TODO: check ownership
                                   .SingleOrDefault(e => e.GigId == id);

                return
                    new GigResource
                    {
                        Date = entity.Date,
                        PostalCode = entity.PostalCode,
                        ArtistId = entity.ArtistId
                    };
            }
        }

        public IEnumerable<GigResource> GetGigs()
        {
            using (var context = new OneOffEntities())
            {
                var query =  context
                                    .Gigs
                                    .Select(
                                        e =>
                                            new GigResource
                                            {
                                                Date = e.Date,
                                                PostalCode = e.PostalCode,
                                                ArtistId = e.ArtistId
                                            }
                                    );

                return query.ToArray();
            }
        }

        public bool UpdateGig(int id, GigUpdateResource gig)
        {
            using (var context = new OneOffEntities())
            {
                var entity = context
                                   .Gigs
                                   .SingleOrDefault(e => e.GigId == id);

                entity.Date = gig.Date;
                entity.PostalCode = gig.PostalCode;

                return context.SaveChanges() == 1;
            }
        }

    }
}
