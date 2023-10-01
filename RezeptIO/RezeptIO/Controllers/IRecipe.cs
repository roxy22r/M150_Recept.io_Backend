using Microsoft.AspNetCore.Mvc;
using RezeptIO.API.Controllers;
using RezeptIO.API.Controllers.Models;

namespace RezeptIO.API.Controllers
{
    public interface IRecipe
    {
        public Task<IActionResult> CreateRecipe(Recipe recipe);
        public Task<IActionResult> UpdateRecipe(Recipe recipe);
        public Task<IActionResult> DeleteRecipe(string id);
        public Task<IActionResult> GetRecipe(string id);
        public Task<IActionResult> GetAllRecipes();
    }
}