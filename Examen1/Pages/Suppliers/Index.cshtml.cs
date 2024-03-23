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

namespace Examen1.Pages.Suppliers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Examen1.Data.Examen1Context _context;

        public IndexModel(Examen1.Data.Examen1Context context)
        {
            _context = context;
        }

        public IList<Supplier> Supplier { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SupplierName { get; set; }
        public async Task OnGetAsync()
        {
            var suppliers = from m in _context.Supplier
                             select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                suppliers = suppliers.Where(s => s.CompanyName.Contains(SearchString));
            }

            Supplier = await suppliers.ToListAsync();

            //Supplier = await _context.Supplier.ToListAsync();
        }
    }
}
