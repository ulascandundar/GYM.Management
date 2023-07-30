using GYM.Management.EntityFrameworkCore;
using GYM.Management.SafeTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
    
namespace GYM.Management.Tests
{
    public class TestRepository : EfCoreRepository<ManagementDbContext, Test, Guid>, ITestRepository
    {
        public TestRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
