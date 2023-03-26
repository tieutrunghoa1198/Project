using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
