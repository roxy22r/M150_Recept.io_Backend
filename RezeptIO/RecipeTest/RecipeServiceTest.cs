using MongoDB.Driver;
using RecipeService;
using RecipeService.Models;
using Xunit;


namespace RecipeTest
{
    public class RecipeServiceTest
    {
        private  readonly IRecipeService testee;

        public RecipeServiceTest(IRecipeService recipeS) {
        testee = recipeS;
        }

        [Fact]
        public void updateRecipe_correctFormmatedRecipe_200RepsoneCode()
        {
            Recipe recipe = new Recipe
            {
                Title = "Apple Pie",
                Description = "A Pie Made with Apples"
                
            };
          //  recipesCollection.InsertOne(recipe);
            Recipe updatedRecipe = new Recipe
            {
                Id = recipe.Id,
                Title = "Apple Pie 5",
                Description = "New Pie Descritpion"
            };
         testee.UpdateRecipe(updatedRecipe);

        //    Recipe result = recipesCollection.Find(r => r.Id.Equals(recipe.Id)).First();
        //    Assert.Equal(result.Description,recipe.Description ) ;
        }


    }
}
