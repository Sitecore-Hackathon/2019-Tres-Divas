using System;
using Sitecore.XConnect;

namespace Feature.Marketing.Model.Events
{
    public class ProductReviewOutcome : Outcome
    {
        //sitecore/system/Marketing Control Panel/Outcomes/Products/Product Review Outcomes/Product Review
        public static Guid OutcomeDefinitionId { get; } = new Guid("0370a334-23d3-4002-9b7e-f09c571fd9c5");

        public ProductTweet ProductTweet { get; set; }

        public ProductReviewOutcome()
            : base(OutcomeDefinitionId, DateTime.Now, null, 0)
        { }

        public ProductReviewOutcome(ProductTweet productTweet, DateTime timestamp) 
            : base(OutcomeDefinitionId, timestamp, null, 0)
        {
            ProductTweet = productTweet;
        }
    }

    public class ProductTweet
    {
        public string ProductHashtag { get; set; } // contains unique identifier for product

        public string Tweet { get; set; }

        public decimal Sentiment { get; set; }
    }
}
