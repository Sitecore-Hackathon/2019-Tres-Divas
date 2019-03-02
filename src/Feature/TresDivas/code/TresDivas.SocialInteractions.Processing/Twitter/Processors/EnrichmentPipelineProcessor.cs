using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.WebApi;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Schema;
using Sitecore.Xdb.Common.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Feature.Marketing.Model.Collection;
using Feature.Marketing.Model.Events;
using Feature.Marketing.Model.Facets;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Rest;
using Sitecore.Tracking.Processing.Abstractions.Pipelines;

namespace TresDivas.SocialInteractions.Processing.Twitter.Processors
{
    public class EnrichmentPipelineProcessor : Processor
    {
        public static string Identifier { get; set; }

        public EnrichmentPipelineProcessor(ILogger<Processor> logger) : base(logger)
        {
        }

        public override Task<PipelineArgs> RunAsync(PipelineArgs arg)
        {
            // Are they verified buyers?
            // Build contact
            Logger.LogInformation("Tres Divas Twitter Interactions EnrichmentPipelineProcessor: " + arg.ProcessingResult.Interaction.Interaction.ChannelId);

            Task.Run(async () => { await Register(arg); }).Wait();

            return Task.FromResult(arg);
        }

        private async Task Register(PipelineArgs arg)
        {
            CertificateHttpClientHandlerModifierOptions options =
                CertificateHttpClientHandlerModifierOptions.Parse("StoreName=My;StoreLocation=LocalMachine;FindType=FindByThumbprint;FindValue=" + Constants.XConnectThumbprint);

            var certificateModifier = new CertificateHttpClientHandlerModifier(options);

            List<IHttpClientModifier> clientModifiers = new List<IHttpClientModifier>();
            var timeoutClientModifier = new TimeoutHttpClientModifier(new TimeSpan(0, 0, 20));
            clientModifiers.Add(timeoutClientModifier);

            var collectionClient = new CollectionWebApiClient(new Uri(Constants.XConnectInstance + "/odata"), clientModifiers, new[] { certificateModifier });
            var searchClient = new SearchWebApiClient(new Uri(Constants.XConnectInstance + "/odata"), clientModifiers, new[] { certificateModifier });
            var configurationClient = new ConfigurationWebApiClient(new Uri(Constants.XConnectInstance + "/configuration"), clientModifiers, new[] { certificateModifier });

            var cfg = new XConnectClientConfiguration(
                new XdbRuntimeModel(ProductTrackingModel.Model), collectionClient, searchClient, configurationClient);
           

            foreach (var interactionEvent in arg.ProcessingResult.Interaction.Interaction.Events)
            {
                if (interactionEvent.CustomValues != null && interactionEvent.CustomValues.Count > 0)
                {
                    var name = interactionEvent.CustomValues["name"].Split(' ');
                    var firstName = name[0] != null ? name[0] : "Not Available";
                    var lastName =  name.Length > 1 ? name[1] : "Not Available";

                    var twitterHandle = interactionEvent.CustomValues["twitterhandle"];
                    var twitterHandleCreated = Convert.ToDateTime(interactionEvent.CustomValues["twitterhandlecreated"]);
                    var numberOfFollowers = Convert.ToInt32(interactionEvent.CustomValues["followerscount"]);
                    var tweetfulltext = interactionEvent.CustomValues["tweetfulltext"];
                    var hashtag = interactionEvent.CustomValues["hashtags"];

                    await cfg.InitializeAsync();
                    using (var client = new XConnectClient(cfg))
                    {
                        try
                        {

                            ContactIdentifier contactIdentifier = new ContactIdentifier("twitter", twitterHandle, ContactIdentifierType.Known);

                            // Let's just save this for later
                            //TODO: If time check for existing user.
                            Identifier = contactIdentifier.Identifier;
                            Contact contact = new Contact(contactIdentifier);

                            //TODO Get from args custom values "Name". If space save first and last
                            PersonalInformation personalInfo = new PersonalInformation()
                            {
                                FirstName = firstName,
                                LastName = lastName
                            };

                            
                            // TODO get from args
                            TwitterAccountInfo visitorInfo = new TwitterAccountInfo()
                            {
                                TwitterHandle = twitterHandle,
                                TwitterStartDate = twitterHandleCreated,
                                NumberOfFollowers = numberOfFollowers,
                                VerifiedTwitterHandle = false
                            };

                            client.AddContact(contact);
                            client.SetFacet(contact, TwitterAccountInfo.DefaultFacetKey, visitorInfo);
                            client.SetFacet(contact, PersonalInformation.DefaultFacetKey, personalInfo);

                            var interaction = new Interaction(contact, InteractionInitiator.Contact, arg.ProcessingResult.Interaction.Interaction.ChannelId, ""); // GUID should be from a channel item in Sitecore

                            //TODO Get from args
                            
                            var productTweet = new ProductTweet();
                            productTweet.Tweet = tweetfulltext;
                            productTweet.ProductHashtag = hashtag;
                            productTweet.TwitterHandle = twitterHandle;

                            ITextAnalyticsClient cogClient = new TextAnalyticsClient(new ApiKeyServiceClientCredentials())
                            {
                                Endpoint = "https://westus.api.cognitive.microsoft.com"
                            };

                            SentimentBatchResult result = cogClient.SentimentAsync(
                                new MultiLanguageBatchInput(
                                    new List<MultiLanguageInput>()
                                    {
                                        new MultiLanguageInput("en", new Guid().ToString(), productTweet.Tweet)
                                    })).Result;

                            if (result != null && result.Documents.Any())
                            {
                                var firstDocument = result.Documents.First();
                                if (firstDocument != null)
                                {
                                    productTweet.Sentiment = firstDocument.Score;
                                }
                            }

                            interaction.Events.Add(new ProductReviewOutcome(productTweet, DateTime.UtcNow));
                            client.AddInteraction(interaction);
                            await client.SubmitAsync();
                        }
                        catch (XdbExecutionException ex)
                        {
                            // Deal with exception
                            Logger.LogInformation("Tres Divas Twitter Interactions EnrichmentPipelineProcessor: ", ex);
                        }
                    }


                }
            }


            
        }
    }

    public class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        private const string SubscriptionKey = "33292a7a07c84bad88e8a132ca1f3eb7";

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }

        


    }
}
