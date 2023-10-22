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
            var convertetRecipe =recipe.ToRecipe();
            convertetRecipe.Id = Guid.NewGuid().ToString();
            var newRecipe = RecipeRepository.CreateRecipe(convertetRecipe);
           return (RecipeServiceResponse.Success,newRecipe.ToRecipe());
        }

        public Task<RecipeServiceResponse> DeleteRecipe(string id)
        {
            try
            {
                var item = RecipeRepository.DeleteRecipe(id);
                return new Task<RecipeServiceResponse>(() => RecipeServiceResponse.Success);
            }
            catch(Exception ex) {
                return new Task<RecipeServiceResponse>(()=>RecipeServiceResponse.Failure);
            }
        }

        public (RecipeServiceResponse, List<Svc.Recipe>) GetAllRecipes()
        {
           var item= RecipeExtention.Recipe(RecipeRepository.GetAllRecipes());
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
