using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class GenresResponse : ResponseBase
    {
        public IEnumerable<string> Genres { get; set; }
    }
}
