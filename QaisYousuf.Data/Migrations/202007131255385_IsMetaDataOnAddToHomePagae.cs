namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsMetaDataOnAddToHomePagae : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomePages", "IsPageMetaDataOn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomePages", "IsPageMetaDataOn");
        }
    }
}
