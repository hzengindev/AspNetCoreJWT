using Newtonsoft.Json;

namespace AspNetCore.JWT.Models
{
    public class ErrorReturn
    {
        public bool Success { get => false; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ErrorCode { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
    }
}
