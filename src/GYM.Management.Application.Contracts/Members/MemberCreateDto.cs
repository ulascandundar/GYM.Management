using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GYM.Management.Members
{
    public class MemberCreateDto
    {
        public string Name { get; set; }
        public DateTime BirdthDate { get; set; }
        [MinLength(10, ErrorMessage = "Telefon 10 haneden az olamaz"), MaxLength(11, ErrorMessage = "Telefon 11 haneden fazla olamaz")]
        public string Telephone { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
