using Rep = RecipeRepositories.Models;
using Svc = RecipeService.Models;
namespace RezeptIO.API
{
    public static class IngredientsExtention
    {
        public static List<Svc.Ingredient> ToIngredient(List<Rep.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ToIngredient(ingredientItem); }).ToList();

        }
        public static Svc.Ingredient ToIngredient(this Rep.Ingredient ingredient)
        {
            return new Svc.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }

        public static List<Rep.Ingredient> ToIngredient(List<Svc.Ingredient> ingredients)
        {
            return ingredients.Select(ingredientItem => { return ToIngredient(ingredientItem); }).ToList();


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
