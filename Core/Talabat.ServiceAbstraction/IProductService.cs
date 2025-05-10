using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Shared.ProductsDTo;

namespace Talabat.ServiceAbstraction
{
    public interface IProductService
    {
        // Get All Product 
        Task<IEnumerable<ProductDto>> GetAllProductSAsync();
        // Get Product By Id
        Task<ProductDto> GetProductByIdAsync(int Id);
        // Get Product By Brand
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync(string brand);
        // Get Product By Type
        Task<IEnumerable<TypeDto>> GetAllTypesAsync(string type);

    }
}