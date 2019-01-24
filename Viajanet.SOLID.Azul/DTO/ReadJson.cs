using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Viajanet.SOLID.Azul.Domain;

namespace Viajanet.SOLID.Azul
{
    public class ReadJson
    {
        public static List<AzulFlights> Read(string pathFile)
        {
            var jsonAzul = File.ReadAllText(pathFile);

            return JsonConvert.DeserializeObject<List<AzulFlights>>(jsonAzul);
        }
    }
}
