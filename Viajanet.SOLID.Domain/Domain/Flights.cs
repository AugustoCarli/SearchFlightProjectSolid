using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajanet.SOLID.Domain.Domain
{   
    public class Flights
    {
        public Locality Arrival { get; set; }
        public Locality Departure { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }

    }
}
