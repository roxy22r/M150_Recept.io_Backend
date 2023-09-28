using Newtonsoft.Json;

namespace RezeptIO.API.Controllers.Models
{
    public class Ingredient
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "quantity")]
        public string Quantity { get; set; } = string.Empty;
    }

}