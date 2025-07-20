using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/158";

        [ValidateNever]
        public Category? Catagory { get; set; }

        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; }

        [ValidateNever]
        public ICollection<ProductIngredient>? ProductIngerdients { get; set; }

    }
}