using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Management.Safes
{
    public class SafeService : ManagementAppService,ISafeService
    {
        private ISafeRepository _safeRepository;

        public SafeService(ISafeRepository safeRepository)
        {
            _safeRepository = safeRepository;
        }

        public async Task<decimal> GetBalance()
        {
            return (await _safeRepository.GetBalance());
        }
    }
}
