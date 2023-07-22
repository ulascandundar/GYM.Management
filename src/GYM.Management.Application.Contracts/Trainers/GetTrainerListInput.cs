using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Trainers
{
    public class GetTrainerListInput : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
        public bool IsPay { get; set; }
    }
}
