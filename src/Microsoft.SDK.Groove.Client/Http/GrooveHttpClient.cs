using Microsoft.SDK.Groove.Extensions;
using Microsoft.SDK.Groove.Models.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SDK.Groove.Client.Http
{
    public class GrooveHttpClient : IDisposable
    {
        private readonly HttpClient m_client;
        private readonly Dictionary<string, string> m_requestData;

        public AuthTokenModel AccessToken { get; private set; }

        public GrooveHttpClient(string clientId, string clientSecret)
        {
            m_client = new HttpClient();
            m_client.BaseAddress = new Uri("https://music.xboxlive.com/1/content/music/");

            m_requestData = new Dictionary<string, string>()
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "scope", "http://music.xboxlive.com" },
                { "grant_type", "client_credentials" }
            };

            Task.Run(async () => await AuthenticateAsync()).Wait();
        }

        public async Task<T> QueryServiceAsync<T>(string request)
        {
            await ValidateTokenAsync();
            request = string.Concat(request, $"&accessToken=Bearer+{AccessToken.AccessToken}");
            var response = await m_client.GetAsync(request);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private async Task AuthenticateAsync()
        {
            var response = await m_client.PostAsync(new Uri("https://datamarket.accesscontrol.windows.net/v2/OAuth2-13"), new FormUrlEncodedContent(m_requestData));
            if (response.IsSuccessStatusCode)
            {
                String responseString = await response.Content.ReadAsStringAsync();
                AuthTokenModel tokenResponse = JsonConvert.DeserializeObject<AuthTokenModel>(responseString);
                AccessToken = tokenResponse;
                AccessToken.TokenExpiryDate = Convert.ToDouble(tokenResponse.ExpiresIn).UnixTimeStampToDateTime();
            }
        }

        private async Task ValidateTokenAsync()
        {
            if (DateTime.UtcNow > AccessToken.TokenExpiryDate)
                await AuthenticateAsync();
        }

        public void Dispose() => m_client?.Dispose();
    }
}
