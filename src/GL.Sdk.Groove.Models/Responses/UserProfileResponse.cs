using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Responses
{
    public class UserProfileResponse
    {
        public bool IsSubscriptionAvailableForPurchase { get; set; }

        public bool HasSuscription { get; set; }

        public string Culture { get; set; }

        public CollectionModel Collection { get; set; }

        public SubscriptionModel Subscription { get; set; }

        public ErrorModel Error { get; set; }
    }
}
