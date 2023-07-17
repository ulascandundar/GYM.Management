using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.Members
{
    public interface IMemberService : ICrudAppService<MemberDto, Guid, PagedAndSortedResultRequestDto, MemberCreateDto>
    {
        Task AddDto(MemberCreateDto memberCreateDto);
        Task<PagedResultDto<MemberDto>> GetListAsync(GetMemberListInput input);
    }
}
