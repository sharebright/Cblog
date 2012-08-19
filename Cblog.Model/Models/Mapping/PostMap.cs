// ----------------------------------------------------------------------
// <copyright file="PostMap.cs" company="">
//  PostMap
// </copyright>
// <author>Vladimir Ciobanu</author>
// ----------------------------------------------------------------------

namespace Cblog.Model.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class PostMap : EntityTypeConfiguration<Post>
    {
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
