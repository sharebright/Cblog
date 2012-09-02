// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CblogApiController.cs" company="cvlad">
//   CblogApiController base
// </copyright>
// <summary>
//   Defines the CblogApiController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Cblog.Web.Controllers
{
    using System.Web.Http;

    /// <summary>
    /// The cblog api controller base.
    /// </summary>
    public abstract class CblogApiController : ApiController
    {
        /// <summary>
        /// The resolve.
        /// </summary>
        /// <typeparam name="T">
        /// The type to resolve.
        /// </typeparam>
        /// <returns>
        /// The T.
        /// </returns>
        protected T Resolve<T>() where T : class
        {
            return GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(T)) as T;
        }
    }
}