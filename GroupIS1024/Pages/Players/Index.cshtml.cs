﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupIS1024.Data;
using GroupIS1024.Models;

namespace GroupIS1024.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly GroupIS1024.Data.GroupIS1024Context _context;

        public IndexModel(GroupIS1024.Data.GroupIS1024Context context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Player != null)
            {
                Player = await _context.Player
                .Include(p => p.Team).ToListAsync();
            }
        }
    }
}
