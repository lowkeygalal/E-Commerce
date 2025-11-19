using AutoMapper;
using Domain.Contracts;
using ServiceAbstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServiceManager(IBasketRepository _basketRepository,IUnitOfWork _unitOfWork,IMapper _mapper) : IServiceManager
    {
        private readonly Lazy<IProductService> _productService = new Lazy<IProductService>
            (()=>new ProductService(_unitOfWork,_mapper));
        private readonly Lazy<IBasketService> _basketService = new Lazy<IBasketService> 
            (()=>new BasketService(_basketRepository, _mapper)); 

        public IProductService productService => _productService.Value;

        public IBasketService basketService => _basketService.Value;
    }
}
