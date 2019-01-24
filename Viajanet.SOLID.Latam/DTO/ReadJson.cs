using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Viajanet.SOLID.Latam.Domain;

namespace Viajanet.SOLID.Latam
{
    public class ReadJson 
    {
        public static List<LatamFlights> Read(string pathFile)
        {
            var jsonLatam = File.ReadAllText(pathFile);

            return JsonConvert.DeserializeObject<List<LatamFlights>>(jsonLatam);
        }
    }
}
