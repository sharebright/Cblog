// ----------------------------------------------------------------------
// <copyright file="InitializeApplication.cs" company="">
//  InitializeApplication
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Web
{
    using System.Configuration;
    using System.Web.Security;
    using WebMatrix.WebData;

    public static class InitializeApplication
    {
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
            catch {
                try
                {
                    WebSecurity.CreateUserAndAccount(username, password);
                    if (!Roles.RoleExists("admin"))
                    {
                        Roles.CreateRole("admin");
                    }
                    Roles.AddUserToRole(username, "admin");
                }
                catch { }
            }
            
        }
    }
}