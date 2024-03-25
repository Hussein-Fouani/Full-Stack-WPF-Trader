using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.EF.Db;

namespace Trader.EF
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<TraderDbContext>
    {
        public TraderDbContext CreateDbContext(string[] args=null)
        {
            var options = new DbContextOptionsBuilder<TraderDbContext>()
                .UseSqlServer("Server=.;Database=TraderDb;Trusted_Connection=True;TrustServerCertificate = True;");
                return new TraderDbContext(options.Options);
        }
    }
}
