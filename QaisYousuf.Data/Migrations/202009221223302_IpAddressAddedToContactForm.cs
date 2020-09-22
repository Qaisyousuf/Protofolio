namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IpAddressAddedToContactForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "IpAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "IpAddress");
        }
    }
}
