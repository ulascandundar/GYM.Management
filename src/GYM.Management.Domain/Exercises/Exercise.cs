﻿using GYM.Management.ExerciseCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace GYM.Management.Exercises
{
    public class Exercise : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string? Video { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ExerciseCategory> ExerciseCategories { get; set; }
    }
}
