using Talabat.APIS.CustomMiddlewares;
using Talabat.DomainLayer.Contracts;

namespace Talabat.APIS.Extensions
{
    public static class WebApplicationServicesRegistration
    {
        public static async Task SeedDataBaseAync(this WebApplication webApplication)
        {
            var scope = webApplication.Services.CreateScope();
            var objectDataSeeding = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            // Get the Service Provider
            await objectDataSeeding.DataSeedAsync();
        }
        public static IApplicationBuilder UseCustomExceptionMiddleWare(this IApplicationBuilder app)
        {
            // Add Application Services
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            return app;

        }
    }
}
