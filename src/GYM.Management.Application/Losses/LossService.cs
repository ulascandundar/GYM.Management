using GYM.Management.MemberOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.Losses
{
	public class LossService : CrudAppService<
        Loss,
        LossDto,
        Guid,
        PagedAndSortedResultRequestDto,
        LossCreateDto>,
    ILossService
    {
        public LossService(IRepository<Loss, Guid> repository):base(repository)
        {

        }
	}
}
