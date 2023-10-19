using MongoDB.Bson;
using MongoDB.Driver;
using RecipeRepositories;
using RecipeRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            recipes.InsertOne(recipe);
            return GetRecipe(recipe.Id);
        }

        public Task<bool> DeleteRecipe(string id)
        {
            bool isAcknowledged = recipes.DeleteOne(id).IsAcknowledged;
            return new Task<bool>(()=> isAcknowledged);
        }

        public  Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            var  all =  recipes.Find(Builders<Recipe>.Filter.Empty).ToListAsync();
            return new Task<IEnumerable<Recipe>>(() => all.Result);

        }

        public  Task<Recipe> GetRecipe(string id)
        {
            var item =recipes.FindAsync(item => item.Id.Equals(id)).Result.First();
            return new Task<Recipe>(() => item);


        }

        public Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            var item = recipes.ReplaceOneAsync(GetIdFilter(recipe.Id), recipe);
            return GetRecipe(recipe.Id);
        }
        public FilterDefinition<Recipe>GetIdFilter(string id){
          return Builders<Recipe> .Filter.Eq(item => item.Id,id);
    }
}
}
