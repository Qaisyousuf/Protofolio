namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodePageDataTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CodePages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CodePages", "IsVisibleToSearchEngine", c => c.String());
        }
    }
}
