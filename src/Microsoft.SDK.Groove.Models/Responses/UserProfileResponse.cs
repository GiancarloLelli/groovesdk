using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.SDK.Groove.Models.Responses
{
    public class UserProfileResponse : ErrorModel
    {
        public bool IsSubscriptionAvailableForPurchase { get; set; }

        public bool HasSuscription { get; set; }

        public string Culture { get; set; }

        public CollectionModel Collection { get; set; }
    }
}
