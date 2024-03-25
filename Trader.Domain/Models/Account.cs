using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public double Balance { get; set; }
        public List<AssetTransactions> AssetTransactions { get; set; }
    }
}
