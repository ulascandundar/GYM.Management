using GYM.Management.Members;
using GYM.Management.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.AppointmentTransactions
{
    public class AppointmentTransaction : FullAuditedAggregateRoot<Guid>
    {
        public Guid MemberId { get; set; }
        public Guid TrainerId { get; set; }
        public string Description { get; set; }
        public int OldStock { get; set; }
        public DateTime Date { get; set; }
        public virtual Member Member { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
