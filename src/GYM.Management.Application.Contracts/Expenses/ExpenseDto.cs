using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Expenses
{
    public class ExpenseDto : AuditedEntityDto<Guid>
    {
        public Guid? TrainerId { get; set; }
        public string? TrainerName { get;set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }
}
