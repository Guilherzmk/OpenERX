using Newtonsoft.Json;

namespace OpenERX.Core.SignIns
{
    public class SignInParams
    {
        [JsonProperty("accessKey")]
        public string AccessKey { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
