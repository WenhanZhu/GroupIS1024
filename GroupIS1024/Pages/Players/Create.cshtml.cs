using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroupIS1024.Data;
using GroupIS1024.Models;

namespace GroupIS1024.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly GroupIS1024.Data.GroupIS1024Context _context;

        public CreateModel(GroupIS1024.Data.GroupIS1024Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "TeamId", "TeamId");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
