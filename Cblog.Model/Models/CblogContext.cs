// ----------------------------------------------------------------------
// <copyright file="CblogContext.cs" company="">
//  CblogContext
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models
{
    using System.Data.Entity;
    using Cblog.Model.Models.Mapping;

    public class CblogContext : DbContext, IContext
    {
        static CblogContext()
        {
            Database.SetInitializer<CblogContext>(null);
        }

		public CblogContext()
			: base("Name=CblogContext")
		{
		}

        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<OAuthMembership> OAuthMembership { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new MembershipMap());
            modelBuilder.Configurations.Add(new OAuthMembershipMap());
            modelBuilder.Configurations.Add(new RoleMap());
        }
    }
}
