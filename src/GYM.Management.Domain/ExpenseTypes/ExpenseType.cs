using GYM.Management.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.ExpenseTypes
{
    public class ExpenseType : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEffect { get; set; }
        public bool IsStatic { get; set; }
        //public virtual ICollection<Expense> Expenses { get; set; }
        protected ExpenseType() { }
        public ExpenseType(Guid id) : base(id) { }
    }
}
