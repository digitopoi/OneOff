using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneOff.Models.Resources
{
    public class GigUpdateResource
    {
        public int GigId { get; set; }
        public DateTime Date { get; set; }
        public string PostalCode { get; set; }
        public int ArtistId { get; set; }
    }
}
