using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.MemberOrders
{
	public interface IMemberOrderService : ICrudAppService<MemberOrderDto, Guid, PagedAndSortedResultRequestDto, MemberOrderCreateDto>
	{
	}
}
