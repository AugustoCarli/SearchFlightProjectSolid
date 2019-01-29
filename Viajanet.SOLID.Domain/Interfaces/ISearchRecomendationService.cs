using System.Collections.Generic;
using Viajanet.SOLID.Domain.Domain;

namespace Viajanet.SOLID.Domain.Interfaces
{
    public interface ISearchRecomendationService
    {
        IEnumerable<Flights> Search(string origem, string destino);
    }
}
