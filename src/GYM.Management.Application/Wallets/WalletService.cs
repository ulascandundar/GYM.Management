using GYM.Management.Expenses;
using GYM.Management.Permissions;
using GYM.Management.WalletTransactions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace GYM.Management.Wallets
{
    [Authorize(ManagementPermissions.Wallet.Default)]
    public class WalletService : ApplicationService, IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IWalletTransactionRepository _walletTransactionRepository;
        private readonly IExpenseRepository _expenseRepository;
        public WalletService(IWalletRepository walletRepository, IWalletTransactionRepository walletTransactionRepository, IExpenseRepository expenseRepository)
        {
            _walletRepository = walletRepository;
            _walletTransactionRepository = walletTransactionRepository;
            _expenseRepository = expenseRepository;
        }
        [Authorize(ManagementPermissions.Wallet.Edit)]
        public async Task CommitToWallet(WalletCommitDto walletCommitDto)
        {
            var wallet = await _walletRepository.GetAsync(o => o.Id == walletCommitDto.WalletId);
            if (walletCommitDto.IsPositive)
            {
                wallet.Balance += walletCommitDto.Amount;
            }
            else
            {
                if (wallet.Balance < walletCommitDto.Amount)
                {
                    throw new UserFriendlyException($"Bakiyeniz {wallet.Balance} TL dir", $"Bakiyeniz {wallet.Balance} TL dir");
                }
                wallet.Balance -= walletCommitDto.Amount;
            }
            await _expenseRepository.InsertAsync(new Expense { Amount= walletCommitDto.Amount,Date = DateTime.UtcNow,ExpenseType= ExpenseType.Wallet
            ,Description = $"Cüzdandan para çekildi",TrainerId = wallet.TrainerId});
            await _walletRepository.UpdateAsync(wallet);
            await _walletTransactionRepository.InsertAsync(new WalletTransaction { Amount= walletCommitDto.Amount,IsPositive=walletCommitDto.IsPositive,
                WalletId=walletCommitDto.WalletId, Description = walletCommitDto.Description });
        }

        public async Task<WalletDetailDto> GetDetail(Guid id,string trainerName)
        {
           var wallet = await _walletRepository.GetByTrainerId(id);
            if (wallet == null)
            {
                var newWallet = new Wallet { TrainerId = id };
                var addedWallet = await _walletRepository.InsertAsync(newWallet);
                return new WalletDetailDto { Balance = newWallet.Balance, TrainerName = trainerName };
            }
            var transactions = wallet.WalletTransactions.OrderByDescending(o=>o.CreationTime).Select(o => new WalletTransDto { Amount = o.Amount, Description =o.Description, IsPositive = o.IsPositive,
                WalletId = o.WalletId, Id = o.Id,CreationTime=o.CreationTime }).ToList();
            return new WalletDetailDto { TrainerName = wallet.Trainer.Name, Balance = wallet.Balance,Trainsactions = transactions,WalletId = wallet.Id };
        }


    }
}
