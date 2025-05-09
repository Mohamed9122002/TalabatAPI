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
        public void DataSeed()
        {
            try
            {
                var pendingMigrations =  _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations.Any())
                {
                     _dbContext.Database.Migrate();
                }
                // Read Data From JSON File
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductBrandData =  File.ReadAllText(@"..\Infrastructure\Talabat.Persistence\Data\DataSeed\brands.json");
                    // Convert Data "String" to C# Object 
                    var ProductBrands =  JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandData);
                    // Save Data to Database
                    if (ProductBrands is not null && ProductBrands.Any())
                    {
                         _dbContext.ProductBrands.AddRange(ProductBrands);
                    }
                }
                if (!_dbContext.ProductTypes.Any())
                {
                    var ProductTypeData = File.ReadAllText(@"..\Infrastructure\Talabat.Persistence\Data\DataSeed\types.json");

                    // Convert Data "String" to C# Object 
                    var ProductTypes =  JsonSerializer.Deserialize<List<ProductType>>(ProductTypeData);
                    // Save Data to Database
                    if (ProductTypes is not null && ProductTypes.Any())
                    {
                         _dbContext.ProductTypes.AddRange(ProductTypes);
                    }
                }
                if (!_dbContext.Products.Any())
                {
                    var ProductData  = File.ReadAllText(@"..\Infrastructure\Talabat.Persistence\Data\DataSeed\products.json");
                    // Convert Data "String" to C# Object 
                    var Products =  JsonSerializer.Deserialize<List<Product>>(ProductData);
                    // Save Data to Database
                    if (Products is not null && Products.Any())
                    {
                        _dbContext.Products.AddRange(Products);
                    }
                }

                 _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
              // ToDo
            }
        }
    }
}
