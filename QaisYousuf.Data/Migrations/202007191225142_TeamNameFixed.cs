namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamNameFixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AboutPages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AboutPages", "IsVisibleToSearchEngine", c => c.String());
        }
    }
}
