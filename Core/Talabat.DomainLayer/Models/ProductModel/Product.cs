using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.DomainLayer.Models.ProductModel
{
   public class Product : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string PictureUrl { get; set; } = null!;
        public decimal Price { get; set; } 
        // Navigation properties 
        public ProductBrand ProductBrand { get; set; }
        public int BrandId { get; set; } // Freign key
        public ProductType ProductType { get; set; }
        public int TypeId { get; set; } // Freign key
    }
}
