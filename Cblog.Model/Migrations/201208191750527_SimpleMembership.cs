// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201208191750527_SimpleMembership.cs" company="cvlad">
//   SimpleMembership
// </copyright>
// <summary>
//   The simple membership.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Cblog.Model.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The simple membership.
    /// </summary>
    public partial class SimpleMembership : DbMigration
    {
        /// <summary>
        /// The up.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 56),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.webpages_Membership",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ConfirmationToken = c.String(maxLength: 128),
                        IsConfirmed = c.Boolean(),
                        LastPasswordFailureDate = c.DateTime(),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 128),
                        PasswordChangedDate = c.DateTime(),
                        PasswordSalt = c.String(nullable: false, maxLength: 128),
                        PasswordVerificationToken = c.String(maxLength: 128),
                        PasswordVerificationTokenExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_OAuthMembership",
                c => new
                    {
                        Provider = c.String(nullable: false, maxLength: 30),
                        ProviderUserId = c.String(nullable: false, maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider, t.ProviderUserId });
            
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
        }

        /// <summary>
        /// The down.
        /// </summary>
        public override void Down()
        {
            this.DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            this.DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            this.DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.UserProfile");
            this.DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            this.DropTable("dbo.webpages_UsersInRoles");
            this.DropTable("dbo.webpages_OAuthMembership");
            this.DropTable("dbo.webpages_Membership");
            this.DropTable("dbo.webpages_Roles");
            this.DropTable("dbo.UserProfile");
        }
    }
}
