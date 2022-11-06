using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupIS1024.Data;
using GroupIS1024.Models;

namespace GroupIS1024.Pages.Teams
{
    public class DeleteModel : PageModel
    {
        private readonly GroupIS1024.Data.GroupIS1024Context _context;

        public DeleteModel(GroupIS1024.Data.GroupIS1024Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FirstOrDefaultAsync(m => m.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }
            else 
            {
                Team = team;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Team == null)
            {
                return NotFound();
            }
            var team = await _context.Team.FindAsync(id);

            if (team != null)
            {
                Team = team;
                _context.Team.Remove(Team);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
