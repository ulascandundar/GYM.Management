using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Losses
{
	public class LossDto : FullAuditedEntityDto<Guid>
	{
		public string Description { get; set; }
		public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}
