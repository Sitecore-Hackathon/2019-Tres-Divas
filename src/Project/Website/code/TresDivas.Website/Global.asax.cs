using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace TresDivas.Website
{
    public class Global : Sitecore.Web.Application
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}