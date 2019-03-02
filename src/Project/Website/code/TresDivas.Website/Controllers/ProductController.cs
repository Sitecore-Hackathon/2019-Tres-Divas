using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Foundation.Models;
using Product_Reviews = Foundation.Models.Custom.Product_Reviews;

namespace TresDivas.Website.Controllers
{
    public class ProductController : GlassController
    {
        // GET: Product Details
        public ActionResult Details()
        {
            Product_Details datasource;
            if (!string.IsNullOrWhiteSpace(RenderingContext.Current?.Rendering?.DataSource))
            {
                datasource = SitecoreContext.GetItem<Product_Details>(RenderingContext.Current.Rendering.DataSource);
            }
           
            return View(Views.Detail);
        }
        // GET: Product Reviews
        public ActionResult Reviews()
        {
            Product_Reviews datasource;
            if (!string.IsNullOrWhiteSpace(RenderingContext.Current?.Rendering?.DataSource))
            {
                datasource = SitecoreContext.GetItem<Product_Reviews>(RenderingContext.Current.Rendering.DataSource);
            }
          
            return View(Views.Reviews);
        }

        protected static class Views
        {
            /// <summary>
            /// FAQ Detail View
            /// </summary>
            public const string Detail = "~/Views/Product/ProductDetail.cshtml";
            public const string Reviews = "~/Views/Product/ProductReviews.cshtml";
        }

    }

   
}