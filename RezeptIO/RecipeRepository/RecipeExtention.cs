using Rep =  RecipeRepositories.Models;
using Mng = RecipeRepositoriesMngoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRepositories
{
    public static class RecipeExtention
    {
        public static Rep.Recipe toRecipe (Mng.Recipe recipe) {
            return new Rep.Recipe() { 
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = IngredientsExtention.ToIngredient(recipe.Ingredients),
            };
        }

        public static Mng.Recipe toRecipe(Rep.Recipe recipe)
        {
            return new Mng.Recipe()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = IngredientsExtention.ToIngredient(recipe.Ingredients),
            };
        }

        internal static List<Rep.Recipe> toRecipe(IEnumerable<Mng.Recipe> result)
        {
            throw new NotImplementedException();
        }
    }
}
