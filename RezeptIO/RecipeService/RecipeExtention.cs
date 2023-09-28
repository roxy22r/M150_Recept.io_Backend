using Svc= RecipeService.Models;
using Rep= RecipeRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeService.Models;

namespace RecipeService
{
    public static class RecipeExtention
    {
        public static Rep.Recipe Recipe(this Svc.Recipe recipe) {
            return new Rep.Recipe { 
              Id = recipe.Id,
              Title = recipe.Title,
              Ingredients = recipe.Ingredients
            } ;
        }
    }
}
