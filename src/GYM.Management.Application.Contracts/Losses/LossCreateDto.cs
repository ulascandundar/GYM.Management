using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Losses
{
	public class LossCreateDto
	{
		public string Description { get; set; }
		public int Quantity { get; set; }
		public Guid ProductId { get; set; }
	}
}
