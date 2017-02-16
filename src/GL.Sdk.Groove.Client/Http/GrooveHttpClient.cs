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
        private readonly HttpClient m_musicHttp;
        private readonly HttpClient m_catalogHttp;
        private readonly Dictionary<string, string> m_requestData;

        public AuthTokenModel AccessToken { get; private set; }

        public Guid ClienteInstanceId { get; private set; }

        public GrooveHttpClient(string clientId, string clientSecret)
        {
            ClienteInstanceId = Guid.NewGuid();

            m_musicHttp = new HttpClient() { BaseAddress = new Uri("https://music.xboxlive.com/1/content/music/") };
            m_catalogHttp = new HttpClient() { BaseAddress = new Uri("https://music.xboxlive.com/1/content/") };

            m_requestData = new Dictionary<string, string>()
            {
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "scope", "app.music.xboxlive.com" },
                { "grant_type", "client_credentials" }
            };

            Task.Run(async () => await AuthenticateAsync()).Wait();
        }

        public async Task<T> QueryMusicServiceAsync<T>(string request)
        {
            await ValidateTokenAsync();
            var response = await m_musicHttp.GetAsync(request);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> QueryCatalogServiceAsync<T>(string request)
        {
            await ValidateTokenAsync();
            var response = await m_catalogHttp.GetAsync(request);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        private async Task AuthenticateAsync()
        {
            var response = await m_musicHttp.PostAsync(new Uri("https://login.live.com/accesstoken.srf"), new FormUrlEncodedContent(m_requestData));
            if (response.IsSuccessStatusCode)
            {
                String responseString = await response.Content.ReadAsStringAsync();
                AuthTokenModel tokenResponse = JsonConvert.DeserializeObject<AuthTokenModel>(responseString);
                AccessToken = tokenResponse;
                AccessToken.TokenExpiryDate = Convert.ToDouble(tokenResponse.ExpiresIn).UnixTimeStampToDateTime();
                m_musicHttp.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {AccessToken.AccessToken}");
                m_catalogHttp.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {AccessToken.AccessToken}");
            }
        }

        private async Task ValidateTokenAsync()
        {
            if (DateTime.UtcNow > AccessToken.TokenExpiryDate)
                await AuthenticateAsync();
        }

        public void Dispose()
        {
            m_musicHttp?.Dispose();
            m_catalogHttp?.Dispose();
        }
    }
}
