using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace DrinkMiBeer.Core.JTOs
{
   public class PublicApiConfigJTO
    {
        [JsonProperty("Url")]
        public string Url { get; set; }
        [JsonProperty("ApiKey")]
        public string ApiKey { get; set; }

    }
}
