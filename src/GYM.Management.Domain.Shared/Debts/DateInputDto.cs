using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.Debts
{
    public class DateInputDto
    {
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
    }
}
