// ----------------------------------------------------------------------
// <copyright file="PostMap.cs" company="cvlad">
//  PostMap
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The post map.
    /// </summary>
    public class PostMap : EntityTypeConfiguration<Post>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostMap"/> class.
        /// </summary>
        public PostMap()
        {
            // Primary key
            this.HasKey(p => p.PostId);

            // Properties
            this.Property(p => p.Title)
                .IsRequired()
                .IsMaxLength();

            this.Property(p => p.Content)
                .IsRequired()
                .IsMaxLength();

            this.Property(p => p.UrlTitle)
                .IsRequired()
                .IsMaxLength();

            // Table & Column Mappings
            this.ToTable("Posts");
            this.Property(p => p.PostId).HasColumnName("PostId");
            this.Property(p => p.Title).HasColumnName("Title");
            this.Property(p => p.Content).HasColumnName("Content");
            this.Property(p => p.CreatedAt).HasColumnName("CreatedAt");

            this.HasRequired(p => p.User)
                .WithOptional()
                .WillCascadeOnDelete(false);
        }
    }
}
