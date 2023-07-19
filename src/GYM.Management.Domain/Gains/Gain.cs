using GYM.Management.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Gains
{
    public class Gain : FullAuditedAggregateRoot<Guid>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Guid MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
