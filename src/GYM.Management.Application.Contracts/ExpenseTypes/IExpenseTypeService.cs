using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.ExpenseTypes
{
    public interface IExpenseTypeService : ICrudAppService<ExpenseTypeDto, Guid, PagedAndSortedResultRequestDto, ExpenseTypeCreateDto>
    {
        Task<bool> AnyName(string name);
    }
}
