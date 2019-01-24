using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajanet.SOLID.Domain.Domain;

namespace Viajanet.SOLID.Domain.Interfaces.ExternalServices
{
    public interface ISearchFlights
    {
        List<Flights> SearchIATA(string origem, string destino);
    }
}
