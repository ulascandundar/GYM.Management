using GYM.Management.Members;
using GYM.Management.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Debts
{
    public class Debt : FullAuditedAggregateRoot<Guid>
    {
        public string Description { get; set; }
        public Guid MemberId { get; set; }
        public decimal Amount { get; set; }
        public Guid? TrainerId { get; set; }
        public bool IsPay { get; set; }
        public virtual Member Member { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
