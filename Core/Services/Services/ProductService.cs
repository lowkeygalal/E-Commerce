using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductBrandModule;
using Domain.Entities.ProductModule;
using Domain.Entities.ProductTypeModule;
using Domain.Exceptions;
using ServiceAbstraction.Contracts;
using Services.Specifications;
using Shared;
using Shared.DTOs.ProductModule;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        #region GetAllBrands
        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {
            var Brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var BrandsResult = _mapper.Map<IEnumerable<BrandResultDto>>(Brands);
            return BrandsResult;
        } 
        #endregion

        #region GetAllProducts
        public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters parameters)
        {
            var specifications = new ProductWithBrandAndTypeSpecification(parameters);
            var Products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
            var ProductsResult = _mapper.Map<IEnumerable<ProductResultDto>>(Products);
            var pageSize = ProductsResult.Count();
            var countSpecifications = new ProductCountSpecifications(parameters);
            var totalCount = await _unitOfWork.GetRepository<Product, int>().CountAsync(countSpecifications);
            return new PaginatedResult<ProductResultDto>(parameters.PageIndex, pageSize, totalCount, ProductsResult);
        } 
        #endregion

        #region GetAllTypes
        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var TypesResult = _mapper.Map<IEnumerable<TypeResultDto>>(Types);
            return TypesResult;
        } 
        #endregion

        #region GetProductById
        public async Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            var specifications = new ProductWithBrandAndTypeSpecification(id);

            var Product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specifications);

            return Product is null?
                throw new ProductNotFoundException(id) :
                _mapper.Map<ProductResultDto>(Product);
        } 
        #endregion
    }
}
