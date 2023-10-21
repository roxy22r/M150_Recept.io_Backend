using RecipeRepositories;
using RecipeRepositories.Models;
using RecipeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svc =RecipeService.Models;
using Rep = RecipeRepositories.Models;
namespace RecipeService
{
    public class RecipeService : IRecipeService
    {
        public RecipeService(IRecipeRepository recipeRepository)
        {
            RecipeRepository = recipeRepository;
        }

        public IRecipeRepository RecipeRepository { get; set; }

        public  (RecipeServiceResponse, Svc.Recipe) CreateRecipe(Svc.Recipe recipe)
        {

          var item= RecipeRepository.CreateRecipe(recipe.ToRecipe());
            item.Id= Guid.NewGuid().ToString();
           return (RecipeServiceResponse.Success,item.ToRecipe());
        }

        public Task<RecipeServiceResponse> DeleteRecipe(string id)
        {
            var item= RecipeRepository.DeleteRecipe(id);
            return new Task<RecipeServiceResponse>(() => RecipeServiceResponse.Success);
        }

        public (RecipeServiceResponse, List<Svc.Recipe>) GetAllRecipes()
        {
           var item= RecipeExtention.ToRecipe(RecipeRepository.GetAllRecipes());
            return (RecipeServiceResponse.Success,item);
        }

        public (RecipeServiceResponse, Svc.Recipe) GetRecipe(string id)
        {
            var item = RecipeRepository.GetRecipe(id);
            return (RecipeServiceResponse.Success,item.ToRecipe());
        }

        public (RecipeServiceResponse, Svc.Recipe) UpdateRecipe(Svc.Recipe recipe)
        {
           var item = RecipeRepository.UpdateRecipe( recipe.ToRecipe());
            return (RecipeServiceResponse.Success, item.ToRecipe());
            
        }

       
    }
}
