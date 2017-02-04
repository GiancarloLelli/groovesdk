using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class GenresResponse : ErrorModel
    {
        public IEnumerable<string> Genres { get; set; }

        public string Culture { get; set; }
    }
}
