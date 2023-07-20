using GYM.Management.EntityFrameworkCore;
using GYM.Management.Gains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Categories
{
    public class CategoryRepository : EfCoreRepository<ManagementDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
