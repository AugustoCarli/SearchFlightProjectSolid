using System.Collections.Generic;
using System.Linq;
using Viajanet.SOLID.Domain.Domain;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;
using Viajanet.SOLID.Latam.Domain;

namespace Viajanet.SOLID.Latam.DTO
{
    public class SearchFlightsLatam : ISearchFlights
    {
        private readonly List<LatamFlights> _flights;

        public SearchFlightsLatam(string pathFile)
        {
            _flights = ReadJson.Read(pathFile);
        }

        public List<Flights> SearchIATA(string origem, string destino)
        {
            return ParserList(_flights.Where(x => x.Origen.IATA == origem && x.Destinos.IATA == destino));
        }

        private static List<Flights> ParserList(IEnumerable<LatamFlights> latamFlights)
        {
            var Flights = new List<Flights>();

            foreach (var latamFlight in latamFlights)
            {
                if (latamFlights.Count() > 0)
                {
                    var flight = new Flights();
                    flight.Date = latamFlight.Fecha;
                    flight.Arrival = new Locality { IATA = latamFlight.Destinos.IATA, Name = latamFlight.Destinos.Nombre };
                    flight.Departure = new Locality { IATA = latamFlight.Origen.IATA, Name = latamFlight.Origen.Nombre };
                    flight.Source = latamFlight.Empresa;
                    Flights.Add(flight);
                }
            }

            return Flights;
        }
    }
}
