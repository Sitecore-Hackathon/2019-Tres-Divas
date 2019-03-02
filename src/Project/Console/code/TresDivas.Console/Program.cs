using System;
using System.Collections.Generic;
using System.IO;
using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.Request.RequestBuilder;
using Sitecore.UniversalTrackerClient.Session.SessionBuilder;
using Tweetinvi;
using Tweetinvi.Models;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using TresDivas.Website.Models.sitecore.templates.Feature.Tres_Divas.Marketing;
using Tweetinvi.Core.Extensions;
using Stream = Tweetinvi.Stream;


namespace TresDivas.Console
{
    class Program
    {
        public const string TwitterApiKey = "K9zwVXwdjmsxVSfoEHd1gxluQ";
        public const string TwitterApiSecretKey = "YHTDuz9NojmDr5WP0i91mHsfGyHkQ6YwRGzPmFwFvdVqaR9Amz";
        public const string TwitterAccessToken = "26886163-SR9DcWa3757tJDH1OCNpgFgoYIZlslYltkmx9Mg0U";
        public const string TwitterAccessTokenSecret = "dKFkYf4NjCzfaFzxezddMzFh94Gg9cmAVMHmvDDtLDxin";

        public static void Main(string[] args)
        {
            string instanceUrl = "https://Hackathon-Sitecore-Tracking-Collection-Service.local.com";
            //string channelId = "6d3d2374-af56-44fe-b99a-20843b440b58";
            string channelId = "6d3d2374-af56-44fe-b99a-20843b440b58"; // Channel Id of the channel: /sitecore/system/Marketing Control Panel/Taxonomies/Channel/Online/Social community/Twitter social community
            //string definitionId = "55555555-d662-4a87-beee-413307055c48";
            string definitionId = "ff1d9360-8a31-4779-ad1a-d4a8178b865a"; // Goal definitionId of the goal: /sitecore/system/Marketing Control Panel/Goals/Sandbox/Twitter Hackathon

            Auth.SetUserCredentials(TwitterApiKey, TwitterApiSecretKey, TwitterAccessToken, TwitterAccessTokenSecret);
            var user = User.GetAuthenticatedUser();

            // Get all twitter filters and put them in a list
            var filtersFromSitecore = GetFilters();

            // Use the channel from the filter.
            var hashTags = filtersFromSitecore.Select(p => p.Product_Hashtag.Trim()).Distinct();
            var hashtagString = string.Join(" OR ", hashTags);

            System.Console.WriteLine(user);

            var stream = Stream.CreateFilteredStream();

            //stream.AddTrack("\ud83d\udd25"); //fire emoji
            hashTags.ForEach(ht=> stream.AddTrack(ht));
            stream.AddTweetLanguageFilter(LanguageFilter.English);

            System.Console.WriteLine("I am listening to Twitter for Product Hashtags:" + hashtagString + "...");

            stream.MatchingTweetReceived += (sender, arguments) =>
            {
                var theTweet = arguments.Tweet;

                //stringify hashtags
                var hashtags = theTweet.Hashtags.ToList();
                var tweetHashtags = hashtags.Count > 0 ? string.Join(", ", hashtags) : string.Empty;

                // Name
                var name = theTweet.CreatedBy.Name;

                // Name
                var twitterHandle = theTweet.CreatedBy.ScreenName;

                // Number of followers
                var followersCount = theTweet.CreatedBy.FollowersCount;

                // Account Description
                var twitterHandleDescription = theTweet.CreatedBy.Description ?? "Not Available";

                // Created At - Account
                var twitterHandleCreated = theTweet.CreatedBy.CreatedAt;

                // Tweet Full Text
                var tweetFullText = theTweet.FullText;

                // Is Retweet
                var isRetweet = theTweet.IsRetweet;

                // var verified
                var isVerified = theTweet.CreatedBy.Verified;

                System.Console.WriteLine(theTweet.FullText);
                System.Console.WriteLine(hashtagString);
                System.Console.WriteLine(theTweet.CreatedBy);
                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine();

                if (!theTweet.Retweeted)
                {
                    var defaultInteraction = UTEntitiesBuilder.Interaction()
                        .ChannelId(channelId)
                        .Initiator(InteractionInitiator.Contact)
                        .Contact("twitter", twitterHandle)
                        .CampaignId("33333333-d662-4a87-beee-413307055c48")
                        .VenueId("44444444-d662-4a87-beee-413307055c48")
                        .UserAgent("ConsoleApp not a browser")
                        .Build();
                    using (var session = SitecoreUTSessionBuilder.SessionWithHost(instanceUrl)
                        .DefaultInteraction(defaultInteraction)
                        .TokenValue("mytokenvalue")
                        .BuildSession()
                    )
                    {
                        var dict = new Dictionary<string, string>();

                        dict.Add("twitterHandle", "@" + twitterHandle);
                        dict.Add("hashtags", "here: " + tweetHashtags);
                        dict.Add("name", name);
                        dict.Add("followersCount", followersCount.ToString());
                        dict.Add("twitterHandleDescription", twitterHandleDescription);
                        dict.Add("twitterHandleCreated", twitterHandleCreated.ToShortDateString());
                        dict.Add("tweetFullText", tweetFullText);
                        dict.Add("isRetweet", isRetweet.ToString());
                        dict.Add("isVerified", isVerified.ToString());

                        var eventRequest = UTRequestBuilder.OutcomeWithDefenitionId(definitionId) // outcome id
                            .Timestamp(DateTime.Now)
                            .AddCustomValues(dict)
                            .EngagementValue(305)
                            .Text(theTweet.FullText)
                            .Build();
                        var eventResponse = session.TrackOutcomeEventAsync(eventRequest);
                        System.Console.WriteLine("Track EVENT RESULT: " + eventResponse.Result.StatusCode);
                    }
                }
            };

            stream.StartStreamMatchingAllConditions();

            System.Console.ReadLine();
        }

        public static List<Twitter_UT_Filters> GetFilters()
        {
            var filters = new List<Twitter_UT_Filters>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ut.hackathon.com/api/sitecore/TwitterFilterApi");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var responseStream = httpResponse.GetResponseStream();
            if (responseStream == null)
            {
                return filters;
            }

            using (var streamReader = new StreamReader(responseStream))
            {
                var responseText = streamReader.ReadToEnd();
                var response = JsonConvert.DeserializeObject<FiltersResponse>(responseText);
                filters = response.Response;
            }

            return filters;
        }
    }


    public class FiltersResponse
    {
        public FiltersResponse()
        {
            Response= new List<Twitter_UT_Filters>();
        }

        public List<Twitter_UT_Filters> Response { get; set; }

        public bool Success { get; set; }
    }
}

