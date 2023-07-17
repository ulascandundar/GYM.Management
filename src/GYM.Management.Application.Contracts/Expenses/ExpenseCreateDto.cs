using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Expenses
{
    public class ExpenseCreateDto
    {
        public Guid? TrainerId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public ExpenseType ExpenseType { get; set; }
    }
}
