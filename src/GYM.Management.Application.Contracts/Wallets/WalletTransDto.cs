using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Wallets
{
    public class WalletTransDto :FullAuditedEntityDto<Guid>
    {
        public bool IsPositive { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Guid WalletId { get; set; }
    }
}
