using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Models.ProductModel;
using Talabat.Shared.QueryParams;

namespace Talabat.ServiceImplemention.Specifications
{
    public class ProductCountSpecifications : BaseSpecifications<Product, int>
    {
        public ProductCountSpecifications(ProductQueryParams queryParams) : base(P => (!queryParams.BrandId.HasValue || P.BrandId == queryParams.BrandId)
            && (!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId)
            && (string.IsNullOrWhiteSpace(queryParams.SearchValue) || P.Name.ToLower().Contains(queryParams.SearchValue.ToLower()) || P.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
        {
        }
    }
}
