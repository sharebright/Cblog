// ----------------------------------------------------------------------
// <copyright file="OAuthMembershipMap.cs" company="cvlad">
//  OAuthMembershipMap
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The o auth membership map.
    /// </summary>
    public class OAuthMembershipMap : EntityTypeConfiguration<OAuthMembership>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthMembershipMap"/> class.
        /// </summary>
        public OAuthMembershipMap()
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
