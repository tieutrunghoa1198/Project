using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Hubs;
using Project.Models;

namespace Project.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;
        private readonly IHubContext<SignalrServer> _signalRHub;
        public DeleteModel(Project.Data.ProjectContext context, IHubContext<SignalrServer> signalRHub)
        {
            _signalRHub = signalRHub;
            _context = context;
        }

        [BindProperty]
      public Project.Models.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);

            if (product != null)
            {
                Product = product;
                _context.Product.Remove(Product);
                await _context.SaveChangesAsync();
                await _signalRHub.Clients.All.SendAsync("LoadProducts");
            }

            return Redirect("~/Product/");
        }
    }
}
