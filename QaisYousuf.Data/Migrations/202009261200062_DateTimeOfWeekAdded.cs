namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeOfWeekAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactDetails", "CountryName", c => c.String());
            AddColumn("dbo.ContactDetails", "SaleEamil", c => c.String());
            AddColumn("dbo.ContactDetails", "WorkingDateTimeOfWeek", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactDetails", "WorkingDateTimeOfWeek");
            DropColumn("dbo.ContactDetails", "SaleEamil");
            DropColumn("dbo.ContactDetails", "CountryName");
        }
    }
}
