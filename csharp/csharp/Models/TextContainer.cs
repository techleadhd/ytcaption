using Newtonsoft.Json;

namespace csharp.Models
{
    public class TextContainer
    {
        [JsonProperty("@start")]
        public string Start { get; set; }
        [JsonProperty("@dur")]
        public string Dur { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}
