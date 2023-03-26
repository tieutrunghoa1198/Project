using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public IndexModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<Project.Models.Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(o => o.Customers).ToListAsync();
            }
        }
    }
}
