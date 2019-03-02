using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using TresDivas.Website.Models;

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
        public JsonResult GetTwitterFilterByHashtag(string hashtag)
        {

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
            var db = Factory.GetDatabase("master");

            var listingParentItem = db.GetItem(new ID(TwitterFilterParentGuid));

            var fullList = new List<Twitter_UT_Filters>();

            if (listingParentItem == null || !listingParentItem.HasChildren) return fullList;

            foreach (Item item in listingParentItem.Axes.GetDescendants())
            {
                var listing = new Twitter_UT_Filters();

                if (item.TemplateID != new ID(FilterTemplateGuid)) continue;


                listing.Product_Name = item.Fields["Product Name"].Value;
                listing.Channel = item.Fields["Channel"].Value;
                listing.Goal_Or_Outcome = item.Fields["Goal or Outcome"].Value;
                listing.Product_Hashtag = item.Fields["Product Hashtag"].Value;
                listing.Twitter_Account_Age = item.Fields["Twitter Account Age"].Value;
                listing.Minimum_Followers = item.Fields["Minimum Followers"].Value;
                listing.Filter_Out_Retweets = item.Fields["Filter Out Retweets"]?.Value == "1";

                fullList.Add(listing);
            }

            return fullList;
        }
    }
}