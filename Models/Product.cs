using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public double QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public Supplier Suppliers { get; set; }
        public Category Categories { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
