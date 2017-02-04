using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class GrooveResponse : ErrorModel
    {
        public TrackLookupResponse Tracks { get; set; }

        public AlbumLookupResponse Albums { get; set; }

        public ArtistLookupResponse Artists { get; set; }
    }
}
