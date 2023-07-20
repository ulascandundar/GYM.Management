﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public decimal StockPrice { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
