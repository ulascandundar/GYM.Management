using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.AppointmentTransactions
{
    public interface IAppointmentTransactionRepository : IRepository<AppointmentTransaction>
    {
    }
}
