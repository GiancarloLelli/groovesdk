using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class MusicPassAvailabilityResponse : ErrorModel
    {
        public bool IsSubscriptionAvailableForPurchase { get; set; }

        public string Culture { get; set; }
    }
}
