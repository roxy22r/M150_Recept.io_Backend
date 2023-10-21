using RecipeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svc=RecipeService.Models;
namespace RecipeService
{
    public interface IRecipeService
    {
        public (RecipeServiceResponse, Svc.Recipe) CreateRecipe(Svc.Recipe recipe);
        public (RecipeServiceResponse, Svc.Recipe) UpdateRecipe(Svc.Recipe recipe);
        public Task<RecipeServiceResponse> DeleteRecipe(string id);
        public (RecipeServiceResponse, Svc.Recipe) GetRecipe(string id);
        public (RecipeServiceResponse, List<Svc.Recipe>) GetAllRecipes();
    }
}
