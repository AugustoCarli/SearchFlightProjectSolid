using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajanet.SOLID.Avianca.Domain;
using Viajanet.SOLID.Domain.Domain;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;

namespace Viajanet.SOLID.Avianca
{
    public class SearchFlightsAvianca : ISearchFlights
    {
        private readonly IList<AviancaFlights> _flights;
        
        public SearchFlightsAvianca(string pathFile)
        {
            _flights = ReadJson.Read(pathFile);
        }

        public List<Flights> SearchIATA(string origem, string destino)
        {
            return ParserList(_flights.Where(x => x.Arrival.IATA == destino && x.Departure.IATA == origem)); 
        }
                
        private static List<Flights> ParserList(IEnumerable<AviancaFlights> aviancaFlights)
        {
            var Flights = new List<Flights>();

            foreach (var aviancaFlight in aviancaFlights)
            {
                if (aviancaFlights.Count() > 0)
                {
                    var flight = new Flights();
                    flight.Date = aviancaFlight.Date;
                    flight.Arrival = new Locality { IATA = aviancaFlight.Arrival.IATA, Name = aviancaFlight.Arrival.Name };
                    flight.Departure = new Locality { IATA = aviancaFlight.Departure.IATA, Name = aviancaFlight.Departure.Name };
                    flight.Source = aviancaFlight.Source;
                    Flights.Add(flight);
                }

            }
            return Flights;
        }
    }
}
