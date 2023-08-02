using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Expenses
{
    public class ExpenseReportInputDto
    {
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
    }
}
