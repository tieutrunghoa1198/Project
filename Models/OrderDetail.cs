using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Keyless]
    public class OrderDetail
    {
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
