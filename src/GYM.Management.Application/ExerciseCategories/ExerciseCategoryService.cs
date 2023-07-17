using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.ExerciseCategories
{
    public class ExerciseCategoryService : ManagementAppService, IExerciseCategoryService
    {
        private readonly IRepository<ExerciseCategory, Guid> repository;

        public ExerciseCategoryService(IRepository<ExerciseCategory, Guid> repository)
        {
            this.repository = repository;
        }

        public async Task AddExerciseCategory(Guid categoryId, Guid exerciseId)
        {
            var isAny = await repository.AnyAsync(o=>o.CategoryId == categoryId && o.ExerciseId == exerciseId);
            if (isAny)
            {
                throw new BusinessException("Bu eşleşme zaten var", "Bu eşleşme zaten var");
            }
           await repository.InsertAsync(new ExerciseCategory { ExerciseId = exerciseId,CategoryId = categoryId });
        }

        public async Task Remove(Guid categoryId, Guid exerciseId)
        {
            var result = await repository.GetAsync(o => o.CategoryId == categoryId && o.ExerciseId == exerciseId);
            if (result == null)
            {
                throw new BusinessException("error", "error");
            }
            await repository.DeleteAsync(result);
        }
    }
}
