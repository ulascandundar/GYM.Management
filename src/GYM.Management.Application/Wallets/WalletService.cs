using GYM.Management.WalletTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GYM.Management.Wallets
{
    public class WalletService : ApplicationService, IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IWalletTransactionRepository _walletTransactionRepository;

        public WalletService(IWalletRepository walletRepository, IWalletTransactionRepository walletTransactionRepository)
        {
            _walletRepository = walletRepository;
            _walletTransactionRepository = walletTransactionRepository;
        }

        public async Task CommitToWallet(WalletCommitDto walletCommitDto)
        {
            var wallet = await _walletRepository.GetAsync(o => o.Id == walletCommitDto.WalletId);
            wallet.Balance += walletCommitDto.Amount;
            await _walletRepository.UpdateAsync(wallet);
            await _walletTransactionRepository.InsertAsync(new WalletTransaction { Amount= walletCommitDto.Amount,IsPositive=true,WalletId=walletCommitDto.WalletId });
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
            var transactions = wallet.WalletTransactions.Select(o => new WalletTransDto { Amount = o.Amount, Description =o.Description, IsPositive = o.IsPositive, WalletId = o.WalletId, Id = o.Id }).ToList();
            return new WalletDetailDto { TrainerName = wallet.Trainer.Name, Balance = wallet.Balance,Trainsactions = transactions };
        }
    }
}
