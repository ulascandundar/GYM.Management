using GYM.Management.Expenses;
using GYM.Management.Permissions;
using GYM.Management.StockTakings;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GYM.Management.Products
{
    public class ProductService : CrudAppService<
        Product,
        ProductDto,
        Guid,
        PagedAndSortedResultRequestDto,
        ProductCreateDto>,
    IProductService
    {
        private readonly IStockTakingRepository _stockTakingRepository;
        private readonly IExpenseRepository _expenseRepository;
        public ProductService(IRepository<Product, Guid> repository, IStockTakingRepository stockTakingRepository, IExpenseRepository expenseRepository) : base(repository)
        {
            GetPolicyName = ManagementPermissions.Product.Default;
            GetListPolicyName = ManagementPermissions.Product.Default;
            CreatePolicyName = ManagementPermissions.Product.Create;
            UpdatePolicyName = ManagementPermissions.Product.Edit;
            DeletePolicyName = ManagementPermissions.Product.Delete;
            _stockTakingRepository= stockTakingRepository;
            _expenseRepository= expenseRepository;
        }
        [Authorize(ManagementPermissions.Product.StockTaking)]
        public async Task StockTaking(StockTakingCreateDto dto)
        {
            var product = await Repository.GetAsync(dto.ProductId);
            await _stockTakingRepository.InsertAsync(new StockTaking { Description= dto.Description,ProductName = product.Name,NewStock = dto.NewStock,
            OldStock = product.Stock});
            if (product.Stock > dto.NewStock)
            {
                await _expenseRepository.InsertAsync(new Expense { Amount = (product.Stock-dto.NewStock) * product.StockPrice,Date= DateTime.UtcNow,
                ExpenseType = ExpenseType.StockLeak,Description = $"{product.Name} isimli üründe yapılan stok sayımında {product.Stock - dto.NewStock}" +
                $" adet eksiğe rastlandı"});
            }
            product.Stock = dto.NewStock;
            await Repository.UpdateAsync(product);
        }
        [Authorize(ManagementPermissions.Product.StockOrder)]
        public async Task StockOrder(StockOrderCreateDto stockOrderCreateDto)
        {
            var product = await Repository.GetAsync(stockOrderCreateDto.ProductId);
            product.Stock += stockOrderCreateDto.Quantity;
            await _expenseRepository.InsertAsync(new Expense
            {
                Description = stockOrderCreateDto.Description +$" {product.Name} isimli üründen {stockOrderCreateDto.Quantity} adet sipariş edildi",
                Amount = product.StockPrice * stockOrderCreateDto.Quantity,
                Date = DateTime.UtcNow,
                ExpenseType = ExpenseType.StockOrder
            });
            await Repository.UpdateAsync(product);
        }
    }
}
