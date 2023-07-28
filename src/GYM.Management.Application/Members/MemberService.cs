using GYM.Management.AppointmentTransactions;
using GYM.Management.Permissions;
using GYM.Management.Trainers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace GYM.Management.Members
{
    public class MemberService : CrudAppService<
        Member,
        MemberDto,
        Guid,
        PagedAndSortedResultRequestDto,
        MemberCreateDto>,
    IMemberService
    {
        private readonly IAppointmentTransactionRepository _appointmentTransactionRepository;
        public MemberService(IRepository<Member, Guid> repository, IAppointmentTransactionRepository appointmentTransactionRepository) : base(repository)
        {
            _appointmentTransactionRepository= appointmentTransactionRepository;
        }
        public Task AddDto(MemberCreateDto memberCreateDto)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<MemberDto>> GetListAsync(GetMemberListInput input)
        {
            var query = await Repository.GetQueryableAsync();
            if (!input.Name.IsNullOrWhiteSpace())
            {
                input.Name = input.Name.ToLower();
                query = query.Where(o => o.Name.ToLower().Contains(input.Name));
            }
            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.OrderBy(string.IsNullOrWhiteSpace(input.Sorting)
                ? "CreationTime desc"
                : input.Sorting);

            query = query.PageBy(input);
            var result = await AsyncExecuter.ToListAsync(query);
            var listDto = ObjectMapper.Map<List<Member>, List<MemberDto>>(result);
            foreach (var item in listDto)
            {
                item.TrainerName = item.TrainerId == null ? null : result.Where(o => o.Id == item.Id)
                .Select(o => o.Trainer.Name).FirstOrDefault();
            }
            return new PagedResultDto<MemberDto>(totalCount, listDto);
        }

        public async Task<List<MemberDto>> GetDebtorMembers()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(o => o.Debt > 0);
            query = query.OrderByDescending(o => o.Debt);

            query = query.Take(5);
            var result = await AsyncExecuter.ToListAsync(query);
            var listDto = ObjectMapper.Map<List<Member>, List<MemberDto>>(result);
            return listDto;
        }

        public async Task CommitAppointment(AppointmentTransactionCreateDto appointmentTransactionCreateDto)
        {
            var member = await GetEntityByIdAsync(appointmentTransactionCreateDto.MemberId);
            member.AppointmentStock--;
            await Repository.UpdateAsync(member);
            await _appointmentTransactionRepository.InsertAsync(new AppointmentTransaction { Description=appointmentTransactionCreateDto.Description,
            MemberId = appointmentTransactionCreateDto.MemberId,OldStock =member.AppointmentStock,TrainerId = (Guid)member.TrainerId});
        }

        public async Task<List<MemberDto>> GetAllMember()
        {
            var result = await Repository.GetListAsync();
            return ObjectMapper.Map<List<Member>, List<MemberDto>>(result);
        }
    }
}
