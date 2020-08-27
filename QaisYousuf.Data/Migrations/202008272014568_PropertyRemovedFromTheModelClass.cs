namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyRemovedFromTheModelClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PlatformDesigns", "ModalTitle");
            DropColumn("dbo.PlatformDesigns", "ModalsContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlatformDesigns", "ModalsContent", c => c.String());
            AddColumn("dbo.PlatformDesigns", "ModalTitle", c => c.String());
        }
    }
}
