using GL.Sdk.Groove.Models.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models
{
    public class BaseModel : ImageLinkProvider
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Uri ImageUrl { get; set; }

        public Uri Link { get; set; }

        public string Source { get; set; }

        public string CompatibleSources { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> Subgenres { get; set; }

        public IEnumerable<ArtistDescriptionModel> Artists { get; set; }
    }
}
