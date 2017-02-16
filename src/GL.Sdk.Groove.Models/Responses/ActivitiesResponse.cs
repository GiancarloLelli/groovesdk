using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class ActivitiesResponse
    {
        public string Culture { get; set; }

        public IEnumerable<CatalogItem> CatalogActivities { get; set; }

        public ErrorModel Error { get; set; }
    }
}
