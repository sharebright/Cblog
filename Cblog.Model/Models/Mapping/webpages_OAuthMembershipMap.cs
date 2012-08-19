using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Cblog.Model.Models.Mapping
{
    public class webpages_OAuthMembershipMap : EntityTypeConfiguration<OAuthUser>
    {
        public webpages_OAuthMembershipMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Provider, t.ProviderUserId });

            // Properties
            this.Property(t => t.Provider)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.ProviderUserId)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("webpages_OAuthMembership");
            this.Property(t => t.Provider).HasColumnName("Provider");
            this.Property(t => t.ProviderUserId).HasColumnName("ProviderUserId");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
