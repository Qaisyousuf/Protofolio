namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainTitleAddedToTheWorkExperienceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkExperiences", "Maintitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkExperiences", "Maintitle");
        }
    }
}
