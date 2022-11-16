using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Collections;

namespace GroupIS1024.Pages
{
    public class StatsLeadersModel : PageModel
    {

        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<IndexModel> _logger;

        public StatsLeadersModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
      //  public void OnGet()
       // {

           // var task = client.GetAsync("https://sports.core.api.espn.com/v2/sports/football/leagues/nfl/leaders/0/");
          //  HttpResponseMessage result = task.Result;
            
           // if (result.IsSuccessStatusCode)
           // {
           // Task<string> readString = result.Content.ReadAsStringAsync();
          //  string jsonString = readString.Result;
             //   Leaderboard leaders = Leaderboard.FromJson(jsonString);
           // }
           // ViewData["Leaderboards"] = result;
       // }
        public string InitLeaderboardQuery { get; set; }

        public async Task OnGetAsync(string LeaderboardQuery)
        {



            InitLeaderboardQuery = LeaderboardQuery;

            HttpRequestMessage request1 = new HttpRequestMessage();
            request1.RequestUri = new Uri("https://sports.core.api.espn.com/v2/sports/football/leagues/nfl/leaders/0/" + LeaderboardQuery);
            request1.Method = HttpMethod.Get;
           // request1.Headers.Add("X-RapidAPI-Key", "f01592f829msh19c3e04e9fee763p158a76jsn20bf9661fd30");
            HttpResponseMessage response1 = await client.SendAsync(request1);
            Leaderboard leaderboards = new Leaderboard();

            if (response1.IsSuccessStatusCode)
            {
                Task<string> readString1 = response1.Content.ReadAsStringAsync();
                string jsonString1 = readString1.Result;

                System.Diagnostics.Debug.WriteLine("Value: " + jsonString1);
                leaderboards = Leaderboard.FromJson(jsonString1);
            }

            ViewData["Leaderboard"] = leaderboards;


        }
    }
}
