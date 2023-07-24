using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.Losses
{
	public interface ILossService : ICrudAppService<LossDto, Guid, PagedAndSortedResultRequestDto, LossCreateDto>
    {
	}
}
