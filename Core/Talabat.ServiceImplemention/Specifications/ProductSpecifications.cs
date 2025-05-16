using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models.ProductModel;
using Talabat.Shared.Enum;
using Talabat.Shared.QueryParams;

namespace Talabat.ServiceImplemention.Specifications
{
    class ProductSpecifications : BaseSpecifications<Product, int>
    {
        // Get All Products With ProductBrand And ProductType
        public ProductSpecifications(ProductQueryParams queryParams)
            : base(P => (!queryParams.BrandId.HasValue || P.BrandId == queryParams.BrandId)
            && (!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId)
            && (string.IsNullOrWhiteSpace(queryParams.SearchValue) || P.Name.ToLower().Contains(queryParams.SearchValue.ToLower()) || P.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            // Add Pagination
            ApplyPaging(queryParams.PageSize,queryParams.PageIndex);
            switch (queryParams.SortingOption)
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
