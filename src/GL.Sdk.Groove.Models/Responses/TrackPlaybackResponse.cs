using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class TrackPlaybackResponse : ResponseBase
    {
        public string ContentType { get; set; }

        public DateTime ExpiresOn { get; set; }

        public Uri Url { get; set; }
    }
}
