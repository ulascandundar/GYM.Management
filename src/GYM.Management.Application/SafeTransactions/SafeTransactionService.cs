using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.SafeTransactions
{
    public class SafeTransactionService : CrudAppService<
        SafeTransaction,
        SafeTransactionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        SafeTransactionCreateDto>,
    ISafeTransactionService
    {
        public SafeTransactionService(IRepository<SafeTransaction, Guid> repository) : base(repository) 
        {

        }
    }
}
