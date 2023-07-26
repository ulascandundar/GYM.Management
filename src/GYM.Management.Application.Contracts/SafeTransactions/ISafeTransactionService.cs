using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.SafeTransactions
{
    public interface ISafeTransactionService : ICrudAppService<SafeTransactionDto, Guid, PagedAndSortedResultRequestDto, SafeTransactionCreateDto>
    {
    }
}
