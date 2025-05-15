using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.ServiceAbstraction;
using Talabat.Shared.Enum;
using Talabat.Shared.ProductsDTo;

namespace Talabat.Presentation.Controllers
{
    public class ProductController(IServiceManager _serviceManager) : BaseApiController
    {
        // get All Product 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(int? BrandId, int?TypeId, ProductSortingOption  SortingOption)
        {
            var Products = await _serviceManager.ProductService.GetAllProductsAsync(BrandId, TypeId, SortingOption);
            return Ok(Products);
        }
        // get Product By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var Product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(Product);
        }
        // Get All Types 
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var Types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }
        // Get All Brands
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var Brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }

    }
}
