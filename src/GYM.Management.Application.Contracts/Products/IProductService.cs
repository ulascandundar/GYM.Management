using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GYM.Management.Products
{
    public interface IProductService : ICrudAppService<ProductDto, Guid, PagedAndSortedResultRequestDto, ProductCreateDto>
    {
    }
}
