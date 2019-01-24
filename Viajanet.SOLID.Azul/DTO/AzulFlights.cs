using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viajanet.SOLID.Azul.Domain
{
    public class AzulFlights
    {
        public AzulLocations Origem { get; set; }
        public AzulLocations Destino { get; set; }
        public string Compania { get; set; }
        public DateTime Data { get; set; }
    }
}
