using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace GYM.Management.Members
{
    public class GetMemberListInput : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }
}
