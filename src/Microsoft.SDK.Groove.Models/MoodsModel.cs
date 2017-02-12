using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models
{
    public class CatalogItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Uri ImageUrl { get; set; }
    }
}
