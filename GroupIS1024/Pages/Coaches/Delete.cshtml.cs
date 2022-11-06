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
    public class DeleteModel : PageModel
    {
        private readonly GroupIS1024.Data.GroupIS1024Context _context;

        public DeleteModel(GroupIS1024.Data.GroupIS1024Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coach == null)
            {
                return NotFound();
            }
            var coach = await _context.Coach.FindAsync(id);

            if (coach != null)
            {
                Coach = coach;
                _context.Coach.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
