namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsVisibleToSearchEnginDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HomePages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HomePages", "IsVisibleToSearchEngine", c => c.String());
        }
    }
}
