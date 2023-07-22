using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GYM.Management.Wallets
{
    public interface IWalletService :IApplicationService
    {
        Task CommitToWallet(WalletCommitDto walletCommitDto);
        Task<WalletDetailDto> GetDetail(Guid id, string trainerName);
    }
}
