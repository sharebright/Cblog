// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201208192113486_Posts.cs" company="cvlad">
//   Posts
// </copyright>
// <summary>
//   The posts.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Cblog.Model.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The posts.
    /// </summary>
    public partial class Posts : DbMigration
    {
        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }

        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.DropIndex("dbo.Posts", new[] { "UserId" });
            this.DropForeignKey("dbo.Posts", "UserId", "dbo.UserProfile");
            this.DropTable("dbo.Posts");
        }
    }
}
