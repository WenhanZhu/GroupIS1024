using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroupIS1024.Pages
{
    public class TeamNameSuggestionsModel : PageModel
    {

        private IList<string> funTeamNames = new List<string>();
        public JsonResult OnGet(String term)
        {
            funTeamNames.Add("Winning Embiid");
            funTeamNames.Add("EnRaptored");
            funTeamNames.Add("Jrue Religeon");
            funTeamNames.Add("You Got Serbed");
            funTeamNames.Add("The Beal World");
            funTeamNames.Add("Spicy Curry");
            funTeamNames.Add("Bronny Bunch");
            funTeamNames.Add("Lowry Expectations");
            funTeamNames.Add("The Fantastic De’Aaron Fox");
            funTeamNames.Add("Making Booker");

            return new JsonResult(funTeamNames);
        }
    }
}
