using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajanet.SOLID.Domain.Domain;
using Viajanet.SOLID.Domain.Interfaces;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;

namespace Viajanet.SOLID.Domain.Service
{
    public class SearchRecomendationService : ISearchRecomendationService
    {
        private readonly IValidationRecomendationService validation;
        private readonly IEnumerable<ISearchFlights> searchFlights;

        public SearchRecomendationService(IEnumerable<ISearchFlights> searchFlights, IValidationRecomendationService validation)
        {
            this.validation = validation;
            this.searchFlights = searchFlights;
        }

        public void Search(string origem, string destino)
        {
            List<Flights> flights = AddList(origem, destino);

            try
            {
                validation.Validate(flights, origem, destino);

                foreach (var item in flights)
                {
                    Console.WriteLine("\n" + item.Departure.IATA);
                    Console.WriteLine(item.Departure.Name);
                    Console.WriteLine(item.Arrival.IATA);
                    Console.WriteLine(item.Arrival.Name);
                    Console.WriteLine(item.Date);
                    Console.WriteLine(item.Source + "\n");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<Flights> AddList(string origem, string destino)
        {
            List<Flights> flights = new List<Flights>();


            foreach (var item in searchFlights)
            {
                flights.AddRange(item.SearchIATA(origem, destino));
            }
            return flights;
        }
    }
}
