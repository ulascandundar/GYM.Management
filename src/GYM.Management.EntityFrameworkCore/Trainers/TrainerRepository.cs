using GYM.Management.EntityFrameworkCore;
using GYM.Management.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Trainers
{
    public class TrainerRepository : EfCoreRepository<ManagementDbContext, Trainer, Guid>, ITrainerRepository
    {
        public TrainerRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
