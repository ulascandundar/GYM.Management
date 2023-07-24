using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using GYM.Management.Members;
using GYM.Management.Products;

namespace GYM.Management.MemberOrders
{
	public class MemberOrder : FullAuditedAggregateRoot<Guid>
    {
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
		public decimal Profit { get; set; }
		public int AppointmentStock { get; set; }
		public MemberOrderType MemberOrderType { get; set; }
		public Guid MemberId { get; set; }
		public Guid? ProductId { get; set; }
		public virtual Member Member { get; set; }
		public virtual Product Product { get; set; }
	}
}
