using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Examen1.Data;
using Examen1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Examen1.Pages.Products
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Examen1.Data.Examen1Context _context;

        public CreateModel(Examen1.Data.Examen1Context context)
        {
            _context = context;
        }


        public SelectList Suppliers { get; set; }
        public SelectList Categories { get; set; }


        public IActionResult OnGet()
        {

            Suppliers = new SelectList(_context.Supplier, "SuppliersID", "CompanyName");
            Categories = new SelectList(_context.Category, "CategoryID", "CategoryName");
            
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
