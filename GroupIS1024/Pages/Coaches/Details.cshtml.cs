using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupIS1024.Data;
using GroupIS1024.Models;

namespace GroupIS1024.Pages.Coaches
{
    public class DetailsModel : PageModel
    {
        private readonly GroupIS1024.Data.GroupIS1024Context _context;

        public DetailsModel(GroupIS1024.Data.GroupIS1024Context context)
        {
            _context = context;
        }

      public Coach Coach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coach == null)
            {
                return NotFound();
            }

            var coach = await _context.Coach.FirstOrDefaultAsync(m => m.CoachId == id);
            if (coach == null)
            {
                return NotFound();
            }
            else 
            {
                Coach = coach;
            }
            return Page();
        }
    }
}
