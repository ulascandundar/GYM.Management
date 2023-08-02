using GYM.Management.Expenses;
using GYM.Management.ExpenseTypes;
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
        private readonly IExpenseTypeRepository _expenseTypeRepository; 
        public SampleDataSeedContributor(ISafeRepository safeRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _safeRepository = safeRepository;
            _expenseTypeRepository= expenseTypeRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateSafe();
            await CreateExpenseType();
        }

        private async Task CreateSafe()
        {
            if (!(await _safeRepository.AnyAsync()))
            {
                await _safeRepository.InsertAsync(new Safe { });
            }
            
        }

        private async Task CreateExpenseType()
        {
            if (!(await _expenseTypeRepository.AnyAsync()))
            {
                await _expenseTypeRepository.InsertAsync(new ExpenseType(Guid.Parse(StaticConsts.Wallet))
                { Description = "Cüzdan", Name = "Cüzdan", IsEffect = true, IsStatic =true });
                await _expenseTypeRepository.InsertAsync(new ExpenseType(Guid.Parse(StaticConsts.StockOrder))
                { Description = "Stok Siparişi", Name = "Stok Siparişi", IsEffect = true, IsStatic = true });
                await _expenseTypeRepository.InsertAsync(new ExpenseType(Guid.Parse(StaticConsts.SalaryId))
                { Description = "Maaş Ödeme", Name = "Maaş Ödeme", IsEffect = true, IsStatic = true });
                await _expenseTypeRepository.InsertAsync(new ExpenseType(Guid.Parse(StaticConsts.StockLeakId))
                { Description = "Stok Kaybı", Name = "Stok Kaybı", IsEffect = false, IsStatic = true });
                await _expenseTypeRepository.InsertAsync(new ExpenseType(Guid.Parse(StaticConsts.Loss))
                { Description = "Zaiyat", Name = "Zaiyat", IsEffect = false, IsStatic = true });
                await _expenseTypeRepository.InsertAsync(new ExpenseType(Guid.Parse(StaticConsts.Spending))
                { Description = "Diğer", Name = "Diğer", IsEffect = true, IsStatic = true });
            }
        }
    }
}
