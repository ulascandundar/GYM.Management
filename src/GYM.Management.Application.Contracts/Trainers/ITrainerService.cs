using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.Trainers
{
    public interface ITrainerService : ICrudAppService<TrainerDto, Guid, PagedAndSortedResultRequestDto, TrainerCreateDto>
    {
        Task<List<TrainerDto>> GetAllTrainerForMember();
        Task PaySalary(Guid trainerId);
        Task DeleteAsyncById(Guid id);
        Task<List<TrainerDto>> GetPaymentDuoTrainer();
    }
}
