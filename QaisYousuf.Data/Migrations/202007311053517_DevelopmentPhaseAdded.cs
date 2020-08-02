namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DevelopmentPhaseAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectStatus", "DevelopmentPhase", c => c.String());
            DropColumn("dbo.ProjectStatus", "UnderDevelopment");
            DropColumn("dbo.ProjectStatus", "Completed");
            DropColumn("dbo.ProjectStatus", "TestingPhase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectStatus", "TestingPhase", c => c.String());
            AddColumn("dbo.ProjectStatus", "Completed", c => c.String());
            AddColumn("dbo.ProjectStatus", "UnderDevelopment", c => c.String());
            DropColumn("dbo.ProjectStatus", "DevelopmentPhase");
        }
    }
}
