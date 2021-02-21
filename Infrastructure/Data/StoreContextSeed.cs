using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedDataAsync(StoreContext _context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!_context.ProductBrands.Any())
                {
                    var brandsData= File.ReadAllText("../InfraStructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        _context.ProductBrands.Add(item);
                        
                    }

                    await _context.SaveChangesAsync();

                }

                if(!_context.ProductTypes.Any())
                {
                    var typesData= File.ReadAllText("../InfraStructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        _context.ProductTypes.Add(item);
                        
                    }

                    await _context.SaveChangesAsync();

                }

                if(!_context.Products.Any())
                {
                    var productsData= File.ReadAllText("../InfraStructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        _context.Products.Add(item);
                        
                    }

                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(ex.Message);
                throw;
            }

        }
    }
}