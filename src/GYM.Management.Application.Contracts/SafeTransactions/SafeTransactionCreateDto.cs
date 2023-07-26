using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.SafeTransactions
{
    public class SafeTransactionCreateDto
    {
        public decimal Amount { get; set; }
        public bool IsPositive { get; set; }
        public string Description { get; set; }
    }
}
