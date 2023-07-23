using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.StockTakings
{
    public class StockTakingCreateDto
    {
        public Guid ProductId { get; set; }
        public int NewStock { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
    }
}
