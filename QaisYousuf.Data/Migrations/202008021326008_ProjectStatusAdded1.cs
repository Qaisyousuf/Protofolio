namespace QaisYousuf.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectStatusAdded1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectStatus", "PortfolioProject_Id", "dbo.PortfolioProjects");
            DropIndex("dbo.ProjectStatus", new[] { "PortfolioProject_Id" });
            DropColumn("dbo.ProjectStatus", "PortfolioProject_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectStatus", "PortfolioProject_Id", c => c.Int());
            CreateIndex("dbo.ProjectStatus", "PortfolioProject_Id");
            AddForeignKey("dbo.ProjectStatus", "PortfolioProject_Id", "dbo.PortfolioProjects", "Id");
        }
    }
}
