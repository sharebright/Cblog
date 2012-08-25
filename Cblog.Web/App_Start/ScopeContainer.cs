// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScopeContainer.cs" company="cvlad">
//   ScopeContainer
// </copyright>
// <summary>
//   Defines the ScopeContainer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Cblog.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The scope container.
    /// </summary>
    public class ScopeContainer : IDependencyScope
    {
        /// <summary>
        /// The Container.
        /// </summary>
        protected readonly IUnityContainer Container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeContainer"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public ScopeContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <returns>
        /// The retrieved service.
        /// </returns>
        /// <param name="serviceType">The service to be retrieved.</param>
        public object GetService(Type serviceType)
        {
            return this.Container.IsRegistered(serviceType) ? this.Container.Resolve(serviceType) : null;
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <returns>
        /// The retrieved collection of services.
        /// </returns>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Container.IsRegistered(serviceType)
                       ? this.Container.ResolveAll(serviceType)
                       : new List<object>();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.Container.Dispose();
        }
    }
}