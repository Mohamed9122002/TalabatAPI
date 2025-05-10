
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.Persistence;
using Talabat.Persistence.Data.DbContexts;
using Talabat.Persistence.Data.Repositories;
using Talabat.ServiceAbstraction;
using Talabat.ServiceImplemention.MappingProfiles;

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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(Options =>
                {
                    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(ProductProfiles).Assembly);
            builder.Services.AddScoped<IServiceManager, IServiceManager>();


            #endregion

            var app = builder.Build();
            var scope = app.Services.CreateScope();
            var objectDataSeeding = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            // Get the Service Provider
            await objectDataSeeding.DataSeedAsync();

            // Configure the HTTP request pipeline.
            #region  Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
