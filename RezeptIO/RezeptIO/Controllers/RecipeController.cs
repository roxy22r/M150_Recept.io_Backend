using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecipeService;
using ServiceModel = RecipeService.Models;
using RezeptIO.API.Controllers.Models;
using RecipeService.Models;
using Recipe = RezeptIO.API.Controllers.Models.Recipe;

namespace RezeptIO.API.Controllers
{
    [Route("recipe/")]
    public class RecipeController : Controller
    {
        public RecipeController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }


        [HttpPost("update")]
        public ActionResult UpdateRecipe(Recipe recipe)
        {
            return StatusCode(200);
        }
        public IRecipeService RecipeService { get; set; }

    }
}
