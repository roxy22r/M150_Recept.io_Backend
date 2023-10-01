using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecipeService;
using ServiceModel = RecipeService.Models;
using RezeptIO.API.Controllers.Models;
using RecipeService.Models;
using MongoDB.Bson;

namespace RezeptIO.API.Controllers
{
    [Route("recipe/")]
    public class RecipeController : Controller,IRecipe
    {
        public RecipeController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        public IRecipeService RecipeService { get; set; }

        public Task<IActionResult> CreateRecipe(Models.Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> GetAllRecipes()
        {
            try { 
            var result = RecipeService.GetAllRecipes();
                switch (result.Item1)
                        {
                    case RecipeServiceResponse.Success:
                        return StatusCode(StatusCodes.Status200OK, result);
                    case RecipeServiceResponse.Failure:
                        return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public Task<IActionResult> GetRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateRecipe(Models.Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
