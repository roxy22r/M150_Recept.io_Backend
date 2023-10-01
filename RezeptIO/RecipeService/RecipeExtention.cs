﻿using Svc= RecipeService.Models;
using Rep= RecipeRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeService.Models;
using RezeptIO.API;
using RecipeRepositories.Models;

namespace RecipeService
{
    public static class RecipeExtention
    {
        public static Svc.Recipe toRecipe(this Rep.Recipe recipe)
        {
            return new Svc.Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Ingredients = IngredientsExtention.ToIngredient(recipe.Ingredients)
            };
        }

        public static IEnumerable<Svc.Recipe> toRecipe(Task<IEnumerable<Rep.Recipe>> recipes)
        {
            return recipes.Result.Select(recipe => toRecipe(recipe)).ToList();
        }
    }
}
