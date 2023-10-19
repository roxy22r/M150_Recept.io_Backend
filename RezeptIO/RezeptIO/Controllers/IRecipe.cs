using RecipeService.Models;

namespace RezeptIO.API.Controllers
{
    public interface IRecipe
    {
        public Task<(RecipeServiceResponse, IRecipe)> CreateRecipe(IRecipe recipe);
        public Task<(RecipeServiceResponse, IRecipe)> UpdateRecipe(IRecipe recipe);
        public Task<RecipeServiceResponse> DeleteRecipe(string id);
        public (RecipeServiceResponse, IRecipe) GetRecipe(string id);
        public (RecipeServiceResponse, IEnumerable<IRecipe>) GetAllRecipes();
    }
}
