using MongoDB.Bson.Serialization.Attributes;

namespace RecipeRepositoriesMngoDb.Models
{
    public class Ingredient
    {
        [BsonElement("nam")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("quan")]
        public string Quantity { get; set; } = string.Empty;
    }
}
