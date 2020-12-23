namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminDashBoardModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminDashboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Content = c.String(),
                        AuthenticatedUser = c.String(),
                        LogintDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LottiAnimationUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminDashboards");
        }
    }
}
