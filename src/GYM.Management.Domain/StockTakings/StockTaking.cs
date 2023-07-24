using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.StockTakings
{
    public class StockTaking : FullAuditedAggregateRoot<Guid>
    {
        public string ProductName { get; set; }
        public int OldStock { get; set; }
        public int NewStock { get; set; }
        public string Description { get; set; }
    }
}
