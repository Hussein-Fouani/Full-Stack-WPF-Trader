using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Models;

namespace Trader.EF.Db
{
    public class TraderDbContext:DbContext
    {
        public TraderDbContext(DbContextOptions<TraderDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransactions> AssetTransactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
    
   
}
