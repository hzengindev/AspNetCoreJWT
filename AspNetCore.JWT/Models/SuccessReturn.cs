using Newtonsoft.Json;

namespace AspNetCore.JWT.Models
{
    public class SuccessReturn<T>
    {
        public bool Success { get => true; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }

    public class SuccessReturn
    {
        public bool Success { get => true; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }
    }
}
