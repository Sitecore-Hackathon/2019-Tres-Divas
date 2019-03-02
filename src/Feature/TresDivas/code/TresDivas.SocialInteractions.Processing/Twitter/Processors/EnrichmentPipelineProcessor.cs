using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.WebApi;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Schema;
using Sitecore.Xdb.Common.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feature.Marketing.Model.Collection;
using Feature.Marketing.Model.Events;
using Feature.Marketing.Model.Facets;
using Microsoft.Extensions.Logging;
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

            //Task.Run(async () => { await Register(); }).Wait();

            return Task.FromResult(arg);
        }

        private async Task Register()
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


            using (var client = new XConnectClient(cfg))
            {
                try
                {
                    ContactIdentifier contactIdentifier = new ContactIdentifier("twitter", "ProductSocial-" + "twitterHandle from args", ContactIdentifierType.Known);

                    // Let's just save this for later
                    //TODO: If time check for existing user.
                    Identifier = contactIdentifier.Identifier;
                    Contact contact = new Contact(contactIdentifier);

                    //TODO Get from args custom values "Name". If space save first and last
                    PersonalInformation personalInfo = new PersonalInformation()
                    {
                        FirstName = "firstname",
                        LastName = "lastname"
                    };

                    //Console.WriteLine("Twitter Handle?");

                    //var handle = Console.ReadLine();

                    // TODO get from args
                    TwitterAccountInfo visitorInfo = new TwitterAccountInfo()
                    {
                        TwitterHandle = "handle",
                        TwitterStartDate = new DateTime(2006, 12, 15),
                        NumberOfFollowers = 300,
                        VerifiedTwitterHandle = false
                    };

                    client.AddContact(contact);
                    client.SetFacet(contact, TwitterAccountInfo.DefaultFacetKey, visitorInfo);
                    client.SetFacet(contact, PersonalInformation.DefaultFacetKey, personalInfo);

                    var interaction = new Interaction(contact, InteractionInitiator.Contact, Guid.NewGuid(), ""); // GUID should be from a channel item in Sitecore

                    //TODO Get from args
                    var productTweet = new ProductTweet(); 
                    productTweet.Tweet = "";
                    productTweet.ProductHashtag = "";

                    //TODO : Cognitive API Call from Deepthi's code
                    //productTweet.Sentiment = decimal.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

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
