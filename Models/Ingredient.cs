namespace Online_Restaurant_Management.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductIngerdient> ProductIngerdients { get; set; }


    }
}