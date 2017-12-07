using OneOff.Web.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOff.Models.Resources;
using OneOff.Data.Entities;

namespace OneOff.Services
{
    public class RequestService : IRequestService
    {
        public bool CreateRequest(RequestResource request)
        {
            var entity =
                new Request()
                {
                    Date = request.Date,
                    Offer = request.Offer,
                    VenueId = request.VenueId
                };

            using (var context = new OneOffEntities())
            {
                Venue venue = context
                                     .Venues
                                     .SingleOrDefault(v => v.VenueId == entity.VenueId);

                venue.Requests.Add(entity);
                context.Requests.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteRequest(int id)
        {
            using (var context = new OneOffEntities())
            {
                var entity = context
                                    .Requests
                                    //  TODO: check ownership
                                    .SingleOrDefault(e => e.RequestId == id);

                context.Requests.Remove(entity);
                return context.SaveChanges() == 1;
            }
        }

        public RequestResource GetRequestById(int id)
        {
            using (var context = new OneOffEntities())
            {
                var entity = context
                                   .Requests
                                   //  TODO: check ownership
                                   .SingleOrDefault(e => e.RequestId == id);

                return
                    new RequestResource
                    {
                        Date = entity.Date,
                        Offer = entity.Offer,
                        VenueId = entity.VenueId
                    };
            }
        }

        public IEnumerable<RequestResource> GetRequests()
        {
            using (var context = new OneOffEntities())
            {
                var query = context
                                    .Requests
                                    .Select(
                                        e =>
                                            new RequestResource
                                            {
                                                Date = e.Date,
                                                Offer = e.Offer,
                                                VenueId = e.VenueId
                                            }
                                    );

                return query.ToArray();
            }
        }

        public bool UpdateRequest(int id, RequestUpdateResource request)
        {
            using (var context = new OneOffEntities())
            {
                var entity = context
                                   .Requests
                                   .SingleOrDefault(e => e.RequestId == id);

                entity.Date = request.Date;
                entity.Offer = request.Offer;

                return context.SaveChanges() == 1;
            }
        }
    }
}
