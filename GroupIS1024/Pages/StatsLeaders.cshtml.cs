using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {

            Query = query;
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://site.api.espn.com/apis/site/v2/sports/football/nfl/teams/1" + query);
            request.Method = HttpMethod.Get;
            HttpResponseMessage response = await client.SendAsync(request);
            Team