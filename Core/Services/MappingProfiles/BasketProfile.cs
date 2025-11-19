using AutoMapper;
using Domain.Entities.BasketModule;
using Shared.DTOs.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile() 
        {
            CreateMap<BasketDto, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDto,BasketItem>().ReverseMap();

        }


    }
}
