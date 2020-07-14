namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyNameChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomePages", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomePages", "Content");
        }
    }
}
