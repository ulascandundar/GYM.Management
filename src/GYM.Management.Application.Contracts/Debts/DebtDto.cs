using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Debts
{
    public class DebtDto : FullAuditedEntityDto<Guid>
    {
        public string Description { get; set; }
        public string TrainerName { get; set; }
        public Guid MemberId { get; set; }
        public decimal Amount { get; set; }
        public Guid? TrainerId { get; set; }
        public bool IsPay { get; set; }
        public decimal SafeAmount { get; set; }
    }
}
