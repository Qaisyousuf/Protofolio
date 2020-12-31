namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelAddedToUserDashboardModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDashboards", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserDashboards", "UserId");
            AddForeignKey("dbo.UserDashboards", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDashboards", "UserId", "dbo.Users");
            DropIndex("dbo.UserDashboards", new[] { "UserId" });
            DropColumn("dbo.UserDashboards", "UserId");
        }
    }
}
