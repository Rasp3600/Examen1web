using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Examen1.Models;

namespace Examen1.Data
{
    public class Examen1Context : DbContext
    {
        public Examen1Context (DbContextOptions<Examen1Context> options)
            : base(options)
        {
        }

        public DbSet<Examen1.Models.Category> Category { get; set; } = default!;
        public DbSet<Examen1.Models.Supplier> Supplier { get; set; } = default!;
        public DbSet<Examen1.Models.Product> Product { get; set; } = default!;
    }
}
