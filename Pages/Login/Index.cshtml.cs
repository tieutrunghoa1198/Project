using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
namespace Project.Pages.Login
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        private readonly Project.Data.ProjectContext _context;

        public IndexModel(Project.Data.ProjectContext context)
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
                  Console.WriteLine(Supplier.Address + " asdasd");
                  return Page();
              }*/

           try
            {
                var acc = _context.Account.SingleOrDefault(e => e.UserName == username);

                if (acc.Password.ToLower().Equals(password))
                {
                    HttpContext.Session.SetString("account", JsonConvert.SerializeObject(acc));
                    return Redirect("/");
                }
                else return RedirectToPage("./../Error");
            } catch (Exception ex)
            {
                
                return RedirectToPage("./../Error");
            }
            


        }
    }
}
