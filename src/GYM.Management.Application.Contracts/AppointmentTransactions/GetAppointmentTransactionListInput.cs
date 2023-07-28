using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.AppointmentTransactions
{
    public class GetAppointmentTransactionListInput : PagedAndSortedResultRequestDto
    {
        public Guid? MemberId { get; set; }
        public Guid? TrainerId { get; set; }
    }
}
