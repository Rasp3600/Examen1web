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

namespace Examen1.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Examen1.Data.Examen1Context _context;

        public IndexModel(Examen1.Data.Examen1Context context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CategoryName { get; set; }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var categories = from m in _context.Category
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                categories = categories.Where(s => s.CategoryName.Contains(SearchString));
            }

            Category = await categories.ToListAsync();

            //Category = await _context.Category.ToListAsync();
        }
    }
}
