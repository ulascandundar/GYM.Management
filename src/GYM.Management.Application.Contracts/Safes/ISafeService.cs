using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GYM.Management.Safes
{
    public interface ISafeService : IApplicationService
    {
        Task<decimal> GetBalance();
    }
}
