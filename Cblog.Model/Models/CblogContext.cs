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

        public IDbSet<UserProfile> Users { get; set; }
        public IDbSet<Membership> Membership { get; set; }
        public IDbSet<OAuthMembership> OAuthMembership { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new MembershipMap());
            modelBuilder.Configurations.Add(new OAuthMembershipMap());
            modelBuilder.Configurations.Add(new RoleMap());
        }
    }
}
