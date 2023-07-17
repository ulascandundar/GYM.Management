using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Expenses
{
    public class GetExpenseListInput : PagedAndSortedResultRequestDto
    {
        public string Description { get; set; }
    }
}
