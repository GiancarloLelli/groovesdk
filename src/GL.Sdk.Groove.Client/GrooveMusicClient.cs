using GL.Sdk.Groove.Client.Formatters;
using GL.Sdk.Groove.Client.Http;
using GL.Sdk.Groove.Models;
using GL.Sdk.Groove.Models.Parameters;
using GL.Sdk.Groove.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Sdk.Groove.Client
{
    /// <summary>
    /// This class contains all the logic that wraps the REST API of the Groove Music Service
    /// </summary>
    public sealed class GrooveMusicClient : IDisposable
    {
        private readonly string m_clientId;
        private readonly string m_secret;
        private readonly RegionInfo m_culture;
        private readonly Lazy<GrooveHttpClient> m_client;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="clientId">Client ID of your app obtained through the DevCenter</param>
        /// <param name="clientSecret">Client Secret of your app obtained through the DevCenter</param>
        public GrooveMusicClient(string clientId, string clientSecret)
        {
            m_clientId = clientId;
            m_secret = clientSecret;
            m_culture = new RegionInfo("us");
            m_client = new Lazy<GrooveHttpClient>(() => new GrooveHttpClient(m_clientId, m_secret));
        }

        /// <summary>
        /// This constructor let's you override the locale settings
        /// </summary>
        /// <param name="clientId">Client ID of your app obtained through the DevCenter</param>
        /// <param name="clientSecret">Client Secret of your app obtained through the DevCenter</param>
        /// <param name="locale">Localization of your app</param>
        public GrooveMusicClient(string clientId, string clientSecret, RegionInfo locale)
        {
            m_culture = locale;
            m_clientId = clientId;
            m_secret = clientSecret;
            m_client = new Lazy<GrooveHttpClient>(() => new GrooveHttpClient(m_clientId, m_secret));
        }


        /// <summary>
        /// Main method to search through the Music Catalog
        /// </summary>
        /// <param name="keyword">What to search</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> SearchAsync(string keyword)
        {
            var url = $"1/content/music/search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Main method to search through the Music Catalog
        /// </summary>
        /// <param name="keyword">What to search</param>
        /// <param name="maxResults">Maximum number of results</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults)
        {
            if (maxResults > 25 || maxResults <= 0) throw new ArgumentException("maxResults must be greater than 0 and less than 25", "maxResults");
            var url = $"1/content/music/search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Main method to search through the Music Catalog
        /// </summary>
        /// <param name="keyword">What to search</param>
        /// <param name="maxResults">Maximum number of results</param>
        /// <param name="filters">Specifies what to search in the catalog</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults, IEnumerable<FilterType> filters)
        {
            if (maxResults > 25) throw new ArgumentException("maxResults must be greater than 0 and less than 25", "maxResults");
            var aggregatedFilters = ParametersFormatter.Format(filters.Select(x => x.ToString()));
            var url = $"1/content/music/search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}&filters={aggregatedFilters}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Main method to search through the Music Catalog
        /// </summary>
        /// <param name="keyword">What to search</param>
        /// <param name="maxResults">Maximum number of results</param>
        /// <param name="filters">Specifies what to search in the catalog</param>
        /// <param name="source">Specifies where to search in the catalog</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> SearchAsync(string keyword, int maxResults, IEnumerable<FilterType> filters, IEnumerable<SearchSource> source)
        {
            if (maxResults > 25) throw new ArgumentException("maxResults must be greater than 0 and less than 25", "maxResults");
            var aggregatedFilters = ParametersFormatter.Format(filters.Select(x => x.ToString()));
            var formattedSource = ParametersFormatter.Format(source.Select(x => x.ToString()));
            var url = $"1/content/music/search?q={Uri.EscapeDataString(keyword)}&country={m_culture.Name}&language={m_culture.Name}&maxitems={maxResults}&filters={aggregatedFilters}&source={formattedSource}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Main method to continue a paginated search in the catalog
        /// </summary>
        /// <param name="continuationToken">The token to continue a previously started search</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> ContinueSearchAsync(string continuationToken)
        {
            var url = $"1/content/music/search?continuationToken={continuationToken}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Lookup a specific set of objects in the catalog
        /// </summary>
        /// <param name="ids">List of object ids</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> LookupAsync(IEnumerable<string> ids)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var url = $"1/content/{formattedParams}/lookup?locale={m_culture.Name}&country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Lookup a specific set of objects in the catalog
        /// </summary>
        /// <param name="ids">List of object ids</param>
        /// <param name="source">Where to search in the catalog</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> LookupAsync(IEnumerable<string> ids, IEnumerable<SearchSource> source)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var formattedSource = ParametersFormatter.Format(source.Select(x => x.ToString()));
            var url = $"1/content/{formattedParams}/lookup?locale={m_culture.Name}&country={m_culture.Name}&language={m_culture.Name}&source={formattedSource}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Lookup a specific set of objects in the catalog
        /// </summary>
        /// <param name="ids">List of object ids</param>
        /// <param name="source">Where to search in the catalog</param>
        /// <param name="extraFields">Extra object to include in the results</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> LookupAsync(IEnumerable<string> ids, IEnumerable<SearchSource> source, IEnumerable<ExtrasParameters> extraFields)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var formattedSource = ParametersFormatter.Format(source.Select(x => x.ToString()));
            var formattedExtras = ParametersFormatter.Format(extraFields.Select(x => x.ToString()));
            var url = $"1/content/{formattedParams}/lookup?locale={m_culture.Name}&country={m_culture.Name}&language={m_culture.Name}&source={formattedSource}&extras={formattedExtras}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Main method to continue a paginated search in the catalog
        /// </summary>
        /// <param name="ids">List of object ids</param>
        /// <param name="continuationToken">The token to continue a previously started lookup</param>
        /// <returns>The list of items found in the catalog</returns>
        public async Task<GrooveResponse> ContinueLookupAsync(string continuationToken, IEnumerable<string> ids)
        {
            var formattedParams = ParametersFormatter.Format(ids);
            var url = $"1/content/{formattedParams}/lookup?continuationToken={continuationToken}";
            return await m_client.Value.QueryMusicServiceAsync<GrooveResponse>(url);
        }

        /// <summary>
        /// Fetches the available music genres for the current locale
        /// </summary>
        /// <returns>The list of available genres</returns>
        public async Task<GenresResponse> GetGenresAsync()
        {
            string url = $"1/content/music/catalog/genres?country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<GenresResponse>(url);
        }

        /// <summary>
        /// Fetches what's currently under the Groove Spotlight
        /// </summary>
        /// <returns>The list of featured albums</returns>
        public async Task<FeaturedResponse> GetSpotlightAsync()
        {
            string url = $"1/content/music/spotlight?country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<FeaturedResponse>(url);
        }

        /// <summary>
        /// Fetches the user's profile
        /// </summary>
        /// <returns>The user profile</returns>
        public async Task<UserProfileResponse> GetUserProfileAsync() => await m_client.Value.QueryMusicServiceAsync<UserProfileResponse>("1/user/music/profile");

        /// <summary>
        /// Fetches the new releases for the current locale
        /// </summary>
        /// <returns>The list of new releases</returns>
        public async Task<FeaturedResponse> GetNewReleasesAsync()
        {
            var url = $"1/content/music/newreleases?country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<FeaturedResponse>(url);
        }

        /// <summary>
        /// Fetches the new releases for the current locale
        /// </summary>
        /// <param name="genre">Narrows down the new releases to a specific music genre</param>
        /// <returns>The list of new releases</returns>
        public async Task<FeaturedResponse> GetNewReleasesAsync(GenreModel genre)
        {
            var url = $"1/content/music/newreleases?genre={genre.Name}&country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<FeaturedResponse>(url);
        }

        /// <summary>
        /// Fetches the moods from the Groove Music Service
        /// </summary>
        /// <returns>The list of available moods</returns>
        public async Task<MoodsResponse> GetAvailableMoodsAsync()
        {
            var url = $"1/content/music/catalog/moods?&country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<MoodsResponse>(url);
        }

        /// <summary>
        /// Fetches the list of available activities from the Groove Music Service
        /// </summary>
        /// <returns></returns>
        public async Task<ActivitiesResponse> GetAvailableActivitiesAsync()
        {
            var url = $"1/content/music/catalog/activities?&country={m_culture.Name}&language={m_culture.Name}";
            return await m_client.Value.QueryMusicServiceAsync<ActivitiesResponse>(url);
        }

        /// <summary>
        /// Gets the preview / full stream of a track
        /// </summary>
        /// <param name="track">Track id</param>
        /// <param name="streamType">Stream type: Full or Preview</param>
        /// <returns></returns>
        public async Task<TrackPlaybackResponse> GetPreviewStreamAsync(string track, PlaybackType streamType)
        {
            var url = $"1/content/{track}/{streamType}?country={m_culture.Name}&language={m_culture.Name}&clientInstanceId={m_client.Value.ClienteInstanceId}";
            return await m_client.Value.QueryMusicServiceAsync<TrackPlaybackResponse>(url);
        }

        /// <summary>
        /// Disposes the object to free up some memory
        /// </summary>
        public void Dispose() => m_client?.Value?.Dispose();
    }
}
