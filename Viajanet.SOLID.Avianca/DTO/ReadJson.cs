using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Viajanet.SOLID.Avianca.Domain;

namespace Viajanet.SOLID.Avianca
{
    public class ReadJson
    {
        public static IList<AviancaFlights> Read(string pathFile)
        {
            var jsonAvianca = File.ReadAllText(pathFile);

            return JsonConvert.DeserializeObject<List<AviancaFlights>>(jsonAvianca);
        }
    }

}
