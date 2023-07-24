using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.Wallets
{
    public interface IWalletRepository : IRepository<Wallet,Guid>
    {
        Task<Wallet> GetByTrainerId(Guid id);
    }
}
