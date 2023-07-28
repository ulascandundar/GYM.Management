using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.AppointmentTransactions
{
    public class AppointmentTransactionDto : FullAuditedEntityDto<Guid>
    {
        public Guid MemberId { get; set; }
        public Guid TrainerId { get; set; }
        public string Description { get; set; }
        public int OldStock { get; set; }
        public string MemberName { get; set; }
        public string TrainerName { get; set; }
    }
}
