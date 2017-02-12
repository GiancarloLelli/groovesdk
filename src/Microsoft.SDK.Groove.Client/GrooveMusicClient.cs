using Microsoft.SDK.Groove.Client.Formatters;
using Microsoft.SDK.Groove.Client.Http;
using Microsoft.SDK.Groove.Models;
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

        public async Task<GrooveResponse> SearchAsync(string keyword)
        {
            var url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults)
        {
            if (maxResults > 25 || maxResults <= 0) throw new ArgumentException("maxResults must be greater than 0 and less than 25", "maxResults");
            var url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}";
            var response = await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults, IEnumerable<FilterType> filters)
        {
            if (maxResults > 25) throw new ArgumentException("maxResults must be greater than 0 and less than 25", "maxResults");
            var aggregatedFilters = ParametersFormatter.Format(filters.Select(x => x.ToString()));
            var url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}&filters={aggregatedFilters}";
            var response = await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults, IEnumerable<FilterType> filters, IEnumerable<SearchSource> source)
        {
            if (maxResults > 25) throw new ArgumentException("maxResults must be greater than 0 and less than 25", "maxResults");
            var aggregatedFilters = ParametersFormatter.Format(filters.Select(x => x.ToString()));
            var formattedSource = ParametersFormatter.Format(source.Select(x => x.ToString()));
            var url = $"search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}&filters={aggregatedFilters}&source={formattedSource}";
            var response = await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> ContinueSearchAsync(string continuationToken)
        {
            var url = $"search?continuationToken={continuationToken}";
            var response = await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> LookupAsync(IEnumerable<string> ids)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var url = $"{formattedParams}/lookup?locale={m_culture.Name}&country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryCatalogServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> LookupAsync(IEnumerable<string> ids, IEnumerable<SearchSource> source)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var formattedSource = ParametersFormatter.Format(source.Select(x => x.ToString()));
            var url = $"{formattedParams}/lookup?locale={m_culture.Name}&country={m_culture.Name}&language={m_culture.Name}&source={formattedSource}";
            var response = await m_client.Value.QueryCatalogServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> LookupAsync(IEnumerable<string> ids, IEnumerable<SearchSource> source, IEnumerable<ExtrasParameters> extraFields)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var formattedSource = ParametersFormatter.Format(source.Select(x => x.ToString()));
            var formattedExtras = ParametersFormatter.Format(extraFields.Select(x => x.ToString()));
            var url = $"{formattedParams}/lookup?locale={m_culture.Name}&country={m_culture.Name}&language={m_culture.Name}&source={formattedSource}&extras={formattedExtras}";
            var response = await m_client.Value.QueryCatalogServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GrooveResponse> ContinueLookupAsync(string continuationToken, IEnumerable<string> ids)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var url = $"{formattedParams}/lookup?continuationToken={continuationToken}";
            var response = await m_client.Value.QueryCatalogServiceAsync<GrooveResponse>(url);
            return response;
        }

        public async Task<GenresResponse> GetGenresAsync()
        {
            string url = $"catalog/genres?country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryMusicServiceAsync<GenresResponse>(url);
            return response;
        }

        public async Task<FeaturedResponse> GetSpotlightAsync()
        {
            string url = $"spotlight?country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryMusicServiceAsync<FeaturedResponse>(url);
            return response;
        }

        public async Task<UserProfileResponse> GetUserProfileAsync()
        {
            var response = await m_client.Value.QueryMusicServiceAsync<UserProfileResponse>("/1/user/music/profile");
            return response;
        }

        public async Task<FeaturedResponse> GetNewReleasesAsync()
        {
            var url = $"newreleases?country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryMusicServiceAsync<FeaturedResponse>(url);
            return response;
        }

        public async Task<FeaturedResponse> GetNewReleasesAsync(GenreModel genre)
        {
            var url = $"newreleases?genre={genre.Name}&country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryMusicServiceAsync<FeaturedResponse>(url);
            return response;
        }

        public async Task<MoodsResponse> GetAvailableMoodsAsync()
        {
            var url = $"catalog/moods?&country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryMusicServiceAsync<MoodsResponse>(url);
            return response;
        }

        public async Task<ActivitiesResponse> GetAvailableActivitiesAsync()
        {
            var url = $"catalog/activities?&country={m_culture.Name}&language={m_culture.Name}";
            var response = await m_client.Value.QueryMusicServiceAsync<ActivitiesResponse>(url);
            return response;
        }

        public async Task<TrackPlaybackResponse> GetPreviewStreamAsync(string songId, PlaybackType streamType)
        {
            var url = $"{songId}/{streamType}?country={m_culture.Name}&language={m_culture.Name}&clientInstanceId={m_client.Value.ClienteInstanceId}";
            var response = await m_client.Value.QueryCatalogServiceAsync<TrackPlaybackResponse>(url);
            return response;
        }
    }
}
