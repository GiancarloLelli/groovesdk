using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class FeaturedResponse
    {
        public FeaturedItemCollectionModel Results { get; set; }

        public ErrorModel Error { get; set; }
    }
}
