using System;
using EPExpressTab.Data;
using Feature.Marketing.Model.Facets;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.Configuration;
using Sitecore.XConnect.Collection.Model;

namespace TresDivas.Website.Classes.ExperienceProfile
{
    public abstract class TabBuilderBase : EpExpressModel
    {
        public Contact GetContact(Guid contactId)
        {
            Contact result = null;
            using (XConnectClient client = SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    result = client.Get<Contact>(new ContactReference(contactId), new ContactExpandOptions(PersonalInformation.DefaultFacetKey, TwitterAccountInfo.DefaultFacetKey)
                    {
                        Interactions = new RelatedInteractionsExpandOptions(LocaleInfo.DefaultFacetKey)
                        {
                            StartDateTime = DateTime.MinValue,
                            EndDateTime = DateTime.UtcNow,
                            Limit = 30
                        }
                    });

                }
                catch (XdbExecutionException ex)
                {
                    // Manage exceptions
                }
            }
            return result;
        }
    }
}
