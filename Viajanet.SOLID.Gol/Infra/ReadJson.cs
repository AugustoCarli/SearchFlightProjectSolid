using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Viajanet.SOLID.Gol.DTO;

namespace Viajanet.SOLID.Gol.Infra
{
    public class ReadJson
    {
        public static List<GolFlights> Read(string pathFile)
        {
            var jsonGol = File.ReadAllText(pathFile);

            return JsonConvert.DeserializeObject<List<GolFlights>>(jsonGol);
        }
    }
}
