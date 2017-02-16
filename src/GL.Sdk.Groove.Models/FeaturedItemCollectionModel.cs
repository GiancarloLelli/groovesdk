using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models
{
    public class FeaturedItemCollectionModel
    {
        public IEnumerable<FeaturedItemModel> Items { get; set; }

        public int TotalItemCount { get; set; }
    }
}
