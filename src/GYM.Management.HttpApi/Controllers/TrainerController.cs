using GYM.Management.Trainers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace GYM.Management.Controllers
{
    [Route("api/trainers")]
    public class TrainerController : AbpController
    {
        private ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        [HttpGet]
        public async Task<ListResultDto<TrainerForUserDto>> GetAsync()
        {
            var list = new List<TrainerForUserDto>() { new TrainerForUserDto { Id=null,Name=""} };
            var result = await _trainerService.GetAllTrainerForUser();
            return new ListResultDto<TrainerForUserDto> { Items = result};
        }
    }
}
