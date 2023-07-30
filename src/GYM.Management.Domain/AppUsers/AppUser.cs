using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace GYM.Management.AppUsers
{
    public class AppUser : IdentityUser
    {
        public Guid? TrainerId { get; set; }
    }
}
