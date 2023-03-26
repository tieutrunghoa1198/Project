using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Newtonsoft.Json;
using Project.Models;
namespace Project.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public IndexModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<Project.Models.Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Account != null)
            {
                Account = await _context.Account.ToListAsync();
                var acc = HttpContext.Session.GetString("account") ?? "";
                var asc = JsonConvert.DeserializeObject<Models.Account>(acc);
                Console.WriteLine(asc.UserName + " cool");
            }
        }
    }
}
