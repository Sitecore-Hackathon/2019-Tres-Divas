using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;

namespace Foundation.Models
{
    public partial class Product_Reviews : GlassBase, IProduct_Reviews
    {
        [SitecoreChildren(InferType = true)]
        public virtual IEnumerable<Review> ReviewsOfProduct { get; set; }

        public virtual List<Review> PostiveReviews { get; set; }
        public virtual List<Review> NeutralReviews { get; set; }
        public virtual List<Review> NegativeReviews { get; set; }
    }
    
}