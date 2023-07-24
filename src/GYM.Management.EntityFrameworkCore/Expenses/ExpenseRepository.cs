using GYM.Management.EntityFrameworkCore;
using GYM.Management.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Expenses
{
    public class ExpenseRepository : EfCoreRepository<ManagementDbContext, Expense, Guid>, IExpenseRepository
    {
        public ExpenseRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
