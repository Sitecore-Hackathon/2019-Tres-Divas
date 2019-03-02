using System;
using Sitecore.XConnect;

namespace Feature.Marketing.Model.Events
{
    public class ProductRegistrationGoal : Goal
    {
        //sitecore/system/Marketing Control Panel/Goals/Product Registration/Registration
        public static Guid GoalDefinitionId { get; } = new Guid("7c555fbf-71d3-4d89-bc85-23f919733d08");

        public ProductRegistration ProductRegistration { get; set; } // contains unique identifier for product

        public ProductRegistrationGoal()
            : base(GoalDefinitionId, DateTime.Now) { }

        public ProductRegistrationGoal(ProductRegistration productRegistration, DateTime timestamp) 
            : base(GoalDefinitionId, timestamp)
        {
            ProductRegistration = productRegistration;
        }
    }

    public class ProductRegistration
    {
        public string ProductHashtag { get; set; } // contains unique identifier for product

        public string SerialNumber { get; set; }
    }
}
