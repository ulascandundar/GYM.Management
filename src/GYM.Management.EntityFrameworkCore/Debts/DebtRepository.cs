using GYM.Management.EntityFrameworkCore;
using GYM.Management.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Debts
{
    public class DebtRepository : EfCoreRepository<ManagementDbContext, Debt, Guid>, IDebtRepository
    {
        public DebtRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
