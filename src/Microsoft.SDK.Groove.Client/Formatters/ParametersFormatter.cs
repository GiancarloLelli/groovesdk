using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.SDK.Groove.Client.Formatters
{
    public class ParametersFormatter
    {
        public static string Format(IEnumerable<string> _array)
        {
            if (_array.Count() == 0 || _array == null || _array.Count() > 10)
                return string.Empty;

            return string.Join("+", _array);
        }
    }
}
