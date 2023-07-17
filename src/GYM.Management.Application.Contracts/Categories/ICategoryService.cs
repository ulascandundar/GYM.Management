using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.Categories
{
    public interface ICategoryService : ICrudAppService<CategoryDto, Guid, PagedAndSortedResultRequestDto, CategoryCreateDto>
    { 
        public Task<CategoryWithExercises> GetExercisesByCategoryId(Guid categoryId);
        public Task<bool> AddExerciseCategory(Guid categoryId,Guid exerciseId);
    }
}
