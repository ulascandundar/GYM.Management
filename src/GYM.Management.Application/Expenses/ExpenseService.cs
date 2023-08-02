using GYM.Management.ExpenseTypes;
using GYM.Management.Safes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace GYM.Management.Expenses
{
    public class ExpenseService : CrudAppService<
        Expense,
        ExpenseDto,
        Guid,
        PagedAndSortedResultRequestDto,
        ExpenseCreateDto>,
    IExpenseService
    {
        private readonly IDataFilter _dataFilter;
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        private readonly ISafeRepository _safeRepository;
        public ExpenseService(IDataFilter dataFilter, IRepository<Expense, Guid> repository,IExpenseTypeRepository expenseTypeRepository, ISafeRepository safeRepository) : base(repository)
        {
            _dataFilter = dataFilter;
            _expenseTypeRepository = expenseTypeRepository;
            _safeRepository = safeRepository;
        }

        public async Task Create(ExpenseCreateDto input)
        {
            await CreateAsync(input);
            var expenseType = await _expenseTypeRepository.GetAsync(o => o.Id == input.ExpenseTypeId);
            if (expenseType.IsEffect)
            {
                await _safeRepository.NegativeCommit(input.Amount
               , input.Description + $"Gider Tipi: {expenseType.Name}");
            }
        }

        public async Task<PagedResultDto<ExpenseDto>> GetListAsync(GetExpenseListInput input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(o => o.IsDeleted == false);
            if (!input.Description.IsNullOrWhiteSpace())
            {
                input.Description = input.Description.ToLower();
                query = query.Where(o => o.Description.ToLower().Contains(input.Description));
            }
            if (input.ExpenseType!=null)
            {
                query = query.Where(o => o.ExpenseTypeId == input.ExpenseType);
            }
            if (input.StartDate.HasValue)
            {
                query = query.Where(o => o.CreationTime >= input.StartDate);
            }
            if (input.EndDate.HasValue)
            {
                query = query.Where(o => o.CreationTime <= input.StartDate);
            }
            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.OrderBy(string.IsNullOrWhiteSpace(input.Sorting)
                ? "CreationTime desc"
                : input.Sorting);

            query = query.PageBy(input);
            using (_dataFilter.Disable<ISoftDelete>())
            {
                var result = await AsyncExecuter.ToListAsync(query);
                var listDto = ObjectMapper.Map<List<Expense>, List<ExpenseDto>>(result);
                foreach (var item in listDto)
                {
                    item.TrainerName = item.TrainerId == null ? null : result.Where(o => o.Id == item.Id)
                    .Select(o => o.Trainer.Name).FirstOrDefault();
                    item.ExpenseTypeName = result.Where(o => o.Id == item.Id)
                    .Select(o => o.Type.Name).FirstOrDefault();
                }
                return new PagedResultDto<ExpenseDto>(totalCount, listDto);
            }
            
        }

        public async Task<List<ExpenseDto>> GetReports(ExpenseReportInputDto dto)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(o => o.CreationTime.Date >= dto.StartDate.Date && o.CreationTime.Date <= dto.EndDate.Date);
            var result = await AsyncExecuter.ToListAsync(query);
            var listDto = ObjectMapper.Map<List<Expense>, List<ExpenseDto>>(result);
            return listDto;
        }
        
    }
}
