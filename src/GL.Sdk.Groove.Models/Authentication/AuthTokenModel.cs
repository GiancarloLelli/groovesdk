using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Authentication
{
    [JsonObject]
    public class AuthTokenModel
    {
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public string ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        public DateTime TokenExpiryDate { get; set; }
    }
}
