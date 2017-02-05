using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class PlaylistResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public string Source { get; set; }

        public string CompatibleSources { get; set; }

        public string Provider { get; set; }

        public bool IsReadOnly { get; set; }

        public bool IsPublished { get; set; }

        public int TrackCount { get; set; }

        public bool UserIsOwner { get; set; }

        public string CollectionStateToken { get; set; }

        public TrackLookupResponse Tracks { get; set; }
    }
}
