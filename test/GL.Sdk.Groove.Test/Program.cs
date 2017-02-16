using GL.Sdk.Groove.Client;
using GL.Sdk.Groove.Models;
using GL.Sdk.Groove.Models.Parameters;
using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args) => Task.Run(async () => await MainAsync(args)).Wait();

    static async Task MainAsync(string[] args)
    {
        var bastille_pompei = "music.8D6KGX7MCGQT";
        var m_client = new GrooveMusicClient(clientId: "", clientSecret: "");

        var search = await m_client.SearchAsync(keyword: "Bastille");
        var search_max = await m_client.SearchAsync(keyword: "Bastille", maxResults: 10);
        var search_filters = await m_client.SearchAsync(keyword: "Bastille", maxResults: 15, filters: new FilterType[] { FilterType.Tracks });
        var search_source = await m_client.SearchAsync(keyword: "Bastille", maxResults: 25, filters: new FilterType[] { FilterType.Tracks }, source: new SearchSource[] { SearchSource.Catalog });
        var continueSearch = await m_client.ContinueSearchAsync(search.Tracks.ContinuationToken);

        var lookup_ids = new string[] { bastille_pompei };
        var lookup = await m_client.LookupAsync(lookup_ids);
        var lookup_source = await m_client.LookupAsync(lookup_ids, new SearchSource[] { SearchSource.Catalog });
        var lookup_extra = await m_client.LookupAsync(lookup_ids, new SearchSource[] { SearchSource.Catalog }, new ExtrasParameters[] { ExtrasParameters.Albums });
        var continueLookup = await m_client.ContinueLookupAsync(lookup.Tracks.ContinuationToken, lookup_ids);

        var genres = await m_client.GetGenresAsync();
        var spotlight = await m_client.GetSpotlightAsync();
        var profile = await m_client.GetUserProfileAsync();

        var new_releases_all = await m_client.GetNewReleasesAsync();
        var new_releases = await m_client.GetNewReleasesAsync(genre: new GenreModel("Rock"));

        var preview_stream = await m_client.GetPreviewStreamAsync(songId: bastille_pompei, streamType: PlaybackType.Preview);
        var full_stream = await m_client.GetPreviewStreamAsync(songId: bastille_pompei, streamType: PlaybackType.Stream);

        var moods = await m_client.GetAvailableMoodsAsync();
        var activities = await m_client.GetAvailableActivitiesAsync();
    }
}