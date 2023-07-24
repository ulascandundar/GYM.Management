using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Expenses
{
    public class GetExpenseListInput : PagedAndSortedResultRequestDto
    {
        public string Description { get; set; }
        public ExpenseType? ExpenseType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
