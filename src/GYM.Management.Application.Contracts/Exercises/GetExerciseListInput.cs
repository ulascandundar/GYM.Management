using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Exercises
{
    public class GetExerciseListInput : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }
}
