using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GYM.Management.Wallets
{
    public class WalletCommitDto
    {
        public Guid WalletId { get; set; }
        public bool IsPositive { get; set; }
        [Range(0,30000,ErrorMessage = "Tek seferde çekilebilecek miktar 1 ile 30.000 TL arasıdır.")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        public string Description { get; set; }
    }
}
