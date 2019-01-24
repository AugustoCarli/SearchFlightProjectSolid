using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajanet.SOLID.Avianca.Domain
{
    public class AviancaFlights
    {
        public AviancaLocations Departure { get; set; }
        public AviancaLocations Arrival { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }
    }
}
