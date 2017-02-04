using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models
{
    public class CollectionModel
    {
        public string Token { get; set; }

        public int PlaylistCount { get; set; }

        public int RemainingPlaylistCount { get; set; }

        public int TrackCount { get; set; }

        public int RemainingTrackCount { get; set; }
    }
}
