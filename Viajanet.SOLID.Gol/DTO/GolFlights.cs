using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajanet.SOLID.Gol.DTO
{
    public class GolFlights
    {
        public GolLocations Herkunft { get; set; }
        public GolLocations Ziel { get; set; }
        public string Firma { get; set; }
        public DateTime Datum { get; set; }
    }
}
