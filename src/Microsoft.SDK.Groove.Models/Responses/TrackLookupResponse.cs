using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class TrackLookupResponse : ContinuationModel
    {
        public IEnumerable<TrackResponse> Items { get; set; }
    }
}
