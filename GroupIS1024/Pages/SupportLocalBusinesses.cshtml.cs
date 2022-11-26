using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupIS1024.Pages
{
    public class SupportLocalBusinessesModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public void OnGet()
        {


            var task = client.GetAsync("https://uchef20221121194020.azurewebsites.net/chefauthors");
            HttpResponseMessage result = task.Result;
            List<ChefAuthor> chefauthors = new List<ChefAuthor>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                chefauthors = ChefAuthor.FromJson(jsonString);

            }

            ViewData["Chef Authors"] = chefauthors;
        }
    }
}