using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class GrooveResponse : ResponseBase
    {
        public TrackLookupResponse Tracks { get; set; }

        public AlbumLookupResponse Albums { get; set; }

        public ArtistLookupResponse Artists { get; set; }

        public PlaylistLookupResponse Playlists { get; set; }
    }
}
