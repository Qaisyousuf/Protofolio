namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringChangeToBoolInPortfolio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Portfolios", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Portfolios", "IsVisibleToSearchEngine", c => c.String());
        }
    }
}
