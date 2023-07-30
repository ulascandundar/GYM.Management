using GYM.Management.Expenses;
using GYM.Management.Permissions;
using GYM.Management.Wallets;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace GYM.Management.Trainers
{
    public class TrainerService : CrudAppService<
        Trainer,
        TrainerDto,
        Guid,
        PagedAndSortedResultRequestDto,
        TrainerCreateDto>,
    ITrainerService
    {
        public TrainerService(IRepository<Trainer, Guid> repository) : base(repository)
        {
			GetPolicyName = ManagementPermissions.Trainer.Default;
			GetListPolicyName = ManagementPermissions.Trainer.Default;
			CreatePolicyName = ManagementPermissions.Trainer.Create;
			UpdatePolicyName = ManagementPermissions.Trainer.Edit;
			DeletePolicyName = ManagementPermissions.Trainer.Delete;
		}
        [Authorize(ManagementPermissions.Trainer.Delete)]
        public async Task DeleteAsyncById(Guid id)
        {
            var query = (await Repository.GetQueryableAsync()).Where(o=>o.Id==id).SelectMany(o => o.Members).Where(o=>o.IsDeleted==false);
            var result = await AsyncExecuter.CountAsync(query);
            if (result>0)
            {
                throw new UserFriendlyException("Bu antrenörün aktif olarak hizmet verdiği üye var öncelikle üye ile ilişkisini kesiniz",
                    "Bu antrenörün aktif olarak hizmet verdiği üye var öncelikle üye ile ilişkisini kesiniz");
            }
            await DeleteAsync(id);
        }
        
        public async Task<List<TrainerDto>> GetAllTrainerForMember()
        {
            var result = await Repository.GetListAsync();
            return  ObjectMapper.Map<List<Trainer>,List<TrainerDto>>(result);
        }
        [Authorize(ManagementPermissions.Trainer.Edit)]
        public async Task PaySalary(Guid trainerId)
        {
            var trainer = await Repository.GetAsync(trainerId);
            trainer.lastSalaryDate = DateTime.UtcNow;
            trainer.Expenses.Add(new Expense
            {
                Amount = trainer.Salary,
                Description = "Maaş Ödemesi",
                ExpenseType = ExpenseType.Salary,
                Date = DateTime.UtcNow
            });
        }

        public async Task<List<TrainerDto>> GetPaymentDuoTrainer()
        {
            DateTime currentDate = DateTime.UtcNow;
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;
            var test = new DateTime(currentDate.Year, currentDate.Month, 1);
            var query = await Repository.GetQueryableAsync();
            query = query.Where(o => (o.lastSalaryDate == null)  || o.lastSalaryDate < new DateTime (currentDate.Year,currentDate.Month,1));
            var result = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<Trainer>, List<TrainerDto>>(result);
        }
        [Authorize(ManagementPermissions.Trainer.Create)]
        public async Task AddAsync(TrainerCreateDto dto)
        {
            var trainer = ObjectMapper.Map<TrainerCreateDto, Trainer>(dto);
            trainer.Wallet = new Wallet { };
            await Repository.InsertAsync(trainer);
        }

        public async Task<PagedResultDto<TrainerDto>> GetListAsync(GetTrainerListInput input)
        {
            var query = await Repository.GetQueryableAsync();
            if (!input.Name.IsNullOrWhiteSpace())
            {
                input.Name = input.Name.ToLower();
                query = query.Where(o => o.Name.ToLower().Contains(input.Name));
            }
            if (input.IsPay)
            {
                DateTime currentDate = DateTime.UtcNow;
                query = query.Where(o => (o.lastSalaryDate == null) || o.lastSalaryDate < new DateTime(currentDate.Year, currentDate.Month, 1));
            }
            var totalCount = await AsyncExecuter.CountAsync(query);
            query = query.OrderBy(string.IsNullOrWhiteSpace(input.Sorting)
                ? "CreationTime desc"
                : input.Sorting);

            query = query.PageBy(input);
            var result = await AsyncExecuter.ToListAsync(query);
            var listDto = ObjectMapper.Map<List<Trainer>, List<TrainerDto>>(result);
            return new PagedResultDto<TrainerDto>(totalCount, listDto);
        }
    }
}
