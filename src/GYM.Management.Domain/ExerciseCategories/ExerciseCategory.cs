using GYM.Management.Categories;
using GYM.Management.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.ExerciseCategories
{
    public class ExerciseCategory : FullAuditedAggregateRoot<Guid>
    {
        public Guid ExerciseId { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual Category Category { get; set; }
    }
}
