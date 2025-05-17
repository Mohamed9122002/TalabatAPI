using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Exceptions;
using Talabat.DomainLayer.Models.ProductModel;
using Talabat.ServiceAbstraction;
using Talabat.ServiceImplemention.Specifications;
using Talabat.Shared;
using Talabat.Shared.DataTransferObject.ProductsDTo;
using Talabat.Shared.Enum;
using Talabat.Shared.QueryParams;

namespace Talabat.ServiceImplemention
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var Repository = _unitOfWork.GenericRepository<Product, int>();
            var Specification = new ProductSpecifications(queryParams);
            var Products = await Repository.GetAllAsync(Specification);

            //Mapping Product To ProductDto
            var Data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
            var ProductCount = Products.Count();
            var TotalCount = await Repository.CountAsync(new ProductCountSpecifications(queryParams));
            return new PaginatedResult<ProductDto>(queryParams.PageIndex, ProductCount, TotalCount, Data);

        }
        public async Task<ProductDto> GetProductByIdAsync(int Id)
        {
            var Specification = new ProductSpecifications(Id);
            var Repository = _unitOfWork.GenericRepository<Product, int>();
            var Product = await Repository.GetByIdAsync(Specification);
            if (Product is null)
            {
                throw new ProductNotFoundException(Id);

            }
            //Mapping Product To ProductDto
            return _mapper.Map<Product, ProductDto>(Product);
        }
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Repository = _unitOfWork.GenericRepository<ProductBrand, int>();
            var Barnds = await Repository.GetAllAsync();
            //Mapping ProductBarnd To BarndDto
            return _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Barnds);
        }


        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Repository = _unitOfWork.GenericRepository<ProductType, int>();
            var Types = await Repository.GetAllAsync();
            //Mapping ProductType To TypeDto
            return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
        }
    }
}
