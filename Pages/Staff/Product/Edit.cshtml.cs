using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Hubs;
using Project.Models;

namespace Project.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;
        private readonly IHubContext<SignalrServer> _signalRHub;
        public EditModel(Project.Data.ProjectContext context, IHubContext<SignalrServer> signalRHub)
        {
            _signalRHub = signalRHub;
            _context = context;
        }

        [BindProperty]
        public Project.Models.Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product =  await _context.Product.FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
           ViewData["CategoryID"] = new SelectList(_context.Set<Project.Models.Category>(), "CategoryID", "CategoryID");
           ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("LoadProducts");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("~/Product/");
        }

        private bool ProductExists(int id)
        {
          return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
