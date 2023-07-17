using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Members
{
    public class MemberCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirdthDate { get; set; }
        public string Telephone { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
