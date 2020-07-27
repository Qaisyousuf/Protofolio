namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactPageDataTypeChagedForIsVisibleToSearchEngine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactPages", "IsVisibleToSearchEngine", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactPages", "IsVisibleToSearchEngine", c => c.String());
        }
    }
}
