using ServiceAbstraction.Contracts;
using Services.Services;
using System.Reflection.Metadata;

namespace E_Commerce.API.Extensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection Services)
        {
            Services.AddAutoMapper(cfg => { }, typeof(AssemblyReference).Assembly);
            Services.AddScoped<IServiceManager, ServiceManager>();
            return Services;
        }



    }
}
