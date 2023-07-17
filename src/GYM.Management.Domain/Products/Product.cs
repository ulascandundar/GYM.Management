using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace GYM.Management.Products
{
    public class Product : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BuyPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
