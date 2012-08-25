// ----------------------------------------------------------------------
// <copyright file="InitializeApplication.cs" company="cvlad">
//  InitializeApplication
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web.App_Start
{
    using System.Configuration;
    using System.Web.Security;

    using WebMatrix.WebData;

    /// <summary>
    /// The initialize application.
    /// </summary>
    public static class InitializeApplication
    {
        /// <summary>
        /// Initializes the application.
        /// </summary>
        public static void Initialize()
        {
            var username = ConfigurationManager.AppSettings["adminName"];
            var password = ConfigurationManager.AppSettings["defaultPass"];
            try
            {
                var user = Membership.GetUser(username);
                if (user == null)
                {
                    WebSecurity.CreateUserAndAccount(username, password);
                    if (!Roles.RoleExists("admin"))
                    {
                        Roles.CreateRole("admin");
                    }

                    Roles.AddUserToRole(username, "admin");
                }
            }
            catch
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(username, password);
                    if (!Roles.RoleExists("admin"))
                    {
                        Roles.CreateRole("admin");
                    }

                    Roles.AddUserToRole(username, "admin");
                }
// ReSharper disable EmptyGeneralCatchClause
                catch
// ReSharper restore EmptyGeneralCatchClause
                {
                }
            }
        }
    }
}