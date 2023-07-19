using GYM.Management.Gains;
using GYM.Management.Members;
using GYM.Management.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
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
		private readonly IProductRepository _productRepository;
		private readonly IMemberOrderRepository _memberOrderRepository;
		private readonly IMemberRepository _memberRepository;
        private readonly IGainRepository _gainRepository;
        public MemberOrderService(IProductRepository productRepository, IMemberOrderRepository memberOrderRepository,
            IMemberRepository memberRepository, IRepository<MemberOrder, Guid> repository, IGainRepository gainRepository) : base(repository)
        {
			_productRepository = productRepository;
			_memberOrderRepository = memberOrderRepository;
			_memberRepository = memberRepository;
            _gainRepository = gainRepository;
		}

		public async Task PlaceOrder(ProductDto productDto, Guid memberId)
		{
			var product = await _productRepository.GetAsync(o=>o.Id == productDto.Id);
			var memberOrder = await _memberOrderRepository.InsertAsync(new MemberOrder
			{
				ProductId = productDto.Id,
				TotalPrice = productDto.Quantity * product.BuyPrice,
				Quantity= productDto.Quantity,
				MemberId = memberId,
				MemberOrderType = MemberOrderType.Product
			});
            var member = await _memberRepository.GetAsync(o => o.Id == memberId);
            member.Debt += memberOrder.TotalPrice;
            await _memberRepository.UpdateAsync(member);
        }
        public async Task PlaceOrderAppointment(MemberOrderAppointmentCreateDto dto, Guid memberId)
        {
            var memberOrder = await _memberOrderRepository.InsertAsync(new MemberOrder
            {
                TotalPrice = dto.UnitPrice * dto.AppointmentStock,
                AppointmentStock = dto.AppointmentStock,
                MemberId = memberId,
                MemberOrderType = MemberOrderType.Appointment
            });
			var member = await _memberRepository.GetAsync(o=>o.Id ==memberId);
			member.AppointmentStock += dto.AppointmentStock;
            member.Debt += memberOrder.TotalPrice;
            await _memberRepository.UpdateAsync(member);
        }

        public async Task AddGain(Guid memberId,string description,decimal amount)
        {
            var member = await _memberRepository.GetAsync(o => o.Id == memberId);
            if (member.Debt < amount)
            {
                throw new UserFriendlyException("Ödeme borçtan büyük olamaz", "Ödeme borçtan büyük olamaz");
            }
            await _gainRepository.InsertAsync(new Gain { Amount= amount,Description = description, MemberId = memberId });
            member.Debt -= amount;
            await _memberRepository.UpdateAsync(member);
        }
    }
}
