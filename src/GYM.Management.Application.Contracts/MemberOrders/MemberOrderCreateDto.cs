using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.MemberOrders
{
	public class MemberOrderCreateDto
	{
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
		public int AppointmentStock { get; set; }
		public MemberOrderType MemberOrderType { get; set; }
		public Guid MemberId { get; set; }
		public Guid? ProductId { get; set; }
	}
}
