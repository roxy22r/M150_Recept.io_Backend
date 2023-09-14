﻿using RecipeRepositories;
using RecipeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeService
{
    public class RecipeService : IRecipeService
    {
        public RecipeService(IRecipeRepository recipeRepository)
        {
            RecipeRepository = recipeRepository;
        }

        public IRecipeRepository RecipeRepository { get; set; }

        public Task<(RecipeServiceResponse, Recipe)> CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeServiceResponse> DeleteRecipe(string id)
        {
            throw new NotImplementedException();
        }

        public (RecipeServiceResponse, IEnumerable<Recipe>) GetAllParkingSpaces()
        {
            throw new NotImplementedException();
        }

        public (RecipeServiceResponse, Recipe) GetParkingSpace(string id)
        {
            throw new NotImplementedException();
        }

        public Task<(RecipeServiceResponse, Recipe)> UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
