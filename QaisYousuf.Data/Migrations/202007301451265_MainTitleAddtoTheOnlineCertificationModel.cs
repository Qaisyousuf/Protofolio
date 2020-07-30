namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainTitleAddtoTheOnlineCertificationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OnlineCertifications", "MainTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OnlineCertifications", "MainTitle");
        }
    }
}
