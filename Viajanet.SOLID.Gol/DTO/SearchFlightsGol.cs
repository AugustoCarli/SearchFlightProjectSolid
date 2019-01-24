using System.Collections.Generic;
using System.Linq;
using Viajanet.SOLID.Domain.Domain;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;

namespace Viajanet.SOLID.Gol.Domain
{
    public class SearchFlightsGol : ISearchFlights
    {
        private readonly IList<GolFlights> _flights;

        public SearchFlightsGol(string pathFile)
        {
            _flights = ReadJson.Read(pathFile);
        }

        public List<Flights> SearchIATA(string origem, string destino)
        {
            return ParserList(_flights.Where(x => x.Herkunft.IATA == origem && x.Ziel.IATA == destino));
        }

        private static List<Flights> ParserList(IEnumerable<GolFlights> golFlights)
        {
            var Flights = new List<Flights>();

            foreach (var golFlight in golFlights)
            {
                if (golFlights.Count() > 0)
                {
                    var flight = new Flights();
                    flight.Date = golFlight.Datum;
                    flight.Arrival = new Locality { IATA = golFlight.Ziel.IATA, Name = golFlight.Ziel.Name };
                    flight.Departure = new Locality { IATA = golFlight.Herkunft.IATA, Name = golFlight.Herkunft.Name };
                    flight.Source = golFlight.Firma;
                    Flights.Add(flight);
                }
            }

            return Flights;
        }
    }
}
