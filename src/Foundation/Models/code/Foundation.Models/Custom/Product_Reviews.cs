using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Foundation.Models.Custom
{
    public partial class Product_Reviews : GlassBase, IProduct_Reviews
    {
        [SitecoreChildren(InferType = true)]
        public virtual IEnumerable<Review> ReviewsOfProduct { get; set; }

        public string Review_Description { get; set; }
        public string Reviews_Title { get; set; }
    }
    
}