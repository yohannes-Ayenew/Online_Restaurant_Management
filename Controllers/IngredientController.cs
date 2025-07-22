using Microsoft.AspNetCore.Mvc;
using Online_Restaurant_Management.Data;
using Online_Restaurant_Management.Models;

namespace Online_Restaurant_Management.Controllers
{
    public class IngredientController : Controller
    {

        private Repository<Ingredient> ingrediants;

        public IngredientController(ApplicationDbContext context)
        {
            ingrediants = new Repository<Ingredient>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await ingrediants.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id )
        {
            return View(await ingrediants.GetByIdAsync(id, new QueryOptions<Ingredient>(){ Includes = "ProductIngredients.Product" }));
        }

    }
}
