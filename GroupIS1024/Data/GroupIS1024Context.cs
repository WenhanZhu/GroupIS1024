using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupIS1024.Models;

namespace GroupIS1024.Data
{
    public class GroupIS1024Context : DbContext
    {
        public GroupIS1024Context (DbContextOptions<GroupIS1024Context> options)
            : base(options)
        {
        }

        public DbSet<GroupIS1024.Models.Player> Player { get; set; } = default!;

        public DbSet<GroupIS1024.Models.Team> Team { get; set; }

        public DbSet<GroupIS1024.Models.Coach> Coach { get; set; }
    }
}
