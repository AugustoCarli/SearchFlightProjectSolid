using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajanet.SOLID.Latam.Domain
{
    public class LatamFlights
    {
        public LatamLocations Origen { get; set; }
        public LatamLocations Destinos { get; set; }
        public string Empresa { get; set; }
        public DateTime Fecha { get; set; }
    }
}
