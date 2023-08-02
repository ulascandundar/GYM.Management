using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using GYM.Management.Members;
using GYM.Management.Trainers;
using GYM.Management.ExpenseTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYM.Management.Expenses
{
    public class Expense : FullAuditedAggregateRoot<Guid>
    {
        public Guid? TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid? ExpenseTypeId { get; set; }
        public virtual ExpenseType Type { get; set; }
    }
}
