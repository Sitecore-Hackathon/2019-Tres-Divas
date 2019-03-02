using System;
using System.Collections.Generic;
using Sitecore.UniversalTrackerClient.Entities;
using Sitecore.UniversalTrackerClient.Request.RequestBuilder;
using Sitecore.UniversalTrackerClient.Session.SessionBuilder;
using Tweetinvi;
using Tweetinvi.Models;
using System.Linq;


namespace TresDivas.Console
{
    class Program
    {
        public const string TwitterApiKey = "uyxX2aH6Hd3MDGDYnxaiyNR0u";
        public const string TwitterApiSecretKey = "MQdMRdmKAyX5C9FFXp1chZp8Ut4lJWBObOqqlppqCQcKl6n33Q";
        public const string TwitterAccessToken = "187039570-Zmsqhp8mbHdE8Tk7ung7Nl5P9a0BFHaR9brUiZoE";
        public const string TwitterAccessTokenSecret = "49a0owIcTgiDIC9tZOlTsmh0j3UNHXBSAImM0KPftli7F";

        public static void Main(string[] args)
        {
            string instanceUrl = "https://Hackathon-Sitecore-Tracking-Collection-Service.local.com";
            //string channelId = "6d3d2374-af56-44fe-b99a-20843b440b58";
            string channelId = "6d3d2374-af56-44fe-b99a-20843b440b58"; // Channel Id of the channel: /sitecore/system/Marketing Control Panel/Taxonomies/Channel/Online/Social community/Twitter social community
            //string definitionId = "55555555-d662-4a87-beee-413307055c48";
            string definitionId = "ff1d9360-8a31-4779-ad1a-d4a8178b865a"; // Goal definitionId of the goal: /sitecore/system/Marketing Control Panel/Goals/Sandbox/Twitter Hackathon

            Auth.SetUserCredentials(TwitterApiKey, TwitterApiSecretKey, TwitterAccessToken, TwitterAccessTokenSecret);
            var user = User.GetAuthenticatedUser();

            System.Console.WriteLine(user);

            var stream = Stream.CreateFilteredStream();

            //stream.AddTrack("\ud83d\udd25"); //fire emoji
            stream.AddTrack("oscars"); //sitecore
            stream.AddTweetLanguageFilter(LanguageFilter.English);

            System.Console.WriteLine("I am listening to Twitter for oscars ...");

            stream.MatchingTweetReceived += (sender, arguments) =>
            {
                var theTweet = arguments.Tweet;

                //stringify hashtags
                var hashtags = theTweet.Hashtags.ToList();
                var hashtagString = string.Join(", ", hashtags);

                // emoji troubleshooting below ...
                //Encoding ascii = Encoding.ASCII;
                //Encoding unicode = Encoding.Unicode;

                //// Convert the string into a byte array.
                //byte[] unicodeBytes = unicode.GetBytes(theTweet.FullText);

                //// Perform the conversion from one encoding to the other.
                //byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

                //// Convert the new byte[] into a char[] and then into a string.
                //char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
                //ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
                //string asciiString = new string(asciiChars);

                //// Display the strings created before and after the conversion.
                //Console.WriteLine("Original string: {0}", theTweet.Text);
                //Console.WriteLine("Ascii converted string: {0}", asciiString);

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
                        .Contact("twitter", theTweet.CreatedBy.UserIdentifier.ScreenName)
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

                        dict.Add("twitterHandle", "@" + theTweet.CreatedBy.UserIdentifier.ScreenName);
                        dict.Add("hashtags", "here: " + hashtagString);

                        var eventRequest = UTRequestBuilder.PageViewWithDefenitionId(definitionId)
                            .Timestamp(DateTime.Now)
                            .AddCustomValues(dict)
                            .EngagementValue(305)
                            .Text(theTweet.FullText)
                            .Url("www.twitter.com")
                            .Build();
                        var eventResponse = session.TrackPageViewEventAsync(eventRequest);
                        System.Console.WriteLine("Track EVENT RESULT: " + eventResponse.Result.StatusCode);
                    }
                }
            };

            stream.StartStreamMatchingAllConditions();

            System.Console.ReadLine();
        }
    }
}
