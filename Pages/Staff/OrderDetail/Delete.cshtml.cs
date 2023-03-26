using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.OrderDetail
{
    public class DeleteModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public DeleteModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Project.Models.OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.OrderDetail.FirstOrDefaultAsync(m => m.ProductID == id);

            if (orderdetail == null)
            {
                return NotFound();
            }
            else 
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }
            var orderdetail = await _context.OrderDetail.FindAsync(id);

            if (orderdetail != null)
            {
                OrderDetail = orderdetail;
                _context.OrderDetail.Remove(OrderDetail);
                await _context.SaveChangesAsync();
            }

            return Redirect("~/OrderDetail/");
        }
    }
}
