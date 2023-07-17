using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GYM.Management.ExerciseCategories
{
    public interface IExerciseCategoryService : IApplicationService
    {
        Task AddExerciseCategory(Guid categoryId, Guid exerciseId);
        Task Remove(Guid categoryId, Guid exerciseId);
    }
}
