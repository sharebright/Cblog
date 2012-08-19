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

        DbSet<UserProfile> Users { get; set; }
        DbSet<Membership> Membership { get; set; }
        DbSet<OAuthMembership> OAuthMembership { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Post> Posts { get; set; }

        int SaveChanges();
    }
}
