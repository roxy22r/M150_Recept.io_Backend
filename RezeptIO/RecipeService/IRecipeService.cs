using RecipeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService
{
    public interface IRecipeService
    {
        public Task<(RecipeServiceResponse, Recipe)> CreateRecipe(Recipe recipe);
        public Task<(RecipeServiceResponse, Recipe)> UpdateRecipe(Recipe recipe);
        public Task<RecipeServiceResponse> DeleteRecipe(string id);
        public (RecipeServiceResponse, Recipe) GeteRecipe(string id);
        public (RecipeServiceResponse, IEnumerable<Recipe>) GetAllRecipe();
    }
}
