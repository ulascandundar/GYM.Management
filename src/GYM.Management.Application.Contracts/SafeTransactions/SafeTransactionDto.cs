using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.SafeTransactions
{
    public class SafeTransactionDto : AuditedEntityDto<Guid>
    {
        public decimal Amount { get; set; }
        public bool IsPositive { get; set; }
        public string Description { get; set; }
    }
}
