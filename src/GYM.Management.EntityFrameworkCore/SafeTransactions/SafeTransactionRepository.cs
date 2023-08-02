using GYM.Management.EntityFrameworkCore;
using GYM.Management.Safes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.SafeTransactions
{
    public class SafeTransactionRepository : EfCoreRepository<ManagementDbContext, SafeTransaction, Guid>, ISafeTransactionRepository
    {
        public SafeTransactionRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
