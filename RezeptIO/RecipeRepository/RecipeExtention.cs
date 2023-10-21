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
        public static Rep.Recipe ToRecipe (this Mng.Recipe recipe) {
            return new Rep.Recipe() { 
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = recipe.Ingredients.ToIngredient(),
            };
        }

        public static Mng.Recipe ToRecipe(this Rep.Recipe recipe)
        {
            return new Mng.Recipe()
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = recipe.Ingredients.ToIngredient(),
            };
        }

        public static List<Rep.Recipe> ToRecipe(this List<Mng.Recipe> recipes)
        {
            return recipes.Select(item => item.ToRecipe()).ToList();
            
        }
    }
}
