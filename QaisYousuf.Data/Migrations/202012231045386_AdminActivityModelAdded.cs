namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminActivityModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(),
                        UserAgint = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        LoginUser = c.String(),
                        UserBrowser = c.String(),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AuthenticationActivity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminActivities");
        }
    }
}
