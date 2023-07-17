using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.MemberOrders
{
	public class MemberOrderService : CrudAppService<
		MemberOrder,
		MemberOrderDto,
		Guid,
		PagedAndSortedResultRequestDto,
		MemberOrderCreateDto>,
	IMemberOrderService
	{
		public MemberOrderService(IRepository<MemberOrder, Guid> repository) : base(repository)
		{
		}
	}
}
