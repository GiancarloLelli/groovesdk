using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class AlbumLookupResponse : ContinuationModel
    {
        public IEnumerable<AlbumsResponse> Items { get; set; }
    }
}
