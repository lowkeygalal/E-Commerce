using Shared.DTOs.BasketModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Contracts
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketAsync(string id);
        Task<bool> DeleteBasketAsync(string id);
        Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basketDto);

    }
}
