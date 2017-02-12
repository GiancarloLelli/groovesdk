using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class FeaturedResponse
    {
        public FeaturedItemCollectionModel Results { get; set; }

        public ErrorModel Error { get; set; }
    }
}
