// ----------------------------------------------------------------------
// <copyright file="IContext.cs" company="">
//  IContext
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Cblog.Model.Models;

    public interface IContext : IDisposable
    {
        DbEntityEntry Entry(object entity);
        DbContextConfiguration Configuration { get; }

        IDbSet<UserProfile> Users { get; set; }
        IDbSet<Membership> Membership { get; set; }
        IDbSet<OAuthMembership> OAuthMembership { get; set; }
        IDbSet<Role> Roles { get; set; }
        IDbSet<Post> Posts { get; set; }

        int SaveChanges();
    }
}
