using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
        public string DateProcessed { get; set; }
        public string Email { get; set; }
   
    }
}
