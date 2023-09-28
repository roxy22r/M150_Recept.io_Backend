using Api = RezeptIO.API.Controllers.Models;
using Svc = RecipeService.Models;
namespace RezeptIO.API
{
    public static class IngredientsExtention
    {
        public static List<Api.Ingredient> ToIngredient(List<Svc.Ingredient> ingredient) {
          return ingredient.Select(ingredientItem => { return ToIngredient(ingredientItem); }).ToList();
           
        }
        public static Api.Ingredient ToIngredient(this Svc.Ingredient ingredient){
            return new Api.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }
    }
}
