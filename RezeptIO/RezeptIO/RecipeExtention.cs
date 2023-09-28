using Api= RezeptIO.API.Controllers.Models;
using Svc= RecipeService.Models;
namespace RezeptIO.API
{
    public static class RecipeExtention
    {
        public static Api.Recipe toRecipe(Svc.Recipe recipe) {
            return new Api.Recipe() { 
                Title = recipe.Title,
                Ingredients = IngredientsExtention.ToIngredient(recipe.Ingredients),
            };
        }
       
    }
}
