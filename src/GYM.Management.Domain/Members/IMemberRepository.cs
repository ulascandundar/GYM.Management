﻿using GYM.Management.MemberOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.Members
{
    public interface IMemberRepository : IRepository<Member>
    {
    }
}
