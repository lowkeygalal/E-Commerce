using Domain.Entities.ProductModule;
using Shared;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecification:BaseSpecifications<Product,int>
    {
        #region GetAllProducts Constructor
        public ProductWithBrandAndTypeSpecification(ProductSpecificationParameters parameters) : base
            (P => 
                (!parameters.TypeId.HasValue || P.TypeId == parameters.TypeId) &&
                (!parameters.BrandId.HasValue || P.BrandId == parameters.BrandId) &&
               ((string.IsNullOrEmpty(parameters.Search)) || P.Name.ToLower().Contains(parameters.Search.ToLower()))
            )
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
            switch(parameters.Sort)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;

                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;

                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;

                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            ApplyPagination(parameters.PageSize, parameters.PageIndex);


        }
        #endregion

        //this ctor for where with id
        #region GetProductById Constructor
        public ProductWithBrandAndTypeSpecification(int id) : base(P => P.Id == id)
        {
            AddIncludes(p => p.ProductBrand);
            AddIncludes(p => p.ProductType);
        } 
        #endregion

    }
}
