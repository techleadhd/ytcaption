using Newtonsoft.Json;

namespace csharp.Models
{
    public class Xml
    {
        [JsonProperty("@version")]
        public string Version { get; set; }
        [JsonProperty("@encoding")]
        public string Encoding { get; set; }
    }
}
