// ----------------------------------------------------------------------
// <copyright file="AuthConfig.cs" company="cvlad">
//  AuthConfig
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Cblog.Web.Models;

    using WebMatrix.WebData;

    /// <summary>
    /// The auth config.
    /// </summary>
    public static class AuthConfig
    {
        /// <summary>
        /// Registers OAuth providers.
        /// </summary>
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            // OAuthWebSecurity.RegisterMicrosoftClient(
            // clientId: "",
            // clientSecret: "");

            // OAuthWebSecurity.RegisterTwitterClient(
            // consumerKey: "",
            // consumerSecret: "");

            // OAuthWebSecurity.RegisterFacebookClient(
            // appId: "",
            // appSecret: "");

            // OAuthWebSecurity.RegisterGoogleClient();
        }

        /// <summary>
        /// Initializes membership.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the membership cannot be initialised. Check settings.
        /// </exception>
        public static void InitializeMembership()
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
