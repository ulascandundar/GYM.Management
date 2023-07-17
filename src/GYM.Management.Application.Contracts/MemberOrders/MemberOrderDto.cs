using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.MemberOrders
{
	public class MemberOrderDto : AuditedEntityDto<Guid>
	{
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
		public int AppointmentStock { get; set; }
		public MemberOrderType MemberOrderType { get; set; }
		public Guid MemberId { get; set; }
		public Guid? ProductId { get; set; }
		public string ProductName { get; set; }
		public string MemberName { get; set; }
	}
}
