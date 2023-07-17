using GYM.Management.Trainers;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Members
{
    public class MemberDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public DateTime BirdthDate { get; set; }
        public string Telephone { get; set; }
        public Guid? TrainerId { get; set; }
        public TrainerDto Trainer { get; set; }
        public string TrainerName { get; set; }
    }
}
