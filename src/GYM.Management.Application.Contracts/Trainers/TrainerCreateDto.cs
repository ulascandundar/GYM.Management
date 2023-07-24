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
        [MinLength(10,ErrorMessage ="Telefon 10 haneden az olamaz"),MaxLength(11,ErrorMessage ="Telefon 11 haneden fazla olamaz")]
        public string Telephone { get; set; }
        public decimal Salary { get; set; }
        [Range(0,100,ErrorMessage = "Kar oranı 0 ile 100 arası olmalıdır")]
        public decimal ProfitRate { get; set; }

    }
}
