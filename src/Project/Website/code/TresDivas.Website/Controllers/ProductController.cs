using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TresDivas.Website.Cogitive;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Foundation.Models;
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
            Product_Reviews datasource;

            if (!string.IsNullOrWhiteSpace(RenderingContext.Current?.Rendering?.DataSource))
            {
                datasource = MvcContext.GetDataSourceItem<Product_Reviews>();
                if(datasource.ReviewsOfProduct != null && datasource.ReviewsOfProduct.Any())
                {
                    //If there are any reviews on xconnect or sitecore, push a call to cognitive services to get back sentiment on each review
                    ITextAnalyticsClient client = new TextAnalyticsClient(new ApiKeyServiceClientCredentials())
                    {
                        Endpoint = "https://westus.api.cognitive.microsoft.com"
                    };
                    List<Review> posReviews = new List<Review>();
                    List<Review> neutralReviews = new List<Review>();
                    List<Review> negativeReviews = new List<Review>();

                    foreach (var review in datasource.ReviewsOfProduct)
                    {
                        if(review != null)
                        {
                            SentimentBatchResult result = client.SentimentAsync(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                          new MultiLanguageInput("en", review.Id.ToString(), review.Review_Text)                         
                        })).Result;

                            if(result != null && result.Documents.Any())
                            {
                                var firstDocument = result.Documents.First();
                                if(firstDocument != null)
                                {
                                    review.SentimentFromCognitive = firstDocument.Score;
                                    

                                    if(review.SentimentFromCognitive > ApiKeyServiceClientCredentials.positiveMinThreshhold && review.SentimentFromCognitive < ApiKeyServiceClientCredentials.positiveThreshhold)
                                    {
                                        posReviews.Add(review);
                                    }
                                    if (review.SentimentFromCognitive > ApiKeyServiceClientCredentials.negativeMinThreshold && review.SentimentFromCognitive < ApiKeyServiceClientCredentials.negativeThreshold)
                                    {
                                        negativeReviews.Add(review);
                                    }
                                    if (review.SentimentFromCognitive > ApiKeyServiceClientCredentials.neutralMinThreshhold && review.SentimentFromCognitive < ApiKeyServiceClientCredentials.neutralThreshold)
                                    {
                                        neutralReviews.Add(review);
                                    }

                                }
                            }

                        }
                    }

                    //Assign bucketed reviews here 
                    datasource.PostiveReviews = posReviews;
                    datasource.NegativeReviews = negativeReviews;
                    datasource.NeutralReviews = neutralReviews;
                }
                return View(Views.Reviews, datasource);
            }
          
            return View(Views.Reviews);
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