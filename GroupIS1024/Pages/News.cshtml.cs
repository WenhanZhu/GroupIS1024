using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace GroupIS1024.Pages
{
    public class NewsModel : PageModel
    {

        static readonly HttpClient client = new HttpClient();
        public void OnGet()
        {


            var task = client.GetAsync("https://inshorts.deta.dev/news?category=sports");
            HttpResponseMessage result = task.Result;
            List<Sport> sports = new List<Sport>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                    NewsFeed newsfeed = Sport.FromJson(jsonString);
                    sports = newsfeed.Data;
                
            }

            ViewData["Sports"] = sports;
        }
    }
}
