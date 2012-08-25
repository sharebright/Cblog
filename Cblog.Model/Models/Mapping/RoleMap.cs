// ----------------------------------------------------------------------
// <copyright file="RoleMap.cs" company="cvlad">
//  RoleMap
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The role map.
    /// </summary>
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleMap"/> class.
        /// </summary>
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleId);

            // Properties
            this.Property(t => t.RoleName)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("webpages_Roles");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RoleName).HasColumnName("RoleName");

            // Relationships
            this.HasMany(t => t.UserProfiles)
                .WithMany(t => t.Roles)
                .Map(m =>
                    {
                        m.ToTable("webpages_UsersInRoles");
                        m.MapLeftKey("RoleId");
                        m.MapRightKey("UserId");
                    });


        }
    }
}
