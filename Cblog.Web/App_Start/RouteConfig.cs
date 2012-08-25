// ----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="cvlad">
//  RouteConfig
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.App_Start
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Configures the MVC routes.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the MVC routes.
        /// </summary>
        /// <param name="routes">
        /// The route collection.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Blog",
                url: "blog/{slug}",
                defaults: new { controller = "Home", action = "Blog", slug = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}