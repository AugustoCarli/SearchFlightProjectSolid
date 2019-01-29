using System.Collections.Generic;
using Viajanet.SOLID.Domain.Domain;
using Viajanet.SOLID.Domain.Interfaces;
using Viajanet.SOLID.Domain.Interfaces.ExternalServices;

namespace Viajanet.SOLID.Domain.Service
{
    public class SearchRecomendationService : ISearchRecomendationService
    {
        private readonly IIataService validation;
        private readonly IEnumerable<ISearchFlights> searchFlights;

        public SearchRecomendationService(IEnumerable<ISearchFlights> searchFlights, IIataService validation)
        {
            this.validation = validation;
            this.searchFlights = searchFlights;
        }

        public IEnumerable<Flights> Search(string origem, string destino)
        {
            List<Flights> flights = new List<Flights>();

            if (validation.Validate(origem, destino))
            {
                foreach (var item in searchFlights)
                {
                    flights.AddRange(item.SearchIATA(origem, destino));
                }
            }

            return flights;
        }
    }
}
