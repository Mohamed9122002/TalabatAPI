using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models.ProductModel;
using Talabat.ServiceAbstraction;
using Talabat.ServiceImplemention.Specifications;
using Talabat.Shared.Enum;
using Talabat.Shared.ProductsDTo;

namespace Talabat.ServiceImplemention
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(int ? BrandId, int? TypeId ,ProductSortingOption SortingOption)
        {
            var Specification = new ProductSpecifications(BrandId, TypeId , SortingOption);
            var Repository = _unitOfWork.GenericRepository<Product, int>();
            var Products = await Repository.GetAllAsync(Specification);

            //Mapping Product To ProductDto
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
        }
        public async Task<ProductDto> GetProductByIdAsync(int Id)
        {
            var Specification = new ProductSpecifications(Id);
            var Repository = _unitOfWork.GenericRepository<Product, int>();
            var Product = await Repository.GetByIdAsync(Specification);

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
