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

        public async Task<List<DebtTrainerGroupDto>> GetTrainerGroup(DateInputDto dto)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.Debts.Where(o => o.IsPay && o.TrainerId != null && o.CreationTime.Date >= dto.StartDate.Date && o.CreationTime.Date <= dto.EndDate.Date);
            var result = query.GroupBy(d => new { d.TrainerId, d.Trainer.Name })
            .Select(g => new DebtTrainerGroupDto
            {
                TrainerId = (Guid)g.Key.TrainerId,
                TrainerName = g.Key.Name,
                TotalSafeAmount = g.Sum(d => d.SafeAmount)
            })
            .ToList();
            return result;
        }
        
    }
}
