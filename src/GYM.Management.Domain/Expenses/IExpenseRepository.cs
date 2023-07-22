﻿using GYM.Management.Gains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.Expenses
{
    public interface IExpenseRepository : IRepository<Expense>
    {
    }
}
