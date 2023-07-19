using GYM.Management.Permissions;
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
        public ProductService(IRepository<Product, Guid> repository) : base(repository)
        {
            GetPolicyName = ManagementPermissions.Product.Default;
            GetListPolicyName = ManagementPermissions.Product.Default;
            CreatePolicyName = ManagementPermissions.Product.Create;
            UpdatePolicyName = ManagementPermissions.Product.Edit;
            DeletePolicyName = ManagementPermissions.Product.Delete;
        }
    }
}
