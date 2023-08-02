using GYM.Management.EntityFrameworkCore;
using GYM.Management.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.ExpenseTypes
{
    public class ExpenseTypeRepository : EfCoreRepository<ManagementDbContext, ExpenseType, Guid>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
