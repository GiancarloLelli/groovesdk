using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models
{
    public class ContinuationModel
    {
        public long TotalItemCount { get; set; }

        public string ContinuationToken { get; set; }
    }
}
