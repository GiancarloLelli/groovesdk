using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class UserProfileResponse : ResponseBase
    {
        public bool IsSubscriptionAvailableForPurchase { get; set; }

        public bool HasSuscription { get; set; }

        public CollectionModel Collection { get; set; }

        public SubscriptionModel Subscription { get; set; }
    }
}
