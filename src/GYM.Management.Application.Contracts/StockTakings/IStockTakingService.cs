using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.StockTakings
{
    public interface IStockTakingService : ICrudAppService<StockTakingDto, Guid, PagedAndSortedResultRequestDto, StockTakingCreateDto>
    {
    }
}
