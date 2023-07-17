using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
