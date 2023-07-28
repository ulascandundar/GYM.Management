using System;
using System.Collections.Generic;
using System.Text;

namespace GYM.Management.AppointmentTransactions
{
    public class AppointmentTransactionCreateDto
    {
        public Guid MemberId { get; set; }
        public string? Description { get; set; }
    }
}
