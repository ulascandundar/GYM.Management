using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.StockTakings
{
    public class StockTakingDto:FullAuditedEntityDto<Guid>
    {
        public string ProductName { get; set; }
        public int OldStock { get; set; }
        public int NewStock { get; set; }
        public string Description { get; set; }
    }
}
