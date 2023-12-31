﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.AppointmentTransactions
{
    public interface IAppointmentTransactionService : ICrudAppService<AppointmentTransactionDto, Guid, PagedAndSortedResultRequestDto, AppointmentTransactionCreateDto>
    {
        Task<PagedResultDto<AppointmentTransactionDto>> GetListAsync(GetAppointmentTransactionListInput input);

        Task UpdateDescription(AppointmentTransactionCreateDto dto);
        Task Cancel(Guid id);
        Task<List<AppointmentTransactionDto>> GetListAsyncForUser();
    }
}
