using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.Models
{
    public class Transcript
    {
        [JsonProperty("text")]
        public List<TextContainer> TextContainer { get; set; }
    }
}
