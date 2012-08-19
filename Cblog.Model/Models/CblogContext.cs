namespace Cblog.Model.Models
{
    using System.Data.Entity;
    using Cblog.Model.Models.Mapping;

    public class CblogContext : DbContext
    {
        static CblogContext()
        {
            Database.SetInitializer<CblogContext>(null);
        }

		public CblogContext()
			: base("Name=CblogContext")
		{
		}

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OAuthUser> OAuthUsers { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new webpages_MembershipMap());
            modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
        }
    }
}
