using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.ExpenseTypes
{
    public class ExpenseTypeService : CrudAppService<
        ExpenseType,
        ExpenseTypeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        ExpenseTypeCreateDto>,
    IExpenseTypeService
    {
        public ExpenseTypeService(IRepository<ExpenseType,Guid> repository):base(repository)
        {

        }

        public async Task<bool> AnyName(string name)
        {
            return await Repository.AnyAsync(o=>o.Name == name);
        }
    }
}
