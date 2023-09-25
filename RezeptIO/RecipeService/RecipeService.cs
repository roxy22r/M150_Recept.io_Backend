using RecipeRepositories;
using RecipeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService
{
    public class RecipeService : IRecipeService
    {
        public RecipeService(IRecipeRepository recipeRepository)
        {
            RecipeRepository = recipeRepository;
        }

        public IRecipeRepository RecipeRepository { get; set; }

        public Task<(RecipeServiceResponse, Recipe)> CreateRecipe(Recipe recipe)
        {

        }

        public RecipeServiceResponse DeleteRecipe(string id)
        {

        }

        public async (RecipeServiceResponse, IEnumerable<Recipe>) GetAllRecipes()
        {

        }

        public async (RecipeServiceResponse, Recipe) GetRecipe(string id)
        {
            try
            {
                return (RecipeServiceResponse.Success, await RecipeRepository.GetRecipe(id));
            }
            catch {
                return (RecipeServiceResponse.Failure,null);
            }
            
        }

        public async Task<(RecipeServiceResponse, Recipe)> UpdateRecipeAsync(Recipe recipe)
        {
            try
            {
               Recipe updatedRecipe= await RecipeRepository.UpdateRecipe(recipe);
                return (RecipeServiceResponse.Success,updatedRecipe );
            }
            catch {
                return RecipeServiceResponse.Failure;
            }
        }
    }
}
