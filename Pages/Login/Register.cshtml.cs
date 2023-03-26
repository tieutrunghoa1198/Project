using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Project.Pages.Login
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        private readonly Project.Data.ProjectContext _context;
        [BindProperty]
        public Project.Models.Account Account { get; set; }
        public RegisterModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Account.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
