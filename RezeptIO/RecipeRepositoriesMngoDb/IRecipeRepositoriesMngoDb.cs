using MongoDB.Driver;
using RecipeRepositoriesMngoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRepositoriesMngoDb
{
    public interface IRecipeRepositoriesMngoDb
    {

        public Task<Recipe> CreateRecipe(Recipe recipe);
        public Task<bool> DeleteRecipe(string id);

        public Task<IEnumerable<Recipe>> GetAllRecipes();
        public Task<Recipe> GetRecipe(string id);

        public Task<Recipe> UpdateRecipe(Recipe recipe);
    }
}
