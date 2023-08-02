using GYM.Management.Safes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.SafeTransactions
{
    public class SafeTransaction: FullAuditedAggregateRoot<Guid>
    {
        public decimal Amount { get; set; }
        public bool IsPositive { get; set; }
        public string Description { get; set; }
        public int SafeId { get; set; }
        public virtual Safe Safe { get; set; }
    }
}
