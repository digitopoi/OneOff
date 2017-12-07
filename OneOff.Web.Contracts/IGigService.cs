using OneOff.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Web.Contracts
{
    public interface IGigService
    {
        Task<GigResource> GetGigById (int id);
        Task<bool> CreateGig (GigResource gig);
        Task<IEnumerable<GigResource>> GetGigs ();
        Task<bool> UpdateGig (GigResource gig);
        Task<bool> DeleteGig(int id);
    }
}
