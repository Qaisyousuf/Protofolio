namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactDetailsRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Portfolios", "PortfolioContactDetails", "dbo.ContactDetails");
            DropIndex("dbo.Portfolios", new[] { "PortfolioContactDetails" });
            DropColumn("dbo.Portfolios", "PortfolioContactDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolios", "PortfolioContactDetails", c => c.Int(nullable: false));
            CreateIndex("dbo.Portfolios", "PortfolioContactDetails");
            AddForeignKey("dbo.Portfolios", "PortfolioContactDetails", "dbo.ContactDetails", "Id", cascadeDelete: true);
        }
    }
}
