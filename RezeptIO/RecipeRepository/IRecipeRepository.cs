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
        public Recipe CreateRecipe(Recipe recipe);
        public Task<bool> DeleteRecipe(string id);
        public IEnumerable<Recipe> GetAllRecipes();
        public Recipe GetRecipe(string id);
        public Recipe UpdateRecipe(Recipe recipe);
    }
    
}
