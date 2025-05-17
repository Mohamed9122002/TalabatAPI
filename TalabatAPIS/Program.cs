
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Talabat.APIS.CustomMiddlewares;
using Talabat.APIS.Extensions;
using Talabat.APIS.Factories;
using Talabat.DomainLayer.Contracts;
using Talabat.Persistence;
using Talabat.Persistence.Data.DbContexts;
using Talabat.Persistence.Data.Repositories;
using Talabat.ServiceAbstraction;
using Talabat.ServiceImplemention;
using Talabat.ServiceImplemention.MappingProfiles;
using Talabat.Shared.ErrorModles;

namespace TalabatAPIS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddWebApplicationServices();

            #endregion

            var app = builder.Build();
            await app.SeedDataBaseAync();

            // Configure the HTTP request pipeline.
            app.UseCustomExceptionMiddleWare();
            #region  Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseAuthorization();

            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
