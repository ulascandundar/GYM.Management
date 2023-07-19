using GYM.Management.EntityFrameworkCore;
using GYM.Management.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.MemberOrders
{
    public class MemberOrderRepository : EfCoreRepository<ManagementDbContext, MemberOrder, Guid>, IMemberOrderRepository
    {
        public MemberOrderRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
