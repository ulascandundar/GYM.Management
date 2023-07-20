using GYM.Management.EntityFrameworkCore;
using GYM.Management.Wallets;
using GYM.Management.WalletTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Wallets
{
    public class WalletRepository : EfCoreRepository<ManagementDbContext, Wallet, Guid>, IWalletRepository
    {
        public WalletRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
