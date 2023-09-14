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
        private readonly IMongoCollection<Recipe> parkingSpaces;

        public MngoRecipeRepository(IMongoDatabase mongoDatabase)
        {
            parkingSpaces = mongoDatabase.GetCollection<Recipe>("recipe");
        }

        public Task<Recipe> CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetAllParkingSpaces()
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetParkingSpace(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
