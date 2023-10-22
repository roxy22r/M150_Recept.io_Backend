using MongoDB.Driver;
using RecipeService;
using RecipeService.Models;
using System.Collections.Generic;
using Xunit;


namespace RecipeTest
{
    public class RecipeServiceTest
    {
        public RecipeServiceTest(IRecipeService recipeService)
        {
            Testee = recipeService;
        }

        public IRecipeService Testee { get; set; }

        [Fact]
        public void createRecipe_titleAndIngredensAreSet_idIsNotEmptyOrNull()
        {
            var ingredients=CreateTestIngredientData();
            Recipe recipe=  new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            var result = Testee.CreateRecipe(recipe);
           Assert.True(string.IsNullOrEmpty(result.Item2.Id));
        }
        [Fact]
        public void updateRecipe_recipeExistsAndTitleIsChanged_titleIsUpdate()
        {
            const string updatedTitle = "Updated";
            var ingredients = CreateTestIngredientData();
            Recipe recipe = new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            var newRecipe = Testee.CreateRecipe(recipe).Item2;
            newRecipe.Title = updatedTitle;
            Recipe result = Testee.UpdateRecipe(newRecipe).Item2;
            Assert.Equal(result.Title, updatedTitle);

        }

        [Fact]
        public void deleteRecipe_recipeExistsDeleteExistingRecipe_isDeletetedSuccess()
        {
            const string updatedTitle = "Updated";
            var ingredients = CreateTestIngredientData();
            Recipe recipe = new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            var newRecipe = Testee.CreateRecipe(recipe).Item2;
            RecipeServiceResponse result = Testee.DeleteRecipe(newRecipe.Id).Result;
            Assert.Equal(result,RecipeServiceResponse.Success);
        }
        [Fact]
        public void deleteRecipe_recipeDoesNotExistsDeleteExistingRecipe_isDeletetedFailure()
        {
        
            RecipeServiceResponse result = Testee.DeleteRecipe("1").Result;
            Assert.Equal(result, RecipeServiceResponse.Failure);
        }

        private List<Ingredient> CreateTestIngredientData()
        {
            return new List<Ingredient>(){
                  new Ingredient()
                {
                    Name = "Mehl",
                    Quantity = "2"
                },
                new Ingredient() {
                    Name = "Wasser",
                    Quantity= "3"
                },
                new Ingredient()
                {
                    Name = "Tomatesauce",
                    Quantity= "2"
                }
        };

        }
    }
}
