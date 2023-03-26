using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.OrderDetail
{
    public class EditModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public EditModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project.Models.OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderDetail == null)
            {
                return NotFound();
            }

            var orderdetail =  await _context.OrderDetail.FirstOrDefaultAsync(m => m.ProductID == id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            OrderDetail = orderdetail;
           ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID");
           ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(OrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(OrderDetail.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("~/OrderDetail/");
        }

        private bool OrderDetailExists(int id)
        {
          return _context.OrderDetail.Any(e => e.ProductID == id);
        }
    }
}
