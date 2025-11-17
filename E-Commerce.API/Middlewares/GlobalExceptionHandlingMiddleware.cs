using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Shared.ErrorModels;

namespace E_Commerce.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next; //pass the request to the next middleware
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;//log the error on the console

        public GlobalExceptionHandlingMiddleware(RequestDelegate next,ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _next=next;
            _logger=logger;
        }

        public async Task InvokeAsync(HttpContext context) //a method which is invoked on every request by ASP.NET Core
        {
            try 
            { 
            await _next(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                    await HandleNotFoundApiAsync(context);

            }
            catch(Exception ex)
            {
                _logger.LogError($"something went wrong ======> {ex.Message}");
                await HandleExceptionAsync(context,ex);
            }
            //لو صح اديه للي بعدي لو غلط اعمله لوج ف الكونسول وابعته للفانكشن الي تحت دي تهندله
        }

        private async Task HandleNotFoundApiAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var response = new ErrorDetails()
            {
                StatusCode = StatusCodes.Status404NotFound,
                ErrorMessage = $"The Endpoint with url {context.Request.Path} is not found"
            }.ToString();

            await context.Response.WriteAsync(response);

        }

        private async Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                (_) => StatusCodes.Status500InternalServerError

            };

            context.Response.ContentType = "application/json";

            var response = new ErrorDetails()
            {
                StatusCode=context.Response.StatusCode,
                ErrorMessage=ex.Message
            }.ToString();

           await context.Response.WriteAsync(response);
        }

    }
}
