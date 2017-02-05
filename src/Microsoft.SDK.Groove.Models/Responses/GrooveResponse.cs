using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class GrooveResponse
    {
        public TrackLookupResponse Tracks { get; set; }

        public AlbumLookupResponse Albums { get; set; }

        public ArtistLookupResponse Artists { get; set; }

        public PlaylistLookupResponse Playlists { get; set; }

        public ErrorModel Error { get; set; }

        public string Culture { get; set; }
    }
}
