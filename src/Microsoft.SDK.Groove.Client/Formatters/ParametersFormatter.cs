using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Client.Formatters
{
    public class ParametersFormatter
    {
        public static string Format(string[] _array)
        {
            if (_array.Length == 0 || _array == null || _array.Length > 10)
                return string.Empty;

            return string.Join("+", _array);
        }
    }
}
