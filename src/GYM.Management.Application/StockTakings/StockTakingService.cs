using GYM.Management.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.StockTakings
{
    public class StockTakingService : CrudAppService<
         StockTaking,
        StockTakingDto,
        Guid,
        PagedAndSortedResultRequestDto,
         StockTakingCreateDto>,
        IStockTakingService
    {
        public StockTakingService(IRepository<StockTaking, Guid> repository) : base(repository)
        {
        }
    }
}
