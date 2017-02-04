using Microsoft.SDK.Groove.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models
{
    public class FeaturedItemModel
    {
        public string Type { get; set; }

        public AlbumsResponse Album { get; set; }
    }
}
