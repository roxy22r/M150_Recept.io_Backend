using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecipeService;
using ServiceModel = RecipeService.Models;
using RezeptIO.API.Controllers.Models;
using RecipeService.Models;
using Recipe = RezeptIO.API.Controllers.Models.Recipe;
using Svc=RecipeService.Models;
using Api = RezeptIO.API.Controllers.Models;

namespace RezeptIO.API.Controllers
{
    [Route("recipe/")]
    public class RecipeController : Controller, IRecipe
    {
        public RecipeController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        public IRecipeService RecipeService { get; set; }

        public IActionResult CreateRecipe(Api.Recipe recipe)
        {
           throw new NotImplementedException();
        }

        public IActionResult DeleteRecipe(string id)
        {
            try
            {
                 RecipeService.DeleteRecipe(id);
                return Ok();
                
            }
            catch {
                return StatusCode(500);
            }
        }

        public IActionResult GetAllRecipes()
        {
            try
            {
                return Ok(RecipeService.GetAllRecipes());
            }
            catch {
                return StatusCode(500);
            }
        }

        public IActionResult GetRecipe(string id)
        {
            Svc.Recipe recipe= RecipeService.GetRecipe(id).Item2;
            return Ok(toRecipe(recipe));

        }

        public IActionResult UpdateRecipe(Api.Recipe res)
        {
            Svc.Recipe mapped=toRecipe(res);
           // Svc.Recipe updatedRecipe=RecipeService.UpdateRecipe(mapped);
           //
           //return Ok(updatedRecipe);
           return Ok();
        }

        public  Svc.Recipe toRecipe(Api.Recipe recipe)
        {
            return new Svc.Recipe()
            {
                Title = recipe.Title,
                Ingredients = ToIngredient(recipe.Ingredients),
            };
        }
        public  List<Svc.Ingredient> ToIngredient(List<Api.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ToIngredient(ingredientItem); }).ToList();

        }
        public  Svc.Ingredient ToIngredient(this Api.Ingredient ingredient)
        {
            return new Svc.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }

        //
        public Api.Recipe toRecipe(Svc.Recipe recipe)
        {
            return new Api.Recipe()
            {
                Title = recipe.Title,
                Ingredients = ToIngredient(recipe.Ingredients),
            };
        }
        public  List<Api.Ingredient> ToIngredient(List<Svc.Ingredient> ingredient)
        {
            return ingredient.Select(ingredientItem => { return ToIngredient(ingredientItem); }).ToList();

        }
        public  Api.Ingredient ToIngredient(this Svc.Ingredient ingredient)
        {
            return new Api.Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
            };
        }
    }
}
