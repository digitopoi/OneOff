using OneOff.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Contracts
{
    public interface IRequestService
    {
        RequestResource GetRequestById(int id);
        bool CreateRequest(RequestResource request);
        IEnumerable<RequestResource> GetRequests();
        bool UpdateRequest(int id, RequestUpdateResource request);
        bool DeleteRequest(int id);
    }
}
