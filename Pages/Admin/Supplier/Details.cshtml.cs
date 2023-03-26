using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Supplier
{
    public class DetailsModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public DetailsModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

      public Project.Models.Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Supplier == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.SupplierID == id);
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
