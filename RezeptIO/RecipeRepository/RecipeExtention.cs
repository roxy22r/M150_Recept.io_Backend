using Rep=  RecipeRepositories.Models;
using Svc = RecipeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRepositories
{
    public static class RecipeExtention
    {
        public static Rep.Recipe toRecipe (Svc.Recipe recipe) {
            return new Rep.Recipe() { 
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = recipe.Inde,
            };
        }
    }
}
