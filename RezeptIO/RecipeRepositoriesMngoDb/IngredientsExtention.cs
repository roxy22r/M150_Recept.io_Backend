using Rep = RecipeRepositories.Models;
using Mng = RecipeRepositoriesMngoDb.Models;

namespace RecipeRepositories
{
    public static class IngredientsExtention
    {
        
        public static List<Mng.Ingredient> ToIngredient(this List<Rep.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ingredientItem.ToIngredient(); }).ToList();

        }

        public static List<Rep.Ingredient> ToIngredient(this List<Mng.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ingredientItem.ToIngredient(); }).ToList();

        }
        public static Rep.Ingredient ToIngredient(this Mng.Ingredient ingredient)
        {
            return new Rep.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }
        public static Mng.Ingredient ToIngredient(this Rep.Ingredient ingredient)
        {
            return new Mng.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }
    }
}
