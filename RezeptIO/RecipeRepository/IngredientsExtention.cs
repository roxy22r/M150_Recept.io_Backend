using Rep = RecipeRepositories.Models;
using Svc = RecipeService.Models;
namespace RezeptIO.API
{
    public static class IngredientsExtention
    {
        public static List<Rep.Ingredient> ToIngredient(List<Svc.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ToIngredient(ingredientItem); }).ToList();

        }
        public static Rep.Ingredient ToIngredient(this Svc.Ingredient ingredient)
        {
            return new Rep.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }
    }
}
