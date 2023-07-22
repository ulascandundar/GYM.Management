using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Wallets
{
    public class DrawToWalletDto
    {
        public Guid WalletId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
