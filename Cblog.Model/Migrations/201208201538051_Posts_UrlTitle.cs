// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201208201538051_Posts_UrlTitle.cs" company="cvlad">
//   UrlTitle
// </copyright>
// <summary>
//   Defines the Posts_UrlTitle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Cblog.Model.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The posts_ url title.
    /// </summary>
    public partial class Posts_UrlTitle : DbMigration
    {
        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("dbo.Posts", "UrlTitle", c => c.String());
        }

        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.DropColumn("dbo.Posts", "UrlTitle");
        }
    }
}
