using Microsoft.EntityFrameworkCore;
using OwnApropos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos
{
    public class MementoMoriContext: DbContext
    {
        public DbSet<Fillial> Fillials { get; set; } = null!;
        public DbSet<BudgetHistory> BudgetHistories { get; set; } = null!;
        public DbSet<Personal> Personals { get; set; } = null!;
        public DbSet<Inventory> Inventories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=memento_mori;Trusted_Connection=True;");
        }
    }
}
