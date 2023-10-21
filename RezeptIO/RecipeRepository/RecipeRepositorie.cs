using RecipeRepositories;
using RecipeRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RecipeRepositories
{
    public class RecipeRepositorie :IRecipeRepository
    {
        public RecipeRepositorie()
        {
        }

        public Recipe CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetAllRecipes()
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public Recipe UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
