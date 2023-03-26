using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;

namespace Project.Pages.OrderDetail
{
    public class CreateModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public CreateModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID");
        ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID");
            return Page();
        }

        [BindProperty]
        public Project.Models.OrderDetail OrderDetail { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          _context.OrderDetail.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return Redirect("~/OrderDetail/");
        }
    }
}
