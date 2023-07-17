using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GYM.Management.Trainers
{
    public class TrainerCreateDto
    {
        [Required(ErrorMessage = "İsim zorunludur")]
        public string Name { get; set; }
        public string? Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirdthDate { get; set; }
        public string Telephone { get; set; }
        public decimal Salary { get; set; }

    }
}
