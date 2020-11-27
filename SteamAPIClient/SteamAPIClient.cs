using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Services
{
    public class HttpMethodConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not implemented yet");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return string.Empty;
            }
            else if (reader.TokenType == JsonToken.String)
            {
                return serializer.Deserialize(reader, objectType);
            }
            else
            {
                JObject obj = JObject.Load(reader);
                if (obj["Code"] != null)
                    return obj["Code"].ToString();
                else
                    return serializer.Deserialize(reader, objectType);
            }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }

    public class SteamAPIClient
    {
        public SteamAPIClient()
        {
            string jsonContent = File.ReadAllText("../../../SteamAPIClient/APIList.json");
            List<Interface> webCalls = JsonConvert.DeserializeObject<MainAPIObject>(jsonContent, new HttpMethodConverter()).Apilist.Interfaces.ToList();
            foreach (var call in webCalls)
            {
                Console.WriteLine(call.Name);
                foreach (var m in call.Methods)
                    Console.WriteLine($"\t{m.Name}: {m.Description}");
            }

        }
    }


    public class MainAPIObject
    {
        public ApiList Apilist { get; set; }
    }

    public class ApiList
    {
        public Interface[] Interfaces { get; set; }
    }

    public class Interface
    {
        public string Name { get; set; }
        public Method[] Methods { get; set; }
    }

    public class Method
    {
        public string Name { get; set; }
        public int Version { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public Parameter[] Parameters { get; set; }
        public string Description { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Optional { get; set; }
        public string Description { get; set; }
    }

}
