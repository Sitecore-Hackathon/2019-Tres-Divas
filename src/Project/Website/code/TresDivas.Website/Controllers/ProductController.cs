using Glass.Mapper.Sc.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TresDivas.Website.Controllers
{
    public class ProductController : GlassController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
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