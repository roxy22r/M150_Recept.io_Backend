using MongoDB.Driver;
using RecipeService;
using RecipeService.Models;
using System.Collections.Generic;
using System.Linq;
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
            //arrange
            var ingredients=CreateTestIngredientData();
            Recipe recipe=  new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            //act
            var result = Testee.CreateRecipe(recipe);
            //assert
            Assert.True(string.IsNullOrEmpty(result.Item2.Id));
        }

        [Fact]
        public void getRecipe_recipeExists_getRecipe()
        {
            //arrange
            var ingredients = CreateTestIngredientData();
            Recipe recipe = new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            var createdRecipe = Testee.CreateRecipe(recipe).Item2;
            //act
            var item=Testee.GetRecipe(createdRecipe.Id).Item2;
            //assert
            Assert.Equal(item, createdRecipe);
        }
        [Fact]
        public void getRecipe_recipeDoesNotExists_getRecipe()
        {
            //arrange
            var ingredients = CreateTestIngredientData();
            Recipe recipe = new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            var createdRecipe = Testee.CreateRecipe(recipe);
            //act
            var result = Testee.GetAllRecipes().Item2.First();
            //assert
            Assert.Equal(result, createdRecipe.Item2);
        }

        [Fact]
        public void getRecipeAll_recipeExists_getAllRecipe()
        {
            //arrange
            var ingredients = CreateTestIngredientData();
            Recipe recipe = new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            var createdRecipe = Testee.CreateRecipe(recipe);
            //act
            var item = Testee.GetRecipe(createdRecipe.Item2.Id);
            //assert
            Assert.Equal(item, createdRecipe);
        }
        [Fact]
        public void updateRecipe_recipeExistsAndTitleIsChanged_titleIsUpdate()
        {
            //arrange
            const string updatedTitle = "Updated";
            var ingredients = CreateTestIngredientData();
            Recipe recipe = new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            //act
            var newRecipe = Testee.CreateRecipe(recipe).Item2;
            newRecipe.Title = updatedTitle;
            //assert
            Recipe result = Testee.UpdateRecipe(newRecipe).Item2;
            Assert.Equal(result.Title, updatedTitle);

        }

        [Fact]
        public void deleteRecipe_recipeExistsDeleteExistingRecipe_isDeletetedSuccess()
        {
            //arrange
            var ingredients = CreateTestIngredientData();
            Recipe recipe = new Recipe()
            {
                Title = "Pizza",
                Ingredients = ingredients,
            };
            //act
            var newRecipe = Testee.CreateRecipe(recipe).Item2;
            RecipeServiceResponse result = Testee.DeleteRecipe(newRecipe.Id).Result;
            Assert.Equal(result,RecipeServiceResponse.Success);
        }
        [Fact]
        public void deleteRecipe_recipeDoesNotExistsDeleteExistingRecipe_isDeletetedFailure()
        {
            //act
            RecipeServiceResponse result = Testee.DeleteRecipe("1").Result;
            //assert
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
