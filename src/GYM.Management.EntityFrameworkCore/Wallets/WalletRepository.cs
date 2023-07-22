using GYM.Management.EntityFrameworkCore;
using GYM.Management.Wallets;
using GYM.Management.WalletTransactions;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Wallet> GetByTrainerId(Guid id)
        {
            var result = await DbContext.Wallets.FirstOrDefaultAsync(o => o.TrainerId == id);
            return result;
        }
    }
}
