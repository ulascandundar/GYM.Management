using GYM.Management.Categories;
using GYM.Management.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.Exercises
{
    public class ExerciseRepository : EfCoreRepository<ManagementDbContext, Exercise, Guid>, IExerciseRepository
    {
        public ExerciseRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task RemoveAsync(Guid id)
        {
            var dbContext = await GetDbContextAsync();
            var exercise = await dbContext.Exercises.FindAsync(id);
            var nagivations = exercise.ExerciseCategories.ToList();
            dbContext.RemoveRange(nagivations);
            dbContext.Remove(exercise);
            await dbContext.SaveChangesAsync();
        }
    }
}
