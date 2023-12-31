﻿using GYM.Management.Debts;
using GYM.Management.Extensions;
using GYM.Management.Gains;
using GYM.Management.Members;
using GYM.Management.Permissions;
using GYM.Management.Products;
using GYM.Management.Safes;
using GYM.Management.Trainers;
using GYM.Management.Wallets;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITrainerRepository _trainerRepository;
        private readonly IWalletService _walletService;
        private readonly ISafeRepository _safeRepository;
        private readonly IDebtRepository _debtRepository;
        public MemberOrderService(IProductRepository productRepository, IMemberOrderRepository memberOrderRepository,
            IMemberRepository memberRepository, IRepository<MemberOrder, Guid> repository, IGainRepository gainRepository,
            ITrainerRepository trainerRepository, IWalletService walletService, ISafeRepository safeRepository, IDebtRepository debtRepository) : base(repository)
        {
			_productRepository = productRepository;
			_memberOrderRepository = memberOrderRepository;
			_memberRepository = memberRepository;
            _gainRepository = gainRepository;
            _trainerRepository = trainerRepository;
            _walletService = walletService;
            _safeRepository = safeRepository;
            _debtRepository = debtRepository;
		}
        [Authorize(ManagementPermissions.Member.AddProduct)]
        public async Task PlaceOrder(ProductDto productDto, Guid memberId)
		{
            var trainer = await _trainerRepository.GetAsync((Guid)productDto.TrainerId);
			var product = await _productRepository.GetAsync(o=>o.Id == productDto.Id);
            if (product.Stock < productDto.Quantity) throw new UserFriendlyException ("Yeterli stok bulunmamakta. Stok sayımı yapınız yada stok siparişi geçiniz.", "Yeterli stok bulunmamakta. Stok sayımı yapınız yada stok siparişi geçiniz.");
			product.Stock -= productDto.Quantity;
            await _productRepository.UpdateAsync(product);
            var memberOrder = await _memberOrderRepository.InsertAsync(new MemberOrder
			{
				ProductId = productDto.Id,
				TotalPrice = productDto.Quantity * product.BuyPrice,
				Quantity= productDto.Quantity,
				MemberId = memberId,
				MemberOrderType = MemberOrderType.Product,
                Profit = productDto.Quantity * (product.BuyPrice - product.StockPrice)
            });
            await _debtRepository.InsertAsync(new Debt
            {
                IsPay = false,
                Amount = memberOrder.TotalPrice,
                Description = $"{product.Name} SATIŞI - {productDto.Quantity} ADET",
                MemberId = memberId
            });
            //await _walletService.CommitToWallet(new WalletCommitDto { Amount = (memberOrder.TotalPrice - (productDto.Quantity * product.StockPrice)).Percent(trainer.ProfitRate),WalletId =trainer.Wallet.Id,
            //    Description = $"{product.Name} SATIŞI - {productDto.Quantity} ADET",IsPositive = true });
            var member = await _memberRepository.GetAsync(o => o.Id == memberId);
            member.Debt += memberOrder.TotalPrice;
            await _memberRepository.UpdateAsync(member);
        }
        [Authorize(ManagementPermissions.Member.AddAppointment)]
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
            if (!member.TrainerId.HasValue)
            {
                throw new UserFriendlyException("Üyenin seçili antrenörü bulunmamakta", "Üyenin seçili antrenörü bulunmamakta");
            }
			member.AppointmentStock += dto.AppointmentStock;
            member.Debt += memberOrder.TotalPrice;
            await _debtRepository.InsertAsync(new Debt
            {
                IsPay = false,
                Amount = memberOrder.TotalPrice,
                Description = $"Tanesi {dto.UnitPrice} TL den {dto.AppointmentStock} adet randevu satışı.",
                MemberId = memberId,
                TrainerId=member.TrainerId
            });
            await _memberRepository.UpdateAsync(member);
        }
        [Authorize(ManagementPermissions.Member.Pay)]
        public async Task AddGain(Guid memberId,string description,decimal amount)
        {
            var member = await _memberRepository.GetAsync(o => o.Id == memberId);
            if (member.Debt < amount)
            {
                throw new UserFriendlyException("Ödeme borçtan büyük olamaz", "Ödeme borçtan büyük olamaz");
            }
            await _gainRepository.InsertAsync(new Gain { Amount= amount,Description = description, MemberId = memberId });
            member.Debt -= amount;
            await _safeRepository.PositiveCommit(amount, $"{member.Name} isimli üye borcunu ödedi.");
            await _memberRepository.UpdateAsync(member);
        }
    }
}
