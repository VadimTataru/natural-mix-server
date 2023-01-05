using Newtonsoft.Json;

namespace NaturalMixApi.Models
{
    public class ComponentItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string? Description { get; set; }
        [JsonProperty("Naturalness")]
        public float? Naturalness { get; set; }

        public ComponentItem(string name, string? description, float? naturalness)
        {
            Name = name;
            Description = description;
            Naturalness = naturalness;
        }
    }
}
