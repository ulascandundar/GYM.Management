using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.Exercises
{
    public interface IExerciseService : ICrudAppService<ExerciseDto,Guid, PagedAndSortedResultRequestDto,ExercisCreateDto>
    {
        Task<List<ExerciseDto>> GetAllExercisesAsync();
        Task<List<ExerciseDto>> GetAllWithoutCategoryExercisesAsync(Guid categoryId);
        Task<PagedResultDto<ExerciseDto>> GetListAsync(GetExerciseListInput input);
        Task AnyName(string name);
    }
}
