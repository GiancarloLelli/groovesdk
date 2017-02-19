using GL.Sdk.Groove.Models.Extensions;
using GL.Sdk.Groove.Models.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GL.Sdk.Groove.Client.Http
{
    internal class GrooveHttpClient : IDisposable
    {
        private static HttpClient _grooveHttpClient;
        private readonly Dictionary<string, string> _requestData;

        public AuthTokenModel AccessToken { get; private set; }

        public Guid ClienteInstanceId { get; private set; }

        public GrooveHttpClient(string clientId, string clientSecret)
        {
            ClienteInstanceId = Guid.NewGuid();
            _grooveHttpClient = new HttpClient() { BaseAddress = new Uri("https://music.xboxlive.com/") };

            _requestData = new Dictionary<string, string>()
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "scope", "app.music.xboxlive.com" },
                { "grant_type", "client_credentials" }
            };

            AuthenticateAsync().GetAwaiter().GetResult();
        }

        public async Task<T> QueryMusicServiceAsync<T>(string request)
        {
            await ValidateTokenAsync();
            var response = await _grooveHttpClient.GetAsync(request);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private async Task AuthenticateAsync()
        {
            var response = await _grooveHttpClient.PostAsync(new Uri("https://login.live.com/accesstoken.srf"), new FormUrlEncodedContent(_requestData));
            if (response.IsSuccessStatusCode)
            {
                String responseString = await response.Content.ReadAsStringAsync();
                AuthTokenModel tokenResponse = JsonConvert.DeserializeObject<AuthTokenModel>(responseString);
                AccessToken = tokenResponse;
                AccessToken.TokenExpiryDate = Convert.ToDouble(tokenResponse.ExpiresIn).UnixTimeStampToDateTime();
                _grooveHttpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {AccessToken.AccessToken}");
            }
        }

        private async Task ValidateTokenAsync()
        {
            if (DateTime.UtcNow > AccessToken.TokenExpiryDate)
                await AuthenticateAsync();
        }

        public void Dispose() => _grooveHttpClient?.Dispose();
    }
}
