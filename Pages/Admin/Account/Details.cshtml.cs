using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public DetailsModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

      public Project.Models.Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }
            else 
            {
                Account = account;
            }
            return Page();
        }
    }
}
