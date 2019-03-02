using Feature.Marketing.Model.Events;
using Feature.Marketing.Model.Facets;
using Foundation.Models;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.Configuration;
using Sitecore.XConnect.Collection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TresDivas.Website.Cogitive;
using Product_Reviews = Foundation.Models.Product_Reviews;

namespace TresDivas.Website.Controllers
{
    public class ProductController : GlassController
    {
        // GET: Product Details
        public ActionResult Details()
        {
            Product_Details datasource;
            if (!string.IsNullOrWhiteSpace(RenderingContext.Current?.Rendering?.DataSource))
            {
                datasource = MvcContext.GetDataSourceItem<Product_Details>();
            }

            return View(Views.Detail);
        }
        // GET: Product Reviews
        public ActionResult Reviews()
        {
            Product_Reviews datasource = new Product_Reviews();

            var product = MvcContext.GetDataSourceItem<Product_Details>();

            if (product == null) return null;

            
            List<Review> allReviews = GetProductReviewsByHastag(product.Product_HashTag);

            List<Review> posReviews = new List<Review>();
            List<Review> neutralReviews = new List<Review>();
            List<Review> negativeReviews = new List<Review>();

            foreach (var review in allReviews)
            {
                if (review != null)
                {
                    if (review.SentimentFromCognitive > ApiKeyServiceClientCredentials.positiveMinThreshhold &&
                        review.SentimentFromCognitive < ApiKeyServiceClientCredentials.positiveThreshhold)
                    {
                        posReviews.Add(review);
                    }

                    if (review.SentimentFromCognitive > ApiKeyServiceClientCredentials.negativeMinThreshold &&
                        review.SentimentFromCognitive < ApiKeyServiceClientCredentials.negativeThreshold)
                    {
                        negativeReviews.Add(review);
                    }

                    if (review.SentimentFromCognitive > ApiKeyServiceClientCredentials.neutralMinThreshhold &&
                        review.SentimentFromCognitive < ApiKeyServiceClientCredentials.neutralThreshold)
                    {
                        neutralReviews.Add(review);
                    }
                }
            }

            //Assign bucketed reviews here 
            datasource.PostiveReviews = posReviews;
            datasource.NegativeReviews = negativeReviews;
            datasource.NeutralReviews = neutralReviews;

            return View(Views.Reviews, datasource);
        }

        private List<Review> GetProductReviewsByHastag(string hashtag)
        {
            var pertinentReviews = new List<Review>();

            Contact result;

            using (XConnectClient client = SitecoreXConnectClientConfiguration.GetClient())
            {

                var enumerator = client.Contacts.Where(c => c.Identifiers.Any(s => s.Source == "twitter")).GetBatchEnumeratorSync(100);

                try
                {
                    while (enumerator.MoveNext())
                    {
                        // Cycle through batch of 100
                        if (enumerator.Current == null) continue;

                        foreach (Contact contact in enumerator.Current)
                        {
                            if (contact.Id == null) continue;

                            Guid contactIdentifier = (Guid)contact.Id;

                            result = client.Get<Contact>(new ContactReference(contactIdentifier), new ContactExpandOptions(PersonalInformation.DefaultFacetKey, TwitterAccountInfo.DefaultFacetKey)
                            {
                                Interactions = new RelatedInteractionsExpandOptions(LocaleInfo.DefaultFacetKey)
                                {
                                    StartDateTime = DateTime.MinValue,
                                    EndDateTime = DateTime.UtcNow,
                                    Limit = 30
                                }
                            });

                            if (result == null) continue;

                            var newReview = new Review();

                            var interactions = result.Interactions;

                            foreach (var interaction in interactions)
                            {
                                foreach (var evt in interaction.Events)
                                {

                                    if (evt.GetType() != typeof(ProductReviewOutcome)) continue;

                                    var tweetAboutProd = (ProductReviewOutcome)evt;

                                    var review = tweetAboutProd.ProductTweet;

                                    if (review == null) continue;

                                    if (review.ProductHashtag != hashtag.ToLowerInvariant()) continue;

                                    newReview.Review_Text = review.Tweet;
                                    newReview.Twitter_Handle = review.TwitterHandle;
                                    newReview.SentimentFromCognitive = review.Sentiment;
                                }

                                pertinentReviews.Add(newReview);
                            }
                        }
                    }
                }
                catch (XdbExecutionException ex)
                {
                    // Manage exceptions
                }
            }
            return pertinentReviews;
        }

        protected static class Views
        {
            /// <summary>
            /// FAQ Detail View
            /// </summary>
            public const string Detail = "~/Views/Product/ProductDetail.cshtml";
            public const string Reviews = "~/Views/Product/ProductReviews.cshtml";
        }

    }


}