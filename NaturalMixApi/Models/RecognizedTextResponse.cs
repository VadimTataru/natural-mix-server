using Newtonsoft.Json;

namespace NaturalMixApi.Models
{
    public class RecognizedTextResponse
    {
        [JsonProperty("RecognizedText")]
        public string Text { get; set; }
        [JsonProperty("Data")]
        public List<ComponentItem> Data { get; set; }

        public RecognizedTextResponse(string text, List<ComponentItem> data)
        {
            Text = text;
            Data = data;
        }
    }
}
