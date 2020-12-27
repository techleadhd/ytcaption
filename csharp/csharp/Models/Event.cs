using Newtonsoft.Json;
using System.Collections.Generic;

namespace csharp.Models
{
    public class Root
    {
        [JsonProperty("?xml")]
        public Xml Xml { get; set; }
        [JsonProperty("transcript")]
        public Transcript Transcript { get; set; }
    }
}
