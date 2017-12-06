using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OneOff.Data.Entities;
using OneOff.Models.Resources;

namespace vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  DOMAIN TO API RESOURCE
            CreateMap<Venue, VenueCreateResource>();

        }
}
