using GYM.Management.Safes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.DbMigrator.Data
{
    public class SampleDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ISafeRepository _safeRepository;

        public SampleDataSeedContributor(ISafeRepository safeRepository)
        {
            _safeRepository = safeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateSafe();
        }

        private async Task CreateSafe()
        {
            if (!(await _safeRepository.AnyAsync()))
            {
                await _safeRepository.InsertAsync(new Safe { });
            }
            
        }
    }
}
