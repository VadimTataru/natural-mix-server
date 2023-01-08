using Newtonsoft.Json;

namespace NaturalMixApi.Models
{
    public class ComponentItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string? Description { get; set; }
        [JsonProperty("Origin")]
        public string? Origin { get; set; }
        [JsonProperty("Naturalness")]
        public float? Safety { get; set; }

        public ComponentItem(string name, string? description, string? origin, float? safety)
        {
            Name = name;
            Description = description;
            Origin = origin;
            Safety = safety;
        }
    }
}
