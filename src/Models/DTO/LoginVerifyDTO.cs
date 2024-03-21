using Newtonsoft.Json;

namespace Models
{
    public class LoginVerifyDTO
    {
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("password")]
        public string PassWord { get; set; }
    }
}
