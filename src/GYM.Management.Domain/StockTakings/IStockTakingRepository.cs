using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.StockTakings
{
    public interface IStockTakingRepository : IRepository<StockTaking, Guid>
    {
    }
}
