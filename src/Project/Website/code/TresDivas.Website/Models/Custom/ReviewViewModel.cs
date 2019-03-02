using System.Collections.Generic;
using TresDivas.Website.Models.sitecore.templates.Project.TresDivas.Modules;

namespace TresDivas.Website.Models.sitecore.templates.Project.TresDivas.Content
{
    public partial class ReviewViewModel 
    {
        
        public Product_Reviews datasourceReview { get; set; }

        public IEnumerable<ReviewAdditional> ReviewsModified { get; set; }

    }

    public class ReviewAdditional
    {


    }
}