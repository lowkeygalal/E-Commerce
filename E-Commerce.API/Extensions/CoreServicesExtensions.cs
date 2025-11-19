using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction.Contracts;
using Services.Services;

namespace E_Commerce.API.Extensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection Services)
        {
            Services.AddAutoMapper(cfg => {}, typeof(AssemblyReference).Assembly);
            Services.AddScoped<IServiceManager, ServiceManager>();
            return Services;
        }



    }
}
