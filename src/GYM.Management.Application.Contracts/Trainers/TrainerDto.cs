using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Trainers
{
    public class TrainerDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirdthDate { get; set; }
        public string Telephone { get; set; }
        public decimal Salary  { get; set; }
        public DateTime lastSalaryDate { get; set; }
        public decimal ProfitRate { get; set; }
    }
}
