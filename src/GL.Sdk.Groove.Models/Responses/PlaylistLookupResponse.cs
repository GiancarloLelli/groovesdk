﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class PlaylistLookupResponse : ContinuationModel
    {
        public IEnumerable<PlaylistResponse> Items { get; set; }
    }
}
