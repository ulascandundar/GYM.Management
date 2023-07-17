using GYM.Management.Expenses;
using GYM.Management.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Trainers
{
    public class Trainer : AuditedAggregateRoot<Guid>,ISoftDelete
    {
        public string Name { get; set; }
        public DateTime BirdthDate { get; set; }
        public string Telephone { get; set; }
        public decimal Salary { get; set; }
        public DateTime lastSalaryDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
