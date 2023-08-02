using GYM.Management.Claims;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace GYM.Management.AppointmentTransactions
{
    public class AppointmentTransactionService : CrudAppService<
        AppointmentTransaction,
        AppointmentTransactionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        AppointmentTransactionCreateDto>,
    IAppointmentTransactionService
    {
        private readonly IDataFilter _dataFilter;
        private readonly ICurrentUser _currentUser;
        public AppointmentTransactionService(IDataFilter dataFilter, IRepository<AppointmentTransaction, Guid> repository,ICurrentUser currentUser) : base(repository)
        {
            _dataFilter = dataFilter;
            _currentUser = currentUser;
        }
        [Authorize]
        public async Task<PagedResultDto<AppointmentTransactionDto>> GetListAsync(GetAppointmentTransactionListInput input)
        {
            var userType = _currentUser.GetUserType();
            var query = await Repository.GetQueryableAsync();
            query = query.Where(o => o.IsDeleted == false);
            //if (!input.Description.IsNullOrWhiteSpace())
            //{
            //    input.Description = input.Description.ToLower();
            //    query = query.Where(o => o.Description.ToLower().Contains(input.Description));
            //}
            if (input.MemberId != null)
            {
                query = query.Where(o => o.MemberId == input.MemberId);
            }
            if (input.TrainerId!=null)
            {
                query = query.Where(o => o.TrainerId == input.TrainerId);
            }
            if (userType == "Trainer")
            {
                query = query.Where(o => o.TrainerId == _currentUser.Id);
            }
            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.OrderBy(string.IsNullOrWhiteSpace(input.Sorting)
                ? "CreationTime desc"
                : input.Sorting);

            query = query.PageBy(input);
            using (_dataFilter.Disable<ISoftDelete>())
            {
                var result = await AsyncExecuter.ToListAsync(query);
                var listDto = ObjectMapper.Map<List<AppointmentTransaction>, List<AppointmentTransactionDto>>(result);
                foreach (var item in listDto)
                {
                    item.TrainerName = item.TrainerId == null ? null : result.Where(o => o.Id == item.Id)
                    .Select(o => o.Trainer.Name).FirstOrDefault();
                    item.MemberName = item.TrainerId == null ? null : result.Where(o => o.Id == item.Id)
                    .Select(o => o.Member.Name).FirstOrDefault();
                }
                return new PagedResultDto<AppointmentTransactionDto>(totalCount, listDto);
            }

        }

        public async Task UpdateDescription(AppointmentTransactionCreateDto dto)
        {
            var transaction = await Repository.GetAsync(dto.Id);
            transaction.Description = dto.Description;
            await Repository.UpdateAsync(transaction);
        }

        public async Task Cancel(Guid id)
        {
            var transaction = await Repository.GetAsync(id);
            if (transaction.Date.AddDays(3) > DateTime.UtcNow)
            {
                throw new UserFriendlyException("İlgili tarih geçildiği için bu randevu iptal edilemez", "İlgili tarih geçildiği için bu randevu iptal edilemez");
            }
            transaction.Member.AppointmentStock++;
            await Repository.DeleteAsync(transaction);
        }
    }
}
