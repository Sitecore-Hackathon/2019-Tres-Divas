using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using TresDivas.Website.Models;
using TresDivas.Website.Models.sitecore.templates.Feature.Tres_Divas.Marketing;

namespace TresDivas.Website.Controllers
{
    public class TwitterFilterApiController : Controller
    {
        private const string TwitterFilterParentGuid = "{FED675BD-4B31-46AB-BA30-B45FF781BAAF}";
        private const string FilterTemplateGuid = "{E0FA547F-F051-4C50-987D-083F43C8543A}";

        [HttpGet]
        // GET: Twitter Filter Settings
        public JsonResult Index()
        {
            var listing = new List<Twitter_UT_Filters>();

            var result = new
            {
                Success = false,
                Response = listing
            };

            listing = GetFilters();

            result = new
            {
                Success = true,
                Response = listing
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        // GET: Twitter Filter By Hashtag
        public JsonResult GetTwitterFilterByHashtag(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Wee need hashtag passed in.");
            }
            
            var hashtag = id.ToLowerInvariant();
            

            if (!hashtag.StartsWith("#"))
            {
                hashtag = $"#{hashtag.ToLowerInvariant()}";
            }

            var listing = GetFilters();

           var filter = new Twitter_UT_Filters();

            var result = new
            {
                Success = false,
                Response = filter
            };

            if (listing == null || !listing.Any()) return Json(result, JsonRequestBehavior.AllowGet);

            filter = listing.FirstOrDefault(x => x.Product_Hashtag == hashtag.ToLowerInvariant());

            result = new
            {
                Success = true,
                Response = filter
            };

            return Json(result, JsonRequestBehavior.AllowGet);

        }  

        private List<Twitter_UT_Filters> GetFilters()
        {
            var db = Factory.GetDatabase("web");

            var listingParentItem = db.GetItem(new ID(TwitterFilterParentGuid));

            var fullList = new List<Twitter_UT_Filters>();

            if (listingParentItem == null || !listingParentItem.HasChildren) return fullList;

            foreach (Item item in listingParentItem.Axes.GetDescendants())
            {
                var listing = new Twitter_UT_Filters();

                if (item.TemplateID != new ID(FilterTemplateGuid)) continue;

                SitecoreService sitecoreService = new SitecoreService(db);

                var model = sitecoreService.GetItem<Twitter_UT_Filters>(item);
                
                listing.Product_Name = model.Product_Name;
                listing.Channel = model.Channel;
                listing.Goal_Or_Outcome = model.Goal_Or_Outcome;
                listing.Product_Hashtag = model.Product_Hashtag;
                listing.Twitter_Account_Age = model.Twitter_Account_Age;
                listing.Minimum_Followers = model.Minimum_Followers;
                listing.Filter_Out_Retweets = model.Filter_Out_Retweets;

                fullList.Add(listing);
            }

            return fullList;
        }
    }
}