using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen1.Data;
using Examen1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Examen1.Pages.Suppliers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Examen1.Data.Examen1Context _context;

        public DetailsModel(Examen1.Data.Examen1Context context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.SuppliersID == id);
            if (supplier == null)
            {
                return NotFound();
            }
            else
            {
                Supplier = supplier;
            }
            return Page();
        }
    }
}
