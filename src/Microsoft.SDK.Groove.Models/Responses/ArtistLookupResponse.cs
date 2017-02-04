using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class ArtistLookupResponse : ContinuationModel
    {
        public IEnumerable<ArtistResponse> Items { get; set; }
    }
}
