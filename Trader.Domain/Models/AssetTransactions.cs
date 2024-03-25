using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.Domain.Models
{
    public class AssetTransactions
    {
        public Guid Id { get; set; }
        public Account Account { get; set; }
        public Stock Stock { get; set; }
        public bool IsPurchased { get; set; }
        public double ShareAmount { get; set; }
      
    }
}
