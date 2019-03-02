using System.Web.Mvc;
using System.Web.Routing;

namespace TresDivas.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Sitecore will handle this route.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "TwitterFilterApi", action = "Index"}
            );

            routes.MapRoute(
                name: "ByHashtag",
                url: "{controller}/{action}/{hashtag}",
                defaults: new { controller = "TwitterFilterApi", action = "GetTwitterFilterByHashtag", hashtag = UrlParameter.Optional}
            );
        }
    }
}
