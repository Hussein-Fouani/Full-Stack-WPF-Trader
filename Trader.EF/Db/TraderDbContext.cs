using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trader.EF.Db
{
    public class TraderDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransactions> AssetTransactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransactions>().OwnsOne(s=>s.Stock);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TraderDb;Trusted_Connection=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
   
}
