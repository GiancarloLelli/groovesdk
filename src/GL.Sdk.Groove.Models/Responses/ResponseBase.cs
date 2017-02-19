using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class ResponseBase
    {
        public string Culture { get; set; }

        public ErrorModel Error { get; set; }
    }
}
