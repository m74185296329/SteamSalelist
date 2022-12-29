using System.Data;
using System.Net.Http.Headers;
using SteamSalelist;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
await ProcessRepositoriesAsync(client);
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
static async Task<string> ProcessRepositoriesAsync(HttpClient client)
{
    var json = await client.GetStringAsync(
        "https://api.steampowered.com/ISteamApps/GetAppList/v2/");
    return json; 
}


DataTableGeneration.SteamGames steamGames = JsonConvert.DeserializeObject<DataTableGeneration.SteamGames>(ProcessRepositoriesAsync(client).Result);
DataTableGeneration.GetJSONToDataTableUsingMethod(steamGames);
//DataTable dtjson = getjson.JSONstrToDataTable(Idlist.Result);
app.MapGet("/", () => "" );
app.Run();

