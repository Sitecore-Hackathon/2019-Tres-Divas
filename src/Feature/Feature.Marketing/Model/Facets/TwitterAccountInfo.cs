using System;
using Sitecore.XConnect;

namespace Feature.Marketing.Model.Facets
{
    [FacetKey(DefaultFacetKey)]
    public class TwitterAccountInfo : Facet
    {
        public const string DefaultFacetKey = "TwitterAccountInfo";

        public string TwitterHandle { get; set; }

        public DateTime TwitterStartDate { get; set; }

        public int NumberOfFollowers { get; set; }

        public bool VerifiedTwitterHandle { get; set; }
    }
}
