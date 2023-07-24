using GYM.Management.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Losses
{
	public class Loss : FullAuditedAggregateRoot<Guid>
	{
		public string Description { get; set; }
		public int Quantity { get; set; }
		public string ProductName { get; set; }
	}
}
