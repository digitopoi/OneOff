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
        GigResource GetGigById (int id);
        bool CreateGig (GigResource gig);
        IEnumerable<GigResource> GetGigs ();
        bool UpdateGig (int id, GigUpdateResource gig);
        bool DeleteGig(int id);
    }
}
