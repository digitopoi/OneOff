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
    public class ArtistService : IArtistService
    {
        public async Task<bool> CreateArtist(ArtistResource artist)
        {
            var entity =
                new Artist()
                {
                    Name = artist.Name,
                    Description = artist.Description
                };

            using (var ctx = new OneOffEntities())
            {
                ctx.Artists.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
