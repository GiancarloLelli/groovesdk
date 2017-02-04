using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class TrackPlaybackResponse : ErrorModel
    {
        public string ContentType { get; set; }

        public string ExpiresOn { get; set; }

        public Uri Url { get; set; }
    }
}
