namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContentPropertyAddToAboutPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AboutPages", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AboutPages", "Content");
        }
    }
}
