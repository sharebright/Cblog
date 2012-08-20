// ----------------------------------------------------------------------
// <copyright file="Bootstrapper.cs" company="">
//  Bootstrapper
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web
{
    using System.Web.Mvc;
    using Cblog.Model;
    using Cblog.Model.Models;
    using Cblog.Service;
    using Microsoft.Practices.Unity;
    using Unity.Mvc3;

    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

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