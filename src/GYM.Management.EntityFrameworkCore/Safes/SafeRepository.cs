using GYM.Management.EntityFrameworkCore;
using GYM.Management.Expenses;
using GYM.Management.SafeTransactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Safes
{
    public class SafeRepository : EfCoreRepository<ManagementDbContext, Safe, int>, ISafeRepository
    {
        public SafeRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task NegativeCommit(decimal amount, string description)
        {
            var dbContext = await GetDbContextAsync();
            var safe = dbContext.Safes.FirstOrDefault();
            safe.Balance -= amount;
            await UpdateAsync(safe);
            await dbContext.SafeTransactions.AddAsync(new SafeTransaction { Amount = amount, Description = description, IsPositive = false, SafeId = safe.Id });
        }

        public async Task PositiveCommit(decimal amount, string description)
        {
            var dbContext = await GetDbContextAsync();
            var safe = dbContext.Safes.FirstOrDefault();
            safe.Balance += amount;
            await UpdateAsync(safe);
            await dbContext.SafeTransactions.AddAsync(new SafeTransaction { Amount = amount, Description = description, IsPositive = true, SafeId = safe.Id });
        }

        public async Task<decimal> GetBalance()
        {
            var dbContext = await GetDbContextAsync();
            var balance = await dbContext.Safes.Select(o=>o.Balance).FirstOrDefaultAsync();
            return balance;
        }
    }
}
