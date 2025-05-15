using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Shared.Enum;

namespace Talabat.Shared.QueryParams
{
   public class ProductQueryParams
    {
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public ProductSortingOption SortingOption { get; set; }
        public string? SearchValue { get; set; }
    }

}
