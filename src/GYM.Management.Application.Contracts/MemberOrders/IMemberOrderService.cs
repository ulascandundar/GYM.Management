using GYM.Management.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.MemberOrders
{
	public interface IMemberOrderService : ICrudAppService<MemberOrderDto, Guid, PagedAndSortedResultRequestDto, MemberOrderCreateDto>
    {
        Task PlaceOrder(ProductDto productDto, Guid memberId);
        Task PlaceOrderAppointment(MemberOrderAppointmentCreateDto dto, Guid memberId);
        Task AddGain(Guid memberId, string description, decimal amount);
    }
}
