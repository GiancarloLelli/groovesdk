using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class GenresResponse
    {
        public IEnumerable<string> Genres { get; set; }

        public string Culture { get; set; }

        public ErrorModel Error { get; set; }
    }
}
