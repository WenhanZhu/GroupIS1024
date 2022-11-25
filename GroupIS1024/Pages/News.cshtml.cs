using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupIS1024.Pages
{
    public class NewsModel : PageModel
    {

        static readonly HttpClient client = new HttpClient();


        private readonly ILogger<IndexModel> _logger;

        public NewsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {

            Query = query;

            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://inshorts.deta.dev/news?category=" + query);
            request.Method = HttpMethod.Get;
            //request.Headers.Add("X-Api-Key", "HnbsldX1Z3abqOl+zT7ySw==rpv1LaFBH0Ibgt3q");
            HttpResponseMessage response = await client.SendAsync(request);
            NewsFeed newsfeeds = new NewsFeed();

            if (response.IsSuccessStatusCode)
            {
                Task<string> readString = response.Content.ReadAsStringAsync();
                string jsonString = readString.Result;

                System.Diagnostics.Debug.WriteLine("Value: " + jsonString);
                newsfeeds = NewsFeed.FromJson(jsonString);
            }

            ViewData["Nutritions"] = newsfeeds;
        }
    }
}
