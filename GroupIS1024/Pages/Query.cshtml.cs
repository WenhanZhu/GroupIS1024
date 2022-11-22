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
    public class QueryModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();


        private readonly ILogger<IndexModel> _logger;

        public QueryModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string initTeamQuery { get; set; }

        
        }
    }
