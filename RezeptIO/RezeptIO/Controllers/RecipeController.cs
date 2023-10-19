using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecipeService;
using ServiceModel = RecipeService.Models;
using RezeptIO.API.Controllers.Models;
using RecipeService.Models;

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

        public Task<(RecipeServiceResponse, IRecipe)> CreateRecipe(IRecipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeServiceResponse> DeleteRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public (RecipeServiceResponse, IEnumerable<IRecipe>) GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        public (RecipeServiceResponse, IRecipe) GetRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public Task<(RecipeServiceResponse, IRecipe)> UpdateRecipe(IRecipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
