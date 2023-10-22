using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecipeService;
using Svc = RecipeService.Models;
using Api = RezeptIO.API.Controllers.Models;
using RezeptIO.API.Controllers.Models;
using RecipeService.Models;

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
        public IActionResult CreateRecipe([FromBody] Api.Recipe recipe)
        {
            try { 
            var (response, newRecipe)= RecipeService.CreateRecipe(recipe.ToRecipe());
                return response switch {
                    RecipeServiceResponse.Success => Ok(newRecipe),
                    RecipeServiceResponse.Failure => NotFound(),
                    _ => StatusCode(500)
                };
            
            
            }catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult DeleteRecipe([FromRoute(Name = "id")] string id)
        {
            try
            {
                RecipeServiceResponse isDeleted = RecipeService.DeleteRecipe(id).Result;
                return isDeleted switch
                {
                    RecipeServiceResponse.Success => Ok(isDeleted),
                    RecipeServiceResponse.Failure => NotFound(""),
                    _ => StatusCode(500)

                };
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            try
            {

                var (response, recipes) = RecipeService.GetAllRecipes();
                return response switch
                {
                    RecipeServiceResponse.Success => Ok(recipes),
                    RecipeServiceResponse.Failure => StatusCode(404),
                    _=>StatusCode(500)
                };
            }
            catch {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetRecipe([FromRoute(Name = "id")] string id)
        {
            try
            {
            
                Svc.Recipe recipe = RecipeService.GetRecipe(id).Item2;
                
                return base.Ok(Api.RecipeExtention.ToRecipe(recipe));
           
            }
            catch {
                return StatusCode(500);
            }

        }

        [HttpPost]
        [Route("/{recipe}")]
        public IActionResult UpdateRecipe([FromBody] Api.Recipe recipe)
        {
            try
            {
                var (response, newRecipe) = RecipeService.UpdateRecipe(recipe.ToRecipe());
                return response switch
                {
                    RecipeServiceResponse.Success => Ok(newRecipe),
                    RecipeServiceResponse.Failure => NotFound(),
                    _ => StatusCode(500)
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
