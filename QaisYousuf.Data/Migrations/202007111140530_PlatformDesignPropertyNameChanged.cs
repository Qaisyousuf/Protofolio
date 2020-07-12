namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlatformDesignPropertyNameChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlatformDesigns", "MainTitle", c => c.String());
            DropColumn("dbo.PlatformDesigns", "MainTile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlatformDesigns", "MainTile", c => c.String());
            DropColumn("dbo.PlatformDesigns", "MainTitle");
        }
    }
}
