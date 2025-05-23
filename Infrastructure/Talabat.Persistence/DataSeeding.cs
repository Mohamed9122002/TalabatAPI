using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DomainLayer.Contracts;
using Talabat.DomainLayer.Models.IdentityModule;
using Talabat.DomainLayer.Models.OrderModule;
using Talabat.DomainLayer.Models.ProductModel;
using Talabat.Persistence.Data.DbContexts;
using Talabat.Persistence.Data.DbContexts.Identity;

namespace Talabat.Persistence
{
    public class DataSeeding(StoreDbContext _dbContext, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager, StoreIdentityDbContext storeIdentity) : IDataSeeding
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
                if (!_dbContext.Set<DeliveryMethod>().Any())
                {
                    using var DeliveryData = File.OpenRead(@"..\Infrastructure\Talabat.Persistence\Data\DataSeed\delivery.json");
                    // Convert Data "String" to C# Object 
                    var Deliverys = await JsonSerializer.DeserializeAsync<List<DeliveryMethod>>(DeliveryData);
                    // Save Data to Database
                    if (Deliverys is not null && Deliverys.Any())
                    {
                        await _dbContext.Set<DeliveryMethod>().AddRangeAsync(Deliverys);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Do 
            }
        }

        public async Task IdentityDataSeedAsync()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }
                if (!_userManager.Users.Any())
                {
                    var User01 = new ApplicationUser()
                    {
                        Email = "Mohamed912@.com",
                        DisplayName = "Mohamed Mahmoud",
                        UserName = "Mohamed912",
                        PhoneNumber = "01098132487"
                    };
                    var User02 = new ApplicationUser()
                    {
                        Email = "Mohamed912002@.com",
                        DisplayName = "Mohamed MahmoudAli",
                        UserName = "Mohamed9122002",
                        PhoneNumber = "01098132487"
                    };

                    await _userManager.CreateAsync(User01, "P@ssw0rd");
                    await _userManager.CreateAsync(User02, "P@ssw00rd");
                    await _userManager.AddToRoleAsync(User01, "Admin");
                    await _userManager.AddToRoleAsync(User02, "SuperAdmin");
                }
                await storeIdentity.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
