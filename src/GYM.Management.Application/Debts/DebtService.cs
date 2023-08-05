using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.ObjectMapping;
using GYM.Management.Wallets;
using GYM.Management.MemberOrders;
using GYM.Management.Safes;
using GYM.Management.Expenses;
using Microsoft.AspNetCore.Authorization;
using GYM.Management.Permissions;

namespace GYM.Management.Debts
{
    public class DebtService : ManagementAppService, IDebtService
    {
        private readonly IDebtRepository _debtRepository;
        private readonly IDataFilter _dataFilter;
        private readonly IWalletService _walletService;
        private readonly ISafeRepository _safeRepository;
        public DebtService(IDebtRepository debtRepository, IDataFilter dataFilter, IWalletService walletService, ISafeRepository safeRepository)
        {
            _debtRepository = debtRepository;
            _dataFilter = dataFilter;
            _walletService = walletService;
            _safeRepository = safeRepository;
        }

        public async Task<List<DebtDto>> GetDebt(Guid memberId)
        {
            var query = await _debtRepository.GetQueryableAsync();
            query = query.Where(o => o.MemberId == memberId && !o.IsPay);
            using (_dataFilter.Disable<ISoftDelete>())
            {
                var result = await AsyncExecuter.ToListAsync(query);
                var listDto = ObjectMapper.Map<List<Debt>, List<DebtDto>>(result);
                foreach (var item in listDto)
                {
                    item.TrainerName = item.TrainerId == null ? null : result.Where(o => o.Id == item.Id)
                    .Select(o => o.Trainer.Name).FirstOrDefault();
                }
                return listDto;
            }
        }
        [Authorize(ManagementPermissions.Debt.Pay)]
        public async Task Pay(Guid debtId)
        {
            using (_dataFilter.Disable<ISoftDelete>())
            {
                decimal trainerAmount = 0;
                var debt = await _debtRepository.GetAsync(o => o.Id == debtId);
                if (debt.IsPay)
                {
                    throw new UserFriendlyException("Borç zaten ödenmiş.", "Borç zaten ödenmiş.");
                }
                debt.IsPay = true;
                if (debt.TrainerId.HasValue)
                {
                    trainerAmount = debt.Amount * (debt.Trainer.ProfitRate / 100);
                    await _walletService.CommitToWalletNotSafeEffect(new WalletCommitDto
                    {
                        Amount = trainerAmount,
                        WalletId = debt.Trainer.Wallet.Id,
                        Description = $"{debt.Member.Name} isimli üye nin ödemesi. {debt.Description}",
                        IsPositive = true
                    });
                }
                debt.SafeAmount = debt.Amount - trainerAmount;
                await _safeRepository.PositiveCommit(debt.Amount - trainerAmount, $"{debt.Member.Name} isimli üye nin ödemesi.");
            }
        }

        public async Task Create(DebtDto dto)
        {
            await _debtRepository.InsertAsync(new Debt { Amount = dto.Amount,TrainerId= dto.TrainerId, MemberId = dto.MemberId,Description=dto.Description,
            IsPay=false});
        }

        public async Task<List<DebtDto>> TrainerReport(Guid id, ExpenseReportInputDto dto)
        {
            var result = await _debtRepository.GetListAsync(o => o.TrainerId == id && o.IsPay && o.CreationTime.Date >= dto.StartDate.Date && o.CreationTime.Date <= dto.EndDate.Date);
            var resultDto = ObjectMapper.Map<List<Debt>, List<DebtDto>>(result);
            return resultDto;
        }

        public async Task<List<DebtTrainerGroupDto>> TrainerGainForChart(DateInputDto dto)
        {
            return await _debtRepository.GetTrainerGroup(dto);
        }
    }
}
