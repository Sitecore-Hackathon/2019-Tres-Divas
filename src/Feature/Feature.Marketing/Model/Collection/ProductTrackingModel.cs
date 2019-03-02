using Feature.Marketing.Model.Events;
using Feature.Marketing.Model.Facets;
using Sitecore.XConnect;
using Sitecore.XConnect.Collection.Model;
using Sitecore.XConnect.Schema;

namespace Feature.Marketing.Model.Collection
{
    public class ProductTrackingModel
    {
        public static XdbModel Model { get; } = BuildModel();

        private static XdbModel BuildModel()
        {
            XdbModelBuilder modelBuilder = new XdbModelBuilder("ProductTrackingModel", new XdbModelVersion(1, 0));

            modelBuilder.DefineFacet<Contact, TwitterAccountInfo>(FacetKeys.TwitterAccountInfo);
            modelBuilder.DefineEventType<ProductReviewOutcome>(false);
            modelBuilder.DefineEventType<ProductRegistrationGoal>(false);

            modelBuilder.ReferenceModel(CollectionModel.Model);

            return modelBuilder.BuildModel();
        }
        
        public ProductTrackingModel() { }

        public class FacetKeys
        {
            public const string TwitterAccountInfo = "TwitterAccountInfo";
        }


    }
}
