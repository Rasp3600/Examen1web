using Microsoft.EntityFrameworkCore;
using Examen1.Models;

namespace Examen1.Data;

public static class SeedDataProducts
{
    public static void Initialize(IServiceProvider serviceProvider)
    {

        SeedDataCategories.Initialize(serviceProvider);
        SeedDataSuppliers.Initialize(serviceProvider);

        using (var context = new Examen1Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Examen1Context>>()))
        {
            if (context == null || context.Product == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }

            context.Product.AddRange(
                new Product
                {
                    ProductName = "PRODUCTO GENERADO 1",
                    SupplierID = 7,
                    CategoryID = 7,
                    QuantityPerUnit = 1,
                    UnitPrice = 1,
                    UnitsInStock = 1,
                    UnitsOnOrder = 1,
                    ReorderLevel = 1,
                    Discontinued = 0
                },
                new Product
                {
                    ProductName = "PRODUCTO GENERADO 2",
                    SupplierID = 7,
                    CategoryID = 7,
                    QuantityPerUnit = 1,
                    UnitPrice = 1,
                    UnitsInStock = 1,
                    UnitsOnOrder = 1,
                    ReorderLevel = 1,
                    Discontinued = 0
                }
             );
            context.SaveChanges();
        }
    }
}