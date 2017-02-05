using Microsoft.SDK.Groove.Models.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class ArtistResponse : ImageLinkProvider
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public string Source { get; set; }

        public string CompatibleSources { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Subgenres { get; set; }

        public string Biography { get; set; }

        public AlbumLookupResponse Albums { get; set; }

        public TrackLookupResponse TopTracks { get; set; }

        public Uri GetDeepLink()
        {
            return new Uri(string.Format("http://music.xbox.com/Artist/{0}", Id));
        }
    }
}
