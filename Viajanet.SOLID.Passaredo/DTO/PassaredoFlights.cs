using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajanet.SOLID.Passaredo.Domain
{
    public class PassaredoFlights
    {
        public PassaredoLocations Origine { get; set; }
        public PassaredoLocations Destination { get; set; }
        public string Compagnie { get; set; }
        public DateTime Dates { get; set; }
    }
}
