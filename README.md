# Groove Music Service .NET Standard SDK
This repo contains a .NET Standard wrapper for the Groove Music Service REST API.
This project is a porting of the same library I made available on NuGet some time ago (I've unpublished it).
I decided to revive this side project since the service changed its name and a few other changes were made on the backed.
I really like the service and I think that many app can benefit from using it.

## Getting started
First thing you have to do is to register yor app and get a `clientID` and `clientSecret` code.
You can do that by following this step by step [how to](https://docs.microsoft.com/en-us/groove/getting-started).
The SDK is able to handle **authentication and automatic token refresh** so basically you can forget about that.
As the name of this project says, this library is a **.NET Standard 1.4** library. 
The reason for that is because I wanted to make UWP apps able to use it.
If you are **not** building an UWP app and you still wanna use this SDK take a look at [this](https://github.com/dotnet/standard/blob/master/docs/versions.md) page to see if you can.

## Backlog
Here's a list of stuff that still needs to be done from a _release_ point of view
* ~~Publish a NuGet Package~~ - [NuGet Package](https://www.nuget.org/packages/GL.Sdk.Groove/)
* Set up the list of Up-For-Grabs

## Features available
Here's a list of API endpoints that as of today are accessible with SDK:
* [Search](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-search-content)
* [Item Lookup](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-content-lookup)
* [Genres](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-get-genres)
* [Spotlight](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-get-spotlight)
* [User profile](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-access-user-profile)
* [New releases](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-get-new-releases)
* [Moods](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-get-moods)
* [Activities](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-get-activities)
* [Preview Stream](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-get-preview)
* [Full Stream](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-get-stream)

## Features not yet available
Here's a list of API endpoint that do are not accessible with this SDK:
* [Browse the catalog](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-browse-catalog)
* [Sub item browse](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-browse-sub-items)
* [Browse user collection](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-browse-user-collection-playlist)
* [Playlist update](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-update-playlist)
* [Playlist delete](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-delete-playlist)
* [Playlist create](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-create-playlist)
* [Delete tracks from collection](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-delete-track-collection)
* [Add tracks to collection](https://docs.microsoft.com/en-us/groove/groove-service-rest-reference/uri-add-track-collection)

## Sample usage
Inside the .cs file "_\groovesdk\test\GL.Sdk.Groove.Test\Program.cs_" you can find some examples of usage.
For those who are too lazy to browse to that file, here's a snippet of that file.

```csharp
class Program
{
    static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

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
```

## License & Contact
This project is distributed under MIT License.
If you have any question or you'd like to get involved in the project write to [gcarlo.lelli@live.com](mailto:gcarlo.lelli@live.com)