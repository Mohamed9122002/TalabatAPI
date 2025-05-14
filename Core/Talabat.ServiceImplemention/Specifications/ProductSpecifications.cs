using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models.ProductModel;

namespace Talabat.ServiceImplemention.Specifications
{
    class ProductSpecifications : BaseSpecifications<Product, int>
    {
        // Get All Products With ProductBrand And ProductType
        public ProductSpecifications(int? BrandId, int? TypeId) : base(P => (!BrandId.HasValue || P.BrandId == BrandId) && (!TypeId.HasValue || P.TypeId == TypeId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

        }
        // Get Product By Id With ProductBrand And ProductType
        public ProductSpecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
