using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

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
                JSchema schema = JSchema.Parse(System.IO.File.ReadAllText("chefauthorschema.json"));
                JArray jsonArray = JArray.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                    if (jsonArray.IsValid(schema, out validationEvents)) { 
                 chefauthors = ChefAuthor.FromJson(jsonString);
            } else
                {
                    foreach(string evt in validationEvents) {
                        Console.WriteLine(evt);
                    }
                }
            }

            ViewData["Chef Authors"] = chefauthors;
        }
    }
}