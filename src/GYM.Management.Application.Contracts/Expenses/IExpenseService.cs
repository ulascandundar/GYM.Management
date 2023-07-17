using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.Expenses
{
    public interface IExpenseService : ICrudAppService<ExpenseDto, Guid, PagedAndSortedResultRequestDto, ExpenseCreateDto>
    {
        Task<PagedResultDto<ExpenseDto>> GetListAsync(GetExpenseListInput input);
        Task<List<ExpenseDto>> GetReports(ExpenseReportInputDto dto);
    }
}
