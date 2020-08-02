namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectStatusAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnderDevelopment = c.String(),
                        Completed = c.String(),
                        TestingPhase = c.String(),
                        PortfolioProject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PortfolioProjects", t => t.PortfolioProject_Id)
                .Index(t => t.PortfolioProject_Id);
            
            AddColumn("dbo.PortfolioProjects", "Content", c => c.String());
            AddColumn("dbo.PortfolioProjects", "SubContent", c => c.String());
            AddColumn("dbo.PortfolioProjects", "ProjectDetails", c => c.String());
            AddColumn("dbo.PortfolioProjects", "ProjectWebSiteUrl", c => c.String());
            AddColumn("dbo.PortfolioProjects", "ButtonText", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectStatus", "PortfolioProject_Id", "dbo.PortfolioProjects");
            DropIndex("dbo.ProjectStatus", new[] { "PortfolioProject_Id" });
            DropColumn("dbo.PortfolioProjects", "ButtonText");
            DropColumn("dbo.PortfolioProjects", "ProjectWebSiteUrl");
            DropColumn("dbo.PortfolioProjects", "ProjectDetails");
            DropColumn("dbo.PortfolioProjects", "SubContent");
            DropColumn("dbo.PortfolioProjects", "Content");
            DropTable("dbo.ProjectStatus");
        }
    }
}
