﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public DeleteModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }
            var account = await _context.Account.FindAsync(id);

            if (account != null)
            {
                Account = account;
                _context.Account.Remove(Account);
                await _context.SaveChangesAsync();
            }

            return Redirect("~/Account/");
        }
    }
}
