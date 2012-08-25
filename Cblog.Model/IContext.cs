// ----------------------------------------------------------------------
// <copyright file="IContext.cs" company="cvlad">
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

    /// <summary>
    /// The Context interface.
    /// </summary>
    public interface IContext : IDisposable
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        DbContextConfiguration Configuration { get; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        IDbSet<UserProfile> Users { get; set; }

        /// <summary>
        /// Gets or sets the membership.
        /// </summary>
        IDbSet<Membership> Membership { get; set; }

        /// <summary>
        /// Gets or sets the o auth membership.
        /// </summary>
        IDbSet<OAuthMembership> OAuthMembership { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        IDbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        IDbSet<Post> Posts { get; set; }

        /// <summary>
        /// Allows changing the entry information for the current context.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity entry information for the entity passed.
        /// </returns>
        DbEntityEntry Entry(object entity);

        /// <summary>
        /// Commits the changes to the database.
        /// </summary>
        /// <returns>
        /// Number of affected rows.
        /// </returns>
        int SaveChanges();
    }
}
