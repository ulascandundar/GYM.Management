using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Products
{
    public class StockOrderCreateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal StockBuyPrice { get; set; }
    }
}
