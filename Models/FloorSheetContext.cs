using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientApi.Models;

    public class FloorSheetContext : DbContext
    {
        public FloorSheetContext (DbContextOptions<FloorSheetContext> options)
            : base(options)
        {
        }

        public DbSet<ClientApi.Models.FloorSheet> FloorSheet { get; set; } = default!;
    }
