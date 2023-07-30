using GYM.Management.AppointmentTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Tests
{
    public class Test : FullAuditedAggregateRoot<Guid>
    {
        public string Description { get; set; }
        public Guid AppointmentTransactionId { get; set; }
        public virtual AppointmentTransaction AppointmentTransaction { get; set; }
    }
}
