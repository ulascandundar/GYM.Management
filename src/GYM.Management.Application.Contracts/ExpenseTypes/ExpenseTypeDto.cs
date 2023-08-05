using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.ExpenseTypes
{
    public class ExpenseTypeDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEffect { get; set; }
        public bool IsStatic { get; set; }

    }
}
