﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GYM.Management.Debts
{
    public interface IDebtService : IApplicationService
    {
        Task<List<DebtDto>> GetDebt(Guid memberId);
        Task Pay(Guid debtId);
        Task Create(DebtDto dto);
    }
}
