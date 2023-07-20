using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Wallets
{
    public class WalletCommitDto
    {
        public Guid WalletId { get; set; }
        public bool IsPositive { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
