using GYM.Management.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace GYM.Management.Exercises
{
    public class ExerciseService : CrudAppService<
		Exercise, 
		ExerciseDto,
		Guid, 
		PagedAndSortedResultRequestDto, 
		ExercisCreateDto>, 
	IExerciseService
	{
        private readonly IExerciseRepository _exerciseRepository;
		public ExerciseService(IRepository<Exercise, Guid> repository, IExerciseRepository exerciseRepository)
		 : base(repository)
		{
            GetPolicyName = ManagementPermissions.Exercise.Default;
            GetListPolicyName = ManagementPermissions.Exercise.Default;
            CreatePolicyName = ManagementPermissions.Exercise.Create;
            UpdatePolicyName = ManagementPermissions.Exercise.Edit;
            DeletePolicyName = ManagementPermissions.Exercise.Delete;
            _exerciseRepository = exerciseRepository;
        }

		public Task<List<ExerciseDto>> GetAllExercisesAsync()
		{
			throw new NotImplementedException();
		}

        public Task<List<ExerciseDto>> GetAllWithoutCategoryExercisesAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        //public Task<PagedResultDto<ExerciseDto>> GetListAsync(GetExerciseListInput input)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<PagedResultDto<ExerciseDto>> GetListAsync(GetExerciseListInput input)
        {
            var query = await Repository.GetQueryableAsync();
            if (!input.Name.IsNullOrWhiteSpace())
            {
                input.Name = input.Name.ToLower();
                query = query.Where(o => o.Name.ToLower().Contains(input.Name));
            }
            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.OrderBy(string.IsNullOrWhiteSpace(input.Sorting)
                ? "CreationTime desc"
                : input.Sorting);

            query = query.PageBy(input);
            var result = await AsyncExecuter.ToListAsync(query);
            var listDto = ObjectMapper.Map<List<Exercise>,List<ExerciseDto>>(result);
            return new PagedResultDto<ExerciseDto>(totalCount, listDto);
        }
        public async Task<bool> AnyName(string name)
        {
            if (await Repository.AnyAsync(o => o.Name.ToLower() == name.ToLower()))
            {
                throw new UserFriendlyException("Aynı isimde ürün zaten var", "Aynı isimde ürün zaten var");
            }
            return true;
        }
        public async Task RemoveAsync(Guid id)
        {
            await _exerciseRepository.RemoveAsync(id);
        }
    }
}
