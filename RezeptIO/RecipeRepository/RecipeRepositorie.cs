using RecipeRepositories;
using RecipeRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rep = RecipeRepositories.Models;
using Mng=RecipeRepositoriesMngoDb.Models;
using RecipeRepositoriesMngoDb;

namespace RecipeRepositories
{
    public class RecipeRepositorie :IRecipeRepository
    {
        public RecipeRepositorie(IRecipeRepositoriesMngoDb repositorieMngoDb)
        {
            RepositorieMngoDb = repositorieMngoDb;
        }

        public IRecipeRepositoriesMngoDb RepositorieMngoDb { get; set; }


        public Rep.Recipe CreateRecipe(Rep.Recipe recipe)
        {
          var item=  RepositorieMngoDb.CreateRecipe(RecipeExtention.toRecipe(recipe));
            return RecipeExtention.toRecipe(item.Result);

        }

        public bool DeleteRecipe(string id)
        {
            var item =RepositorieMngoDb.DeleteRecipe(id);
            return item.Result;
        }

        public List<Rep.Recipe> GetAllRecipes()
        {
            var item =RepositorieMngoDb.GetAllRecipes();
            return RecipeExtention.toRecipe(item.Result);

        }

        public Rep.Recipe GetRecipe(string id)
        {
            var item = RepositorieMngoDb.GetRecipe(id);
            return RecipeExtention.toRecipe(item.Result);

        }

        public  Rep.Recipe UpdateRecipe(Rep.Recipe recipe)
        {
          var item = RepositorieMngoDb.UpdateRecipe(RecipeExtention.toRecipe(recipe));
            return RecipeExtention.toRecipe(item.Result);
        }
    }
}
