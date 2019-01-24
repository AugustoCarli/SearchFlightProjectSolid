using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajanet.SOLID.Domain.Domain;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;
using Viajanet.SOLID.Passaredo.Domain;

namespace Viajanet.SOLID.Passaredo.DTO
{
    public class SearchFlightsPassaredo : ISearchFlights
    {
        private readonly List<PassaredoFlights> _flights;

        public SearchFlightsPassaredo(string pachFile)
        {
            _flights = ReadJson.Read(pachFile);
        }

        public List<Flights> SearchIATA(string origem, string destino)
        {
            return ParserList(_flights.Where(x => x.Origine.IATA == origem && x.Destination.IATA == destino));
        }

        private static List<Flights> ParserList(IEnumerable<PassaredoFlights> passaredoFlights)
        {
            var Flights = new List<Flights>();

            foreach (var passaredoFlight in passaredoFlights)
            {
                if (passaredoFlights.Count() > 0)
                {
                    var flight = new Flights();
                    flight.Date = passaredoFlight.Dates;
                    flight.Arrival = new Locality { IATA = passaredoFlight.Origine.IATA, Name = passaredoFlight.Origine.Nom };
                    flight.Departure = new Locality { IATA = passaredoFlight.Destination.IATA, Name = passaredoFlight.Destination.Nom };
                    flight.Source = passaredoFlight.Compagnie;
                    Flights.Add(flight);
                }
            }
            return Flights;
        }
    }
}
