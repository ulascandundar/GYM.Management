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
        public ExpenseService(IDataFilter dataFilter, IRepository<Expense, Guid> repository) : base(repository)
        {
            _dataFilter = dataFilter;
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
                query = query.Where(o => o.ExpenseType == input.ExpenseType);
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
