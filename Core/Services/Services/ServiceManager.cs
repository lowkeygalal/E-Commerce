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
    public class ServiceManager(IUnitOfWork _unitOfWork,IMapper _mapper) : IServiceManager
    {
        private readonly Lazy<IProductService> _productService = new Lazy<IProductService>
            (()=>new ProductService(_unitOfWork,_mapper));

        public IProductService productService => _productService.Value;
    }
}
