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
        public Recipe UpdateRecipe(Recipe recipe);
        public bool DeleteRecipe(string id);
        public Recipe GetRecipe(string id);
        public List<Recipe> GetAllRecipes();
    }
}
