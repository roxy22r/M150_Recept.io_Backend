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
        public (RecipeServiceResponse, Recipe) CreateRecipe(Recipe recipe);
        public (RecipeServiceResponse, Recipe) UpdateRecipe(Recipe recipe);
        public Task<RecipeServiceResponse> DeleteRecipe(string id);
        public (RecipeServiceResponse, Recipe) GetRecipe(string id);
        public (RecipeServiceResponse, IEnumerable<Recipe>) GetAllRecipes();
    }
}
