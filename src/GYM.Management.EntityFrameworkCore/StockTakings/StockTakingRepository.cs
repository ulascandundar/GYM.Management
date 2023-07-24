using GYM.Management.EntityFrameworkCore;
using GYM.Management.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.StockTakings
{
    public class StockTakingRepository : EfCoreRepository<ManagementDbContext, StockTaking, Guid>, IStockTakingRepository
    {
        public StockTakingRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
