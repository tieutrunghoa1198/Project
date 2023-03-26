using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;

namespace Project.Pages.Customer
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
            return Page();
        }

        [BindProperty]
        public Project.Models.Customer Customer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return Redirect("~/Customer/");
        }
    }
}
