using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Categories
{
	public class GetCategoryListInput : PagedAndSortedResultRequestDto
	{
		public string Name { get; set; }
	}
}
