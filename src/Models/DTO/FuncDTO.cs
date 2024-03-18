using Newtonsoft.Json;

namespace Models
{
    public class FuncDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("funcpara")]
        public string FuncPara { get; set; }

        [JsonProperty("funcname")]
        public string FuncName { get; set; }

        [JsonProperty("funcurl")]
        public string FuncUrl { get; set; }

        [JsonProperty("funcicon")]
        public string FuncIcon { get; set; }

        [JsonProperty("partentid")]
        public string ParentId { get; set; }
    }
}