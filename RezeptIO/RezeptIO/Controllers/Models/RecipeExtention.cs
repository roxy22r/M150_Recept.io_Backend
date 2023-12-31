﻿using Api = RezeptIO.API.Controllers.Models;
using Svc = RecipeService.Models;
namespace RezeptIO.API.Controllers.Models
{
    public static class RecipeExtention
    {
        public static Svc.Recipe ToRecipe(this Api.Recipe recipe)
        {
            return new Svc.Recipe()
            {
                Title = recipe.Title,
                Ingredients = ToIngredient(recipe.Ingredients),
            };
        }
        public static List<Svc.Ingredient> ToIngredient(this List<Api.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ingredientItem.ToIngredient(); }).ToList();

        }
        public static Svc.Ingredient ToIngredient(this Ingredient ingredient)
        {
            return new Svc.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }

        public static Recipe ToRecipe(this Svc.Recipe recipe)
        {
            return new Recipe()
            {
                Title = recipe.Title,
                Ingredients = ToIngredient(recipe.Ingredients),
            };
        }
        public static List<Api.Ingredient> ToIngredient(this List<Svc.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ingredientItem.ToIngredient(); }).ToList();

        }
        public static Api.Ingredient ToIngredient(this Svc.Ingredient ingredient)
        {
            return new Api.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }

    }
}
