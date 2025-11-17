using Domain.Entities.ProductModule;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductCountSpecifications : BaseSpecifications<Product,int>
    {
        public ProductCountSpecifications(ProductSpecificationParameters parameters)
            : base
            (P =>
                (!parameters.TypeId.HasValue || P.TypeId == parameters.TypeId) &&
                (!parameters.BrandId.HasValue || P.BrandId == parameters.BrandId) &&
               ((string.IsNullOrEmpty(parameters.Search)) || P.Name.ToLower().Contains(parameters.Search.ToLower()))
            )
        {









        }


    }
}
