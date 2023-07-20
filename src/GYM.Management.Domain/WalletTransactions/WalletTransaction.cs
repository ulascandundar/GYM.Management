using GYM.Management.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace GYM.Management.WalletTransactions
{
    public class WalletTransaction : Entity<Guid>
    {
        public bool IsPositive { get; set; }
        public decimal Amount { get; set; }
        public Guid WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
