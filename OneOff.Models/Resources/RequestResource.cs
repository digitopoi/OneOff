using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Models.Resources
{
    public class RequestResource
    {
        public DateTime Date { get; set; }
        public decimal Offer { get; set; }
        public int VenueId { get; set; }
    }
}
