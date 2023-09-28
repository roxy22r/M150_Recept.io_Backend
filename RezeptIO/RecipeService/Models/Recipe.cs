﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService.Models
{
    public class Recipe
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<Ingredient> Ingredients { get; set; } = new();

    }
}
