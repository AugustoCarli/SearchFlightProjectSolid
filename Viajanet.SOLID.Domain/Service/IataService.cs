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
    public class IataService : IIataService
    {
        private static HashSet<string> _iatas = new HashSet<string> { "CGH","GRU","CPV", "GIG", "ROR", "NYC", "VCP" };


        public bool Validate(string origem, string destino)
        {

            if (!_iatas.Contains(origem) && !_iatas.Contains(destino))
            {
                throw new ArgumentException("Iata Inválida");
            }
            return true;
        }
    }
}
