using MongoDB.Bson;
using MongoDB.Driver;
using RecipeRepositories;
using RepoModel = RecipeRepositories.Models;
using RecipeRepositoriesMngoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRepositoriesMngoDb
{
    public class MngoRecipeRepository: IRecipeRepository
    {
        private readonly IMongoCollection<Recipe> recipes;

        public MngoRecipeRepository(IMongoDatabase mongoDatabase)
        {
            recipes = mongoDatabase.GetCollection<Recipe>("recipe");
        }

        public Task<bool> DeleteRecipe(string id)
        {
                var result = recipes.DeleteOne(id);
                return Task.FromResult(result.IsAcknowledged);
        }

        public RepoModel.Recipe CreateRecipe(RepoModel.Recipe recipe)
        {
            Task.FromResult(new Task(() => recipes.InsertOne(recipe.ToRecipe())));
            return recipe;
        }

        public IEnumerable<RepoModel.Recipe> GetAllRecipes()
        {
            return Task.FromResult(recipes.Find(Builders<Recipe>.Filter.Empty).ToList())//
                   .Result.Select(x => x.ToRecipe())//
                   .ToArray();
        }

        public RepoModel.Recipe GetRecipe(string id)
        {
            var item =  recipes.FindAsync(item => item.Id.Equals(id)).Result.First();
            return item.ToRecipe();
        }

        public RepoModel.Recipe UpdateRecipe(RepoModel.Recipe recipe)
        {
            var item = new Task(() => recipes.ReplaceOneAsync(GetIdFilter(recipe.Id), recipe.ToRecipe()));
            return recipe;
        }

        private FilterDefinition<Recipe> GetIdFilter(string id)
        {
            return Builders<Recipe>.Filter.Eq(item => item.Id, id);
        }
    }
}
