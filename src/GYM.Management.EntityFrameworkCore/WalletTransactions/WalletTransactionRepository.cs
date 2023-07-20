using GYM.Management.EntityFrameworkCore;
using GYM.Management.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.WalletTransactions
{
    public class WalletTransactionRepository : EfCoreRepository<ManagementDbContext, WalletTransaction, Guid>, IWalletTransactionRepository
    {
        public WalletTransactionRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
