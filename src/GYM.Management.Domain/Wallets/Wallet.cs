using GYM.Management.Trainers;
using GYM.Management.WalletTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Wallets
{
    public class Wallet :FullAuditedAggregateRoot<Guid>
    {
        public decimal Balance { get; set; }
        public Guid TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<WalletTransaction> WalletTransactions { get; set; }
    }
}
