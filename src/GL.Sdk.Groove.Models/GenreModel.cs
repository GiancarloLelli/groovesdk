using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models
{
    public class GenreModel
    {
        public GenreModel(string text)
        {
            Name = text;
        }

        public string Name { get; set; }
    }
}
