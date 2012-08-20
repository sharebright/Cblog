namespace Cblog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Posts_UrlTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "UrlTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "UrlTitle");
        }
    }
}
