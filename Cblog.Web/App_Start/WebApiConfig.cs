// ----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="cvlad">
//  WebApiConfig
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.App_Start
{
    using System.Web.Http;

    /// <summary>
    /// Configures the WebApi routes.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the WebApi routes.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
