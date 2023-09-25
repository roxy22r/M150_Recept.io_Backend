using RecipeRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRepositories
{
    public interface IRecipeRepository
    {
        public Task<Recipe> CreateRecipe(Recipe recipe);
        public Task<Recipe> UpdateRecipe(Recipe recipe);
        public Task<bool> DeleteRecipe(string id);
        public Task<Recipe> GetRecipe(string id);
        public Task<IEnumerable<Recipe>> GetAllRecipes();
    }
}
