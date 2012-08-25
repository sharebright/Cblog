// ----------------------------------------------------------------------
// <copyright file="UserProfileMap.cs" company="cvlad">
//  UserProfileMap
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The user profile map.
    /// </summary>
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileMap"/> class.
        /// </summary>
        public UserProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(56);

            // Table & Column Mappings
            this.ToTable("UserProfile");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserName).HasColumnName("UserName");
        }
    }
}
