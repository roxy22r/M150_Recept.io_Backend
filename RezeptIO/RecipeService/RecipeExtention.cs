using Svc = RecipeService.Models;
using Rep = RecipeRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeService.Models;
using RecipeRepositories.Models;

namespace RecipeService
{
    public static class RecipeExtention
    {
       

        public static Svc.Recipe ToRecipe(this Rep.Recipe recipe)
        {
            return new Svc.Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = IngredientsExtention.ToIngredient(recipe.Ingredients)
            };
        }

        public static Rep.Recipe ToRecipe(this Svc.Recipe recipe)
        {
            return new Rep.Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = IngredientsExtention.ToIngredient(recipe.Ingredients)
            };
        }

     
        public static List<Svc.Recipe> ToRecipe(this List<Rep.Recipe> recipes)
        {
            return  recipes.Select(item => { return item.ToRecipe(); }).ToList();
        }
    }
}
