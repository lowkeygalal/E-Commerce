using AutoMapper;
using Domain.Entities.ProductBrandModule;
using Domain.Entities.ProductModule;
using Domain.Entities.ProductTypeModule;
using Shared.DTOs.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductType,TypeResultDto>();
            CreateMap<ProductBrand, BrandResultDto>();
            CreateMap<Product, ProductResultDto>()
                .ForMember(dest=>dest.BrandName,src=>src.MapFrom(opt=>opt.ProductBrand.Name))
                .ForMember(dest => dest.TypeName, src => src.MapFrom(opt => opt.ProductType.Name))
                .ForMember(dest=>dest.PictureUrl,options=>options.MapFrom<PictureUrlResolver>());





        }


    }
}
