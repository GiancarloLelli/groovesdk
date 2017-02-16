using GL.Sdk.Groove.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models
{
    public class FeaturedItemModel
    {
        public string Type { get; set; }

        public AlbumsResponse Album { get; set; }
    }
}
