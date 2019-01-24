using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajanet.SOLID.Domain.Domain;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;

namespace Viajanet.SOLID.Azul.Domain
{
    public class SearchFlightsAzul : ISearchFlights
    {
        private readonly IList<AzulFlights> _flights;

        public SearchFlightsAzul(string pathFile)
        {
            _flights = ReadJson.Read(pathFile);
        }

        public List<Flights> SearchIATA(string origem, string destino)
        {
            return ParserList(_flights.Where(x => x.Origem.IATA == origem && x.Destino.IATA == destino));
        }
        
        private static List<Flights> ParserList(IEnumerable<AzulFlights> azulFlights)
        {
            var Flights = new List<Flights>();

            foreach (var azulFlight in azulFlights)
            {
                if (azulFlights.Count() > 0)
                {
                    var flight = new Flights();
                    flight.Date = azulFlight.Data;
                    flight.Arrival = new Locality { IATA = azulFlight.Destino.IATA, Name = azulFlight.Destino.Nome };
                    flight.Departure = new Locality { IATA = azulFlight.Origem.IATA, Name = azulFlight.Origem.Nome };
                    flight.Source = azulFlight.Compania;
                    Flights.Add(flight);
                }
            }
            return Flights;
        }
    }
}
