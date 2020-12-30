using Microsoft.EntityFrameworkCore;
using Ruleta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruleta.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Models.Ruleta> Ruleta { get; set; }
        public DbSet<Apuesta> Apuesta { get; set; }
    }
}
