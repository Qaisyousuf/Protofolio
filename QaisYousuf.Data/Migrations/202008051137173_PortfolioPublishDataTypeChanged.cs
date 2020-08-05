namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PortfolioPublishDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PortfolioProjects", "ProjectPublishDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PortfolioProjects", "ProjectPublishDate", c => c.String());
        }
    }
}
