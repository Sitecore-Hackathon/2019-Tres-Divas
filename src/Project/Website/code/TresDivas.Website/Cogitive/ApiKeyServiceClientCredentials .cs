using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;
using Microsoft.Rest;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TresDivas.Website.Cogitive
{
    public class ApiKeyServiceClientCredentials: ServiceClientCredentials
    {
        private const string SubscriptionKey = "33292a7a07c84bad88e8a132ca1f3eb7";         
      
            public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
                return base.ProcessHttpRequestAsync(request, cancellationToken);
            }

        public static double positiveMinThreshhold = 0.8;
        public static double positiveThreshhold = 1;
        public static double negativeMinThreshold = 0;
        public static double negativeThreshold = 0.2;
        public static double neutralMinThreshhold = 0.2;
        public static double neutralThreshold = 0.5;


    }
}