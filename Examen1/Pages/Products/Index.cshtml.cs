using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen1.Data;
using Examen1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Examen1.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Examen1.Data.Examen1Context _context;

        public IndexModel(Examen1.Data.Examen1Context context)
        {
            _context = context;
        }


        // public IList<Product> Product { get; set; } = default!;
        //public IList<Supplier> Supplier { get; set; } = default!;
        public IList<Product> Product { get; set; } = new List<Product>();
        public IList<string> SupplierName { get; set; } = new List<string>();

        public IList<string> CategoryName { get; set; } = new List<string>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }


        public async Task OnGetAsync()
        {
            // var pName = from m in _context.Product
            //  select m;

            var products = from p in _context.Product
                           join s in _context.Supplier on p.SupplierID equals s.SuppliersID into ps
                           from supplier in ps.DefaultIfEmpty()
                           join c in _context.Category on p.CategoryID equals c.CategoryID into cs
                           from category in cs.DefaultIfEmpty()
                           select new
                           {
                               Product = p,
                               SupplierName = supplier.CompanyName,
                               CategoryName = category.CategoryName// Nombre del proveedor
                           };

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(x => x.Product.ProductName.Contains(SearchString));

            }


            //Product = await pName.ToListAsync();
            Product = await products.Select(x => x.Product).ToListAsync();
            SupplierName = await products.Select(x => x.SupplierName).ToListAsync();
            CategoryName = await products.Select(x => x.CategoryName).ToListAsync();
        }


        

    }
}
