using Newtonsoft.Json;

namespace RezeptIO.API.Controllers.Models
{
    public class Recipe
    {
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; } = string.Empty;

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; } = string.Empty;
    }
}
