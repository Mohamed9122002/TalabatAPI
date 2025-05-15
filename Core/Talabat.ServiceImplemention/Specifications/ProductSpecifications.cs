using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models.ProductModel;
using Talabat.Shared.Enum;

namespace Talabat.ServiceImplemention.Specifications
{
    class ProductSpecifications : BaseSpecifications<Product, int>
    {
        // Get All Products With ProductBrand And ProductType
        public ProductSpecifications(int? BrandId, int? TypeId ,ProductSortingOption SortingOption) : base(P => (!BrandId.HasValue || P.BrandId == BrandId) && (!TypeId.HasValue || P.TypeId == TypeId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            switch(SortingOption)
            {
                case ProductSortingOption.PriceAscending:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOption.PriceDescending:
                    AddOrderByDescending(p => p.Price);
                    break;
                case ProductSortingOption.NameAscending:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOption.NameDescending:
                    AddOrderByDescending(p => p.Name);
                    break;
                default:
                    AddOrderBy(p => p.Id);
                    break;
            }

        }
        // Get Product By Id With ProductBrand And ProductType
        public ProductSpecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
