using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecipeService;
using Svc = RecipeService.Models;
using Api = RezeptIO.API.Controllers.Models;
using RezeptIO.API.Controllers.Models;

namespace RezeptIO.API.Controllers
{
    [Route("recipe/")]
    public class RecipeController : Controller
    {
        public RecipeController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        public IRecipeService RecipeService { get; set; }

        [HttpPost]
        public IActionResult CreateRecipe([FromBody] Recipe recipe)
        {
            var (_, newRecipe) = RecipeService.CreateRecipe(recipe.toRecipe());
            return Ok(newRecipe);
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult DeleteRecipe([FromRoute(Name = "id")] string id)
        {
            try
            {
                 RecipeService.DeleteRecipe(id);
                return Ok();
                
            }
            catch {
                return StatusCode(500);
            }
        }
        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            try
            {
                var (_, Recipes) = RecipeService.GetAllRecipes();
                return Ok(Recipes);
            }
            catch {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetRecipe([FromRoute(Name = "id")] string id)
        {
            Svc.Recipe recipe= RecipeService.GetRecipe(id).Item2;
            return Ok(recipe.ToRecipe());

        }

        [HttpPost]
        [Route("/{id}")]
        public IActionResult UpdateRecipe([FromBody] Recipe res)
        {
            var (_, newRecipe) = RecipeService.UpdateRecipe(res.toRecipe());
           return Ok(newRecipe);
        }
    }
}
