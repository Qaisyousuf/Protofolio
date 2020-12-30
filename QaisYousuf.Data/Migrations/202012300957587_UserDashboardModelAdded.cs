namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDashboardModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDashboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthenticatedUser = c.String(),
                        Content = c.String(),
                        ProjectName = c.String(),
                        ProjectStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ProjectFinishDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ProjectType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDashboards");
        }
    }
}
