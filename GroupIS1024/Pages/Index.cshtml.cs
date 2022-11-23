using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

using System.Net;

namespace GroupIS1024.Pages
{
    public class IndexModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();



        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
    }
}