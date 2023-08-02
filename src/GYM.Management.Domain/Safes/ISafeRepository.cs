using GYM.Management.SafeTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.Safes
{
    public interface ISafeRepository : IRepository<Safe>
    {
        Task NegativeCommit(decimal amount,string description);
        Task PositiveCommit(decimal amount, string description);
        Task<decimal> GetBalance();
    }
}
