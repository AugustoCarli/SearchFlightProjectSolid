using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajanet.SOLID.Domain.Domain;

namespace Viajanet.SOLID.Domain.Interfaces
{
    public interface IValidationRecomendationService
    {
        bool Validate(List<Flights> flights, string origem, string destino);
    }
}
