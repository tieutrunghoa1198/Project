using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Pages.Login
{
    public class LoadProductModel : PageModel
    {
        private readonly ProjectContext _context;
        public LoadProductModel(ProjectContext context)
        {
            _context= context;
        }
        public void OnGet()
        {

        }
    }
}
