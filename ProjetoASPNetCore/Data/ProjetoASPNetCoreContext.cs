using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoASPNetCore.Models;

namespace ProjetoASPNetCore.Data
{
    public class ProjetoASPNetCoreContext : DbContext
    {
        public ProjetoASPNetCoreContext (DbContextOptions<ProjetoASPNetCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Departament>? Departament { get; set; }
        public DbSet<Seller>? Seller { get; set; }
        public DbSet<SalesRecord>? SalesRecord { get; set; }
    }
}
