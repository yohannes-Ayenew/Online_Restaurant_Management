using Microsoft.Identity.Client;

namespace Online_Restaurant_Management.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = null;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CatagoryId { get; set; }
        public Catagory? Catagory { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<ProductIngerdient>? ProductIngerdients { get; set; }

    }
}