﻿using Microsoft.AspNetCore.Mvc;
using RezeptIO.API.Controllers.Models;

namespace RezeptIO.API.Controllers
{
    public interface IRecipe
    {
        public IActionResult CreateRecipe(Recipe recipe);
        public IActionResult UpdateRecipe(Recipe recipe);
        public IActionResult DeleteRecipe(string id);
        public IActionResult GetRecipe(string id);
        public IActionResult GetAllRecipes();
    }
}
