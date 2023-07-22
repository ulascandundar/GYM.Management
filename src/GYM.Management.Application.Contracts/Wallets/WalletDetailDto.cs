using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Wallets
{
    public class WalletDetailDto
    {
        public string TrainerName { get; set; }
        public decimal Balance { get; set; }
        public List<WalletTransDto> Trainsactions { get; set; } = new List<WalletTransDto>();
    }
}
