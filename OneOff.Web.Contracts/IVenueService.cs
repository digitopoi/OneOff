using OneOff.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Web.Contracts
{
    public interface IVenueService
    {
        Task<bool> CreateVenue(VenueResource venue);
    }
}
