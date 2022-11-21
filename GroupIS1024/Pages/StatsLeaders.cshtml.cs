using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
/*using System.Runtime.Serialization.Json;
*/
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
/*using System.Text.Json.Nodes;
*/
using System.Net.Http;
using System.Collections;
//using System.Text.Json;

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
        public string initTeamQuery { get; set; }

        public async Task OnGetAsync(string TeamQuery)
        {

            initTeamQuery = TeamQuery;

            HttpRequestMessage request1 = new HttpRequestMessage();
            request1.RequestUri = new Uri("https://site.api.espn.com/apis/site/v2/sports/football/nfl/teams/" + TeamQuery);
            request1.Method = HttpMethod.Get;
            //request1.Headers.Add("X-RapidAPI-Key", "NA");
            HttpResponseMessage response1 = await client.SendAsync(request1);
            Franchise franchises = new Franchise();
            if (response1.IsSuccessStatusCode)
            {
                Task<string> readString1 = response1.Content.ReadAsStringAsync();
                string jsonString1 = readString1.Result;

                System.Diagnostics.Debug.WriteLine("Value: " + jsonString1);
                franchises = Franchise.FromJson(jsonString1);
            }

            ViewData["Franchises"] = franchises;
        }
    }
}

