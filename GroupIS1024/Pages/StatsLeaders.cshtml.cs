using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Net;

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
        public void OnGet()
        {
            var task = client.GetAsync("https://site.api.espn.com/apis/site/v2/sports/football/nfl/teams/1");
            HttpResponseMessage result = task.Result;
            List<FranchiseTeam> franchiseteams = new List<FranchiseTeam>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                franchiseteams = FranchiseTeam.FromString(jsonString);
            }
            ViewData["Franchises"] = franchiseteams;
        }


        }
    }

