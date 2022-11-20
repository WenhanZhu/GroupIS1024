using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupIS1024.Pages
{
    public class NFLOverviewModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;

        public NFLOverviewModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var task = client.GetAsync("https://site.api.espn.com/apis/site/v2/sports/football/nfl/teams");
            HttpResponseMessage result = task.Result;
            List<Franchise> franchises = new List<Franchise>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                franchises = Franchise.FromJson(jsonString);
            }
            ViewData["Franchises"] = franchises;
        }
    }
}
