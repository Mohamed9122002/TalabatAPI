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
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(int? BarndId ,int ? TypeId);
        // Get Product By Id
        Task<ProductDto> GetProductByIdAsync(int Id);
        // Get Product By Brand
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        // Get Product By Type
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

    }
}