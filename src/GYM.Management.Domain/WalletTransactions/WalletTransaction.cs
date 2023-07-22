using GYM.Management.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.WalletTransactions
{
    public class WalletTransaction : FullAuditedAggregateRoot<Guid>
    {
        public bool IsPositive { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Guid WalletId { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
