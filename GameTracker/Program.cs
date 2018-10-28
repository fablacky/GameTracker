using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string SteamKey = "F1B4C7CA29E7DEC50D5F81357DC09CE5";
            string SteamID = "76561197971749060";
            string SteamIDPaolo = "76561197994867585";
            string baseURL = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={SteamKey}&steamids={SteamIDPaolo}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(baseURL).Result;
            string viewResult = response.Content.ReadAsStringAsync().Result;
            Player rObject = JsonConvert.DeserializeObject<Rootobject>(viewResult).response.players[0];
        }
    }
}
public class Rootobject
{
    public Response response { get; set; }
}

public class Response
{
    public Player[] players { get; set; }
}

public class Player
{
    public string steamid { get; set; }
    public int communityvisibilitystate { get; set; }
    public int profilestate { get; set; }
    public string personaname { get; set; }
    public int lastlogoff { get; set; }
    public string profileurl { get; set; }
    public string avatar { get; set; }
    public string avatarmedium { get; set; }
    public string avatarfull { get; set; }
    public int personastate { get; set; }
    public string realname { get; set; }
    public string primaryclanid { get; set; }
    public int timecreated { get; set; }
    public int personastateflags { get; set; }
    public string loccountrycode { get; set; }
    public string locstatecode { get; set; }
    public int loccityid { get; set; }
}

