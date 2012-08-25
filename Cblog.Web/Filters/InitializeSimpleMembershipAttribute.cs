// ----------------------------------------------------------------------
// <copyright file="InitializeSimpleMembershipAttribute.cs" company="cvlad">
//  InitializeSimpleMembershipAttribute
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.Filters
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading;
    using System.Web.Mvc;
    using Cblog.Web.Models;
    using WebMatrix.WebData;

    /// <summary>
    /// The initialize simple membership attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// The initializer_.
        /// </summary>
        private static SimpleMembershipInitializer initializer_;

        /// <summary>
        /// The initializer_ lock.
        /// </summary>
        private static object initializerLock_ = new object();

        /// <summary>
        /// The _is initialized.
        /// </summary>
        private static bool isInitialized_;

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref initializer_, ref isInitialized_, ref initializerLock_);
        }

        /// <summary>
        /// The simple membership initializer.
        /// </summary>
// ReSharper disable ClassNeverInstantiated.Local
        private class SimpleMembershipInitializer
// ReSharper restore ClassNeverInstantiated.Local
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SimpleMembershipInitializer"/> class.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// Database could not be initialised.
            /// </exception>
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("CblogContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
