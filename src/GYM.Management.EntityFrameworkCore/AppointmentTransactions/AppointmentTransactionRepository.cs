using GYM.Management.EntityFrameworkCore;
using GYM.Management.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GYM.Management.AppointmentTransactions
{
    public class AppointmentTransactionRepository : EfCoreRepository<ManagementDbContext, AppointmentTransaction, Guid>, IAppointmentTransactionRepository
    {
        public AppointmentTransactionRepository(IDbContextProvider<ManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}
