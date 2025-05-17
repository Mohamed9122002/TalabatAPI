using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models.ProductModel;
using Talabat.Persistence.Data.DbContexts;

namespace Talabat.Persistence
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            try
            {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }
                // Read Data From JSON File
                if (!_dbContext.ProductBrands.Any())
                {
                    using var ProductBrandData = File.OpenRead(@"..\Infrastructure\Talabat.Persistence\Data\DataSeed\brands.json");

                    // Convert Data "String" to C# Object 
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    // Save Data to Database
                    if (ProductBrands is not null && ProductBrands.Any())
                    {
                        await _dbContext.ProductBrands.AddRangeAsync(ProductBrands);
                    }
                }
                if (!_dbContext.ProductTypes.Any())
                {
                    using var ProductTypeData = File.OpenRead(@"..\Infrastructure\Talabat.Persistence\Data\DataSeed\types.json");
                    // Convert Data "String" to C# Object 
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                    // Save Data to Database
                    if (ProductTypes is not null && ProductTypes.Any())
                    {
                        await _dbContext.ProductTypes.AddRangeAsync(ProductTypes);
                    }
                }
                if (!_dbContext.Products.Any())
                {
                    using var ProductData = File.OpenRead(@"..\Infrastructure\Talabat.Persistence\Data\DataSeed\products.json");
                    // Convert Data "String" to C# Object 
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    // Save Data to Database
                    if (Products is not null && Products.Any())
                    {
                        await _dbContext.Products.AddRangeAsync(Products);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
              // Do 
            }
        }
    }
}
