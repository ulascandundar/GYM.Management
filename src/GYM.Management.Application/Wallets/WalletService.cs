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
    }
}
