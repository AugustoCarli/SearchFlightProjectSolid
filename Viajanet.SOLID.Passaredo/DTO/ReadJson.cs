using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Viajanet.SOLID.Passaredo.Domain;

namespace Viajanet.SOLID.Passaredo
{
    public class ReadJson
    {
        public static List<PassaredoFlights> Read(string pachFile)
        {
            var jsonPassaredo = File.ReadAllText(pachFile);

            return JsonConvert.DeserializeObject<List<PassaredoFlights>>(jsonPassaredo);
        }
    }
}