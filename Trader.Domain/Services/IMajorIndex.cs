using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trader.Domain.Models;

namespace Trader.Domain.Services
{
    public interface IMajorIndex
    {
        Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
    }
}
