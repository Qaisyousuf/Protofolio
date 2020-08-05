namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubTitleAddedToInterestModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interests", "Subtitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Interests", "Subtitle");
        }
    }
}
