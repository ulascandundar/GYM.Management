using GYM.Management.SafeTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Safes
{
    public class Safe : FullAuditedAggregateRoot<int>
    {
        public decimal Balance { get; set; }
        public virtual ICollection<SafeTransaction> SafesTransactions { get; set; }
    }
}
