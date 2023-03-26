using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ProjectContext _context;
        public HomeController(ProjectContext context)
        {
            _context= context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var res = _context.Product.ToList();
            return Ok(res);
        }
    }
}
