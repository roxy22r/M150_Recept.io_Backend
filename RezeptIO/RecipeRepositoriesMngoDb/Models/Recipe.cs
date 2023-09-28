using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;

namespace RecipeRepositoriesMngoDb.Models
{
    public class Recipe
    {
        [BsonId]
        public string Id { get; set; } = string.Empty;

        [BsonElement("ttl")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("ingr")]
        public List<Ingredient> Ingredients { get; set; } = new();

    }
}
