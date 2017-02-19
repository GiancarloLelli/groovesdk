using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class ActivitiesResponse : ResponseBase
    {
        public IEnumerable<CatalogItem> CatalogActivities { get; set; }
    }
}
