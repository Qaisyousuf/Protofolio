namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiteSettingsAddedAgain : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SiteSettings", newName: "Settings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Settings", newName: "SiteSettings");
        }
    }
}
