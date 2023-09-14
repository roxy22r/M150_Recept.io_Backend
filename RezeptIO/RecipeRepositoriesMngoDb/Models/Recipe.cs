using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRepositoriesMngoDb.Models
{
    public class Recipe
    {
        [BsonId]
        public string Id { get; set; } = string.Empty;

        [BsonElement("ttl")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("dscr")]
        public string Description { get; set; } = string.Empty;
    }
}
