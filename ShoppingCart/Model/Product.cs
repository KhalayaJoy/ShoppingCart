using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}
