using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Online_Restaurant_Management.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }

        [ValidateNever]
        public ICollection<ProductIngredient> ProductIngerdients { get; set; }


    }
}