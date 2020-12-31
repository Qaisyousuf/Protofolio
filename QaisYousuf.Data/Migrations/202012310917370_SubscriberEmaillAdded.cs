namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscriberEmaillAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubscriberEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubscriberEmails");
        }
    }
}
