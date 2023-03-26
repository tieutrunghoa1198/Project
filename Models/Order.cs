using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public double Freight { get; set; }
        public string ShipAddress { get; set; }
        public Customer Customers { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
