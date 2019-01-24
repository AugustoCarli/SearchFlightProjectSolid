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
    public class ValidationRecomendationService : IValidationRecomendationService
    {
        bool _exist;
        
        public bool Validate(List<Flights> flights, string origem, string destino)
        {
            _exist = flights.Any(x => x.Arrival.IATA == destino && x.Departure.IATA == origem);

            if (_exist != true)
            {
                throw new ArgumentException("Esta Viajem ainda não existe");
            }
            return _exist;
        }
    }
}
