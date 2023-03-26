using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Project.Data;
using Project.Hubs;
using Project.Models;

namespace Project.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;
        private readonly IHubContext<SignalrServer> _signalRHub;
        public CreateModel(Project.Data.ProjectContext context, IHubContext<SignalrServer> signalRHub)
        {
            _signalRHub = signalRHub;
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName");
        ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Project.Models.Product Product { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadProducts");
            return Redirect("~/Product/");
        }
    }
}
