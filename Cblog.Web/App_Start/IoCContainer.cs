// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoCContainer.cs" company="cvlad">
//   IoC Container
// </copyright>
// <summary>
//   The io c container.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Cblog.Web.App_Start
{
    using System.Web.Http.Dependencies;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The IoC container.
    /// </summary>
    public class IoCContainer : ScopeContainer, IDependencyResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IoCContainer"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public IoCContainer(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Starts a resolution scope. 
        /// </summary>
        /// <returns>
        /// The dependency scope.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            var child = this.Container.CreateChildContainer();
            return new ScopeContainer(child);
        }
    }
}