using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.AppointmentTransactions
{
    public class AppointmentTransactionCreateDto:FullAuditedEntityDto<Guid>
    {
        public Guid MemberId { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage ="Randevu Tarihi Zorunludur")]
        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(3);
    }
}
