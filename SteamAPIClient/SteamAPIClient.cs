using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Services
{
    public class SteamAPIClient
    {
        public SteamAPIClient()
        {
            string jsonContent = File.ReadAllText("../../../SteamAPIClient/APIList.json");
            List<Interface> webCalls = JsonConvert.DeserializeObject<GameTracker.Services.MainAPIObject>(jsonContent).apilist.interfaces.ToList();
            foreach (var call in webCalls)
                Console.WriteLine();
        }
    }


    public class MainAPIObject
    {
        public ApiList apilist { get; set; }
    }

    public class ApiList
    {
        public Interface[] interfaces { get; set; }
    }

    public class Interface
    {
        public string name { get; set; }
        public Method[] methods { get; set; }
    }

    public class Method
    {
        public string name { get; set; }
        public int version { get; set; }
        public string httpmethod { get; set; }
        public Parameter[] parameters { get; set; }
        public string description { get; set; }
    }

    public class Parameter
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool optional { get; set; }
        public string description { get; set; }
    }

}
