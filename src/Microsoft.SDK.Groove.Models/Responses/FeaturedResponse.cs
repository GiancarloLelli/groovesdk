using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class FeaturedResponse : ErrorModel
    {
        public FeaturedItemCollectionModel Results { get; set; }
    }
}
