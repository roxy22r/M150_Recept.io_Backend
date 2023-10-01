using MongoDB.Bson;
using MongoDB.Driver;
using RecipeRepositories;
using RecipeRepositories.Models;
using RecipeRepositoriesMngoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe = RecipeRepositoriesMngoDb.Models.Recipe;

namespace RecipeRepositoriesMngoDb
{
    public class MngoRecipeRepository : IRecipeRepository
    {
        private readonly IMongoCollection<Recipe> recipes;

        public MngoRecipeRepository(IMongoDatabase mongoDatabase)
        {
            recipes = mongoDatabase.GetCollection<Recipe>("recipe");
        }

        public Task<Recipe> CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            var all = await (recipes.Find(_ => true).ToListAsync());
            return all;
        }

        public Task<Recipe> GetRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> UpdateRecipe(Recipe recipe)
        {
           return recipes.UpdateOneAsync(recipe);

        }
    }
}
