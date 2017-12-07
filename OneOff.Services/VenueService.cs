using OneOff.Data.Entities;
using OneOff.Models.Resources;
using System.Web.ModelBinding;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace OneOff.Services
{
    public class VenueService
    {
        public async Task<bool> CreateVenue(VenueCreateResource venue)
        {
            var entity =
                new Venue()
                {
                    Name = venue.Name,
                    Description = venue.Description,
                    PostalCode = venue.PostalCode
                };

            using (var ctx = new OneOffEntities())
            {
                ctx.Venues.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
