using Microsoft.EntityFrameworkCore;
using Examen1.Models;

namespace Examen1.Data;

public static class SeedDataSuppliers
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Examen1Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Examen1Context>>()))
        {
            if (context == null || context.Supplier == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Supplier.Any())
            {
                return;   // DB has been seeded
            }

            context.Supplier.AddRange(
                new Supplier
                {
                   
                    CompanyName = "PROVEEDOR GENERADO 1",
                    ContactTitle = "11223344"
                },
                new Supplier
                {
                    
                    CompanyName = "PROVEEDOR GENERADO 2",
                    ContactTitle = "44332211"
                }
             ); ;
            context.SaveChanges();
        }
    }
}