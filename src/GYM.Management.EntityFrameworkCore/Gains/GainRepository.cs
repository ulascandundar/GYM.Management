using GYM.Management.EntityFrameworkCore;
using GYM.Management.MemberOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Gains
{
    public class GainRepository : EfCoreRepository<ManagementDbContext, Gain, Guid>, IGainRepository
    {
        public GainRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
