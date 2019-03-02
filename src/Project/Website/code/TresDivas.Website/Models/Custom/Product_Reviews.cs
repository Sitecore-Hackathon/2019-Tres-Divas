using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TresDivas.Website.Models.sitecore.templates.Project.TresDivas.Content;

namespace TresDivas.Website.Models.sitecore.templates.Project.TresDivas.Modules
{
    public partial class Product_Reviews : GlassBase, IProduct_Reviews
    {
        [SitecoreChildren(InferType = true)]
        public virtual IEnumerable<Review> ReviewsOfProduct { get; set; }
    }
    
}