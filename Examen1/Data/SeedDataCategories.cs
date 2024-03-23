using Microsoft.EntityFrameworkCore;
using Examen1.Models;

namespace Examen1.Data;

public static class SeedDataCategories
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Examen1Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Examen1Context>>()))
        {
            if (context == null || context.Category == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Category.Any())
            {
                return;   // DB has been seeded
            }

            context.Category.AddRange(
                new Category
                {
                   
                    CategoryName = "CATEGORIA 1",
                    Description = "Categoria generada 1"
                },
                new Category
                {
                    
                    CategoryName = "CATEGORIA 2",
                    Description = "Categoria generada 2"
                }
             );
            context.SaveChanges();
        }
    }
}