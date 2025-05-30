﻿using Talabat.DomainLayer.Exceptions;
using Talabat.Shared.ErrorModles;

namespace Talabat.APIS.CustomMiddlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate Next, ILogger<CustomExceptionHandlerMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
                await HandleNotFoundEndPontAsync(httpContext);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Something Went Wrong");

                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            // Response Object 
            var response = new ErrorToReturn()
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = exception.Message
            };
            // Statuscode For Response 
            response.StatusCode = exception switch
            {
                // Custom Exception 
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                BadRequestException badRequestErrors => GetBadRequestErrors(badRequestErrors, response),
                // Default Exception 
                _ => StatusCodes.Status500InternalServerError
            };
            httpContext.Response.StatusCode = response.StatusCode;
            // Return Object As JSON
            await httpContext.Response.WriteAsJsonAsync(response);
        }

        private static int GetBadRequestErrors(BadRequestException badRequestErrors, ErrorToReturn response)
        {
            response.Errors = badRequestErrors.Errors; 
            return StatusCodes.Status400BadRequest;
        }

        private static async Task HandleNotFoundEndPontAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                httpContext.Response.ContentType = "application/json";
                var response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = $"End Point {httpContext.Request.Path} is Not Found"
                };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
