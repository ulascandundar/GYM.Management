using GYM.Management.ExerciseCategories;
using GYM.Management.Exercises;
using GYM.Management.Permissions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.Categories
{
    public class CategoryService : CrudAppService<
        Category,
        CategoryDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CategoryCreateDto>,
        ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IRepository<Category, Guid> repository)
         : base(repository)
        {
            GetPolicyName = ManagementPermissions.Category.Default;
            GetListPolicyName = ManagementPermissions.Category.Default;
            CreatePolicyName = ManagementPermissions.Category.Create;
            UpdatePolicyName = ManagementPermissions.Category.Edit;
            DeletePolicyName = ManagementPermissions.Category.Delete;
        }

        public async Task<bool> AddExerciseCategory(Guid categoryId, Guid exerciseId)
        {
            var category = await Repository.GetAsync(categoryId);
            category.ExerciseCategories.Add(new ExerciseCategory { ExerciseId = exerciseId,CategoryId=categoryId });
            return true;
        }

        public async Task<CategoryWithExercises> GetExercisesByCategoryId(Guid categoryId)
        {
            var category = await Repository.GetAsync(categoryId,true);
            //var queryable = query.Where(o=>o.Id == categoryId);
            //var category = await AsyncExecuter.FirstOrDefaultAsync(queryable);
            CategoryWithExercises categoryWithExercises = new CategoryWithExercises
            {
                CategoryId = categoryId,
                CategoryName = category.Name,
                ExerciseDtos = category.ExerciseCategories.Select(o => new ExerciseDto { Id = o.ExerciseId, Name = o.Exercise.Name }).ToList()
            };
            return categoryWithExercises;
        }
    }
}
