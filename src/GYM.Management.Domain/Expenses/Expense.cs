using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using GYM.Management.Members;
using GYM.Management.Trainers;

namespace GYM.Management.Expenses
{
    public class Expense : AuditedAggregateRoot<Guid>, ISoftDelete
    {
        public Guid? TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public string Description { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
