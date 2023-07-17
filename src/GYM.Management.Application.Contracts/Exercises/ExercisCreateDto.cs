using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Exercises
{
	public class ExercisCreateDto
	{
		[MaxLength(20)]
		[Required]
		public string Name { get; set; }
        [Required]
        public string Description { get; set; }
	}
}
