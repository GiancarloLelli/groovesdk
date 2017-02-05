using Microsoft.SDK.Groove.Client.Formatters;
using Microsoft.SDK.Groove.Client.Http;
using Microsoft.SDK.Groove.Models.Parameters;
using Microsoft.SDK.Groove.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SDK.Groove.Client
{
    public sealed class GrooveMusicClient
    {
        private readonly string m_clientId;
        private readonly string m_secret;
        private readonly RegionInfo m_culture;
        private readonly Lazy<GrooveHttpClient> m_client;

        public GrooveMusicClient(string clientId, string clientSecret)
        {
            m_clientId = clientId;
            m_secret = clientSecret;
            m_culture = new RegionInfo("us");
            m_client = new Lazy<GrooveHttpClient>(() => new GrooveHttpClient(m_clientId, m_secret));
        }

        public GrooveMusicClient(string clientId, string clientSecret, RegionInfo locale)
        {
            m_culture = locale;
            m_clientId = clientId;
            m_secret = clientSecret;
            m_client = new Lazy<GrooveHttpClient>(() => new GrooveHttpClient(m_clientId, m_secret));
        }

        #region Search
        public async Task<GrooveResponse> SearchAsync(string keyword)
        {
            string url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults)
        {
            string url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}";
            var response = await m_client.Value.QueryServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults, FilterType[] filters)
        {
            string aggregatedFilters = ParametersFormatter.Format(filters.Select(x => x.ToString()).ToArray());
            string url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}&filters={aggregatedFilters}";
            var response = await m_client.Value.QueryServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults, FilterType[] filters, SearchSource source)
        {
            string aggregatedFilters = ParametersFormatter.Format(filters.Select(x => x.ToString()).ToArray());
            string url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}&filters={aggregatedFilters}&source={source}";
            var response = await m_client.Value.QueryServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> ContinueSearchAsync(string continuationToken)
        {
            var url = $"search?continuationToken={continuationToken}";
            var response = await m_client.Value.QueryServiceAsync<GrooveResponse>(url);
            return response;
        }
        #endregion
    }
}
