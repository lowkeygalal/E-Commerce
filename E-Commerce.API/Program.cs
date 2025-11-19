using Domain.Contracts;
using E_Commerce.API.Extensions;
using E_Commerce.API.Factories;
using E_Commerce.API.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; 
using Persistence.Data;
using Persistence.Data.Contexts;
using Persistence.Repositories;
using ServiceAbstraction.Contracts;
using Services;
using Services.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region DI Container

            var builder = WebApplication.CreateBuilder(args);
            
            #region WebApiServices
            builder.Services.AddWebApiServices();
            #endregion

            #region AddInfrastructureServices
            builder.Services.AddInfrastructureServices(builder.Configuration);
            #endregion

            #region AddCoreServices
            builder.Services.AddCoreServices();
            #endregion

            #endregion

            #region Pipelines - Middlewares
            var app = builder.Build();
            await app.SeedDatabaseAsync();

            app.UseExceptionHandlingMiddlewares();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
