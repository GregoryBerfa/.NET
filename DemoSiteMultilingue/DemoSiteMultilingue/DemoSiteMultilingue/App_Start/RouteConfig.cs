using DemoSiteMultilingue.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemoSiteMultilingue
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ArticleEn", "en/my-great-article",new { lang = "en", controller = "Home", action = "MyArticle" } );
            routes.MapRoute("ArticleFr", "fr/mon-super-article",new { lang = "fr", controller = "Home", action = "MyArticle" } );

            routes.MapRoute("HomeEn","en", new { lang = "en", controller = "Home", action = "Index" } );
            routes.MapRoute("HomeFr", "fr", new { lang = "fr", controller = "Home", action = "Index" } );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
