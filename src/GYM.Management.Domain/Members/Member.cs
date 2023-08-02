﻿using GYM.Management.AppointmentTransactions;
using GYM.Management.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Members
{
    public class Member : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime BirdthDate { get; set; }
        public string Telephone { get; set; }
        public Guid? TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public int AppointmentStock { get; set; }
        public decimal Debt { get; set; }
        public virtual ICollection<AppointmentTransaction> AppointmentTransactions { get; set; }
    }
}
