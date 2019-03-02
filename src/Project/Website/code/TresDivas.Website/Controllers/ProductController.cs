using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TresDivas.Website.Models.sitecore.templates.Project.TresDivas.Modules;

namespace TresDivas.Website.Controllers
{
    public class ProductController : GlassController
    {
        // GET: Product
        public ActionResult Details()
        {
            Product_Details datasource;
            if (!string.IsNullOrWhiteSpace(RenderingContext.Current?.Rendering?.DataSource))
            {
                datasource = SitecoreContext.GetItem<Product_Details>(RenderingContext.Current.Rendering.DataSource);
            }
            else
            {
                datasource = SitecoreContext.GetCurrentItem<Product_Details>();
            }
            return View(Views.Detail, datasource);
        }
        protected static class Views
        {
            /// <summary>
            /// FAQ Detail View
            /// </summary>
            public const string Detail = "~/Views/Product/ProductDetail.cshtml";
        }

    }

   
}