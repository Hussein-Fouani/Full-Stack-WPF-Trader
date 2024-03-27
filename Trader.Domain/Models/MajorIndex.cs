using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader.Domain.Models
{
    public enum MajorIndexType
    {
        DowJones,
        Nasdaq,
        SP500
    }
    public class MajorIndex
    {
        public MajorIndexType Type { get; set; }
        public string Name { get; set; }
        public double Changes { get; set; }
    }
}
