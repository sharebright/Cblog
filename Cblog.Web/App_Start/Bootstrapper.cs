// ----------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="cvlad">
//  Bootstrapper
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.App_Start
{
    using System.Web.Mvc;
    using Cblog.Model;
    using Cblog.Model.Models;
    using Cblog.Service;
    using Microsoft.Practices.Unity;
    using Unity.Mvc3;

    /// <summary>
    /// Bootstraps the Dependency Injection container for MVC.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Initialises the DI container.
        /// </summary>
        public static void Initialise()
        {
            // TODO: make it work with WEB API as well.
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        /// <summary>
        /// The build unity container.
        /// </summary>
        /// <returns>
        /// The Microsoft.Practices.Unity.IUnityContainer.
        /// </returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();            
            container.RegisterType<IContext, CblogContext>();
            container.RegisterType<IBlogService, BlogService>();

            return container;
        }
    }
}