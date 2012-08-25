// ----------------------------------------------------------------------
// <copyright file="CblogContext.cs" company="cvlad">
//  CblogContext
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    using System.Data.Entity;
    using Cblog.Model.Models.Mapping;

    /// <summary>
    /// The cblog context.
    /// </summary>
    public class CblogContext : DbContext, IContext
    {
        /// <summary>
        /// Initializes static members of the <see cref="CblogContext"/> class.
        /// </summary>
        static CblogContext()
        {
            Database.SetInitializer<CblogContext>(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CblogContext"/> class.
        /// </summary>
        public CblogContext()
            : base("Name=CblogContext")
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public IDbSet<UserProfile> Users { get; set; }

        /// <summary>
        /// Gets or sets the membership.
        /// </summary>
        public IDbSet<Membership> Membership { get; set; }

        /// <summary>
        /// Gets or sets the o auth membership.
        /// </summary>
        public IDbSet<OAuthMembership> OAuthMembership { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public IDbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        public IDbSet<Post> Posts { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new MembershipMap());
            modelBuilder.Configurations.Add(new OAuthMembershipMap());
            modelBuilder.Configurations.Add(new RoleMap());
        }
    }
}
