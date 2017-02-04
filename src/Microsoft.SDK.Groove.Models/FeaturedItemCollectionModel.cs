using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models
{
    public class FeaturedItemCollectionModel
    {
        public IEnumerable<FeaturedItemModel> Items { get; set; }

        public int TotalItemCount { get; set; }
    }
}
